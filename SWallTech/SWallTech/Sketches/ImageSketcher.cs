using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace SWallTech
{
	public delegate void SketchCreatedEventHandler(object sender, SketchCreatedEventArgs e);

	public class SketchCreatedEventArgs : EventArgs
	{
		private Bitmap _sketch;
		private int _record;
		private int _card;
		private string _fileName;
		private int _counter;

		public SketchCreatedEventArgs(Bitmap sketch, int record, int card, string fileName, int counter)
		{
			_sketch = sketch;
			_record = record;
			_card = card;
			_fileName = fileName;
			_counter = counter;
		}

		public Bitmap Sketch
		{
			get
			{
				return _sketch;
			}
		}

		public int Record
		{
			get
			{
				return _record;
			}
		}

		public int Card
		{
			get
			{
				return _card;
			}
		}

		public int Counter
		{
			get
			{
				return _counter;
			}
		}

		public string FileName
		{
			get
			{
				return _fileName;
			}
		}
	}

	public class ImageSketcher
	{
		public event SketchCreatedEventHandler SketchCreatedEvent;

		private CAMRA_Connection _conn;
		private SupportedTypes _type = SupportedTypes.JPG;
		private int _sizeInPixels = 400;
		private int _beginningRecord = 0;
		private int _endingRecord = 0;
		private string _targetDirectory;
		private Bitmap _sketch;

		public enum SupportedTypes
		{
			BMP,
			GIF,
			JPG,
			PNG,
			TIF,
			WMF
		}

		private ImageSketcher()
		{
		}

		public ImageSketcher(CAMRA_Connection conn)
		{
			_conn = conn;
		}

		public CAMRA_Connection Connection
		{
			get
			{
				return _conn;
			}
		}

		public SupportedTypes Type
		{
			get
			{
				return _type;
			}
		}

		public string TargetDirectory
		{
			get
			{
				return _targetDirectory;
			}
		}

		public int SizeInPixels
		{
			get
			{
				return _sizeInPixels;
			}
		}

		public int BeginningRecord
		{
			get
			{
				return _beginningRecord;
			}
		}

		public int EndingRecord
		{
			get
			{
				return _endingRecord;
			}
		}

		public int GetSketchCount()
		{
			return GetSketchCount(_beginningRecord, _endingRecord);
		}

		public int GetSketchCount(int beginningRecord, int endingRecord)
		{
			int count = 0;

			DBAccessManager _db = new DBAccessManager(DBAccessManager.DatabaseTypes.iSeriesDB2,
				_conn.DataSource, null, _conn.User, _conn.Password, null);

			if (_db.IsConnected)
			{
				StringBuilder sql = new StringBuilder();
				sql.Append("select count(*) from ");
				sql.Append(_conn.Library);
				sql.Append(_db.SeparatorCharacter);
				sql.Append(_conn.LocalityPrefix);
				sql.Append("MASTER where JMSKETCH = 'Y'");

				// Record number selections
				if (beginningRecord > 0 && endingRecord > beginningRecord)
				{
					sql.Append(" and JMRECORD between ");
					sql.Append(beginningRecord.ToString());
					sql.Append(" and ");
					sql.Append(endingRecord.ToString());
				}
				else if (beginningRecord > 0 && endingRecord < beginningRecord)
				{
					sql.Append(" and JMRECORD >= ");
					sql.Append(beginningRecord.ToString());
				}
				else if (beginningRecord <= 0 && endingRecord > 0)
				{
					sql.Append(" and JMRECORD <= ");
					sql.Append(endingRecord.ToString());
				}
				else if (beginningRecord > 0 && beginningRecord == endingRecord)
				{
					sql.Append(" and JMRECORD = ");
					sql.Append(beginningRecord.ToString());
				}

				object obj = _db.ExecuteScalar(sql.ToString());
				count = Convert.ToInt32(obj);
			}

			_db.Close();

			return count;
		}

		public int CreateSketchImages(string targetDirectory)
		{
			return CreateSketchImages(_conn, targetDirectory, _type, _sizeInPixels, _beginningRecord, _endingRecord);
		}

		public int CreateSketchImages(string targetDirectory, SupportedTypes type)
		{
			return CreateSketchImages(_conn, targetDirectory, type, _sizeInPixels, _beginningRecord, _endingRecord);
		}

		public int CreateSketchImages(string targetDirectory, SupportedTypes type, int sizeInPixels)
		{
			return CreateSketchImages(_conn, targetDirectory, type, sizeInPixels, _beginningRecord, _endingRecord);
		}

		public int CreateSketchImages(string targetDirectory, SupportedTypes type, int sizeInPixels, int beginningRecord)
		{
			return CreateSketchImages(_conn, targetDirectory, type, sizeInPixels, beginningRecord, _endingRecord);
		}

		public int CreateSketchImages(string targetDirectory, SupportedTypes type, int sizeInPixels, int beginningRecord, int endingRecord)
		{
			return CreateSketchImages(_conn, targetDirectory, type, sizeInPixels, beginningRecord, endingRecord);
		}

		public Bitmap CreateSingleSketch(CAMRA_Connection conn, int sizeInPixels, int recordNumber, int cardNumber)
		{
			_sketch = null;
			this.CreateSketchImages(conn, String.Empty, SupportedTypes.BMP, sizeInPixels, recordNumber, recordNumber, cardNumber);
			return _sketch;
		}

		private int CreateSketchImages(CAMRA_Connection conn, string targetDirectory, SupportedTypes type, int sizeInPixels, int beginningRecord, int endingRecord)
		{
			return this.CreateSketchImages(conn, targetDirectory, type, sizeInPixels, beginningRecord, endingRecord, int.MinValue);
		}

		private int CreateSketchImages(CAMRA_Connection conn, string targetDirectory, SupportedTypes type, int sizeInPixels, int beginningRecord, int endingRecord, int cardNumber)
		{
			_targetDirectory = targetDirectory;
			_type = type;
			_sizeInPixels = sizeInPixels;
			_beginningRecord = beginningRecord;
			_endingRecord = endingRecord;

			int sketchesCreated = 0;

			DBAccessManager _db = new DBAccessManager(DBAccessManager.DatabaseTypes.iSeriesDB2,
				conn.DataSource, null, conn.User, conn.Password, null);

			if (_db.IsConnected)
			{
				// Check Target Directory if not exists
				if (!_targetDirectory.Equals(String.Empty) && !Directory.Exists(targetDirectory))
				{
					throw new IOException("Target Directory " + targetDirectory + " does not exist.");
				}

				// File Names
				string _master = conn.Library + _db.SeparatorCharacter + conn.LocalityPrefix + "MASTER";
				string _section = conn.Library + _db.SeparatorCharacter + conn.LocalityPrefix + "SECTION";
				string _line = conn.Library + _db.SeparatorCharacter + conn.LocalityPrefix + "LINE";

				// Create Paramaterized Select Statements for SECTION and LINE
				StringBuilder _section_SELECT = new StringBuilder();
				_section_SELECT.Append("select JSSECT, JSTYPE, JSSTORY, JSSQFT from ");
				_section_SELECT.Append(_section);
				_section_SELECT.Append(" where JSRECORD = @JSRECORD and JSDWELL = @JSDWELL and JSSKETCH = 'Y'");
				_section_SELECT.Append(" order by JSSECT");

				IDataParameter _section_record_parm;
				_section_record_parm = _db.CreateParameter("@jsrecord", DatabaseConstants.DataTypes.Numeric, "jsrecord", 7, 0);
				IDataParameter _section_card_parm;
				_section_card_parm = _db.CreateParameter("@jsdwell", DatabaseConstants.DataTypes.Numeric, "jsdwell", 2, 0);

				IDbCommand _cmd_section_select = _db.CreateCommand(_section_SELECT.ToString());
				_cmd_section_select.Parameters.Add(_section_record_parm);
				_cmd_section_select.Parameters.Add(_section_card_parm);

				// Supplemental Connection for processing Lines
				DBAccessManager _db_line = new DBAccessManager(DBAccessManager.DatabaseTypes.iSeriesDB2,
					conn.DataSource, null, conn.User, conn.Password, null);

				StringBuilder _line_SELECT = new StringBuilder();
				_line_SELECT.Append("select JLLINE# as JLLINE, JLPT1X, JLPT1Y, JLPT2X, JLPT2Y, JLDIRECT, JLXLEN, JLYLEN from ");
				_line_SELECT.Append(_line);
				_line_SELECT.Append(" where JLRECORD = @JLRECORD and JLDWELL = @JLDWELL and JLSECT = @JLSECT");
				_line_SELECT.Append(" order by JLLINE");

				IDataParameter _line_record_parm;
				_line_record_parm = _db_line.CreateParameter("@jlrecord", DatabaseConstants.DataTypes.Numeric, "jlrecord", 7, 0);
				IDataParameter _line_card_parm;
				_line_card_parm = _db_line.CreateParameter("@jldwell", DatabaseConstants.DataTypes.Numeric, "jldwell", 2, 0);
				IDataParameter _line_sect_parm;
				_line_sect_parm = _db_line.CreateParameter("@jlsect", DatabaseConstants.DataTypes.Char, "jlsect", 2);

				IDbCommand _cmd_line_select = _db.CreateCommand(_line_SELECT.ToString());
				_cmd_line_select.Parameters.Add(_line_record_parm);
				_cmd_line_select.Parameters.Add(_line_card_parm);
				_cmd_line_select.Parameters.Add(_line_sect_parm);

				// Create master Table to loop through
				StringBuilder skmaster_sql = new StringBuilder();
				skmaster_sql.Append("select jmrecord, jmdwell from ");
				skmaster_sql.Append(_master);
				skmaster_sql.Append(" where JMSKETCH = 'Y' ");

				// Record number selections
				if (beginningRecord > 0 && endingRecord > beginningRecord)
				{
					skmaster_sql.Append(" and JMRECORD between ");
					skmaster_sql.Append(beginningRecord.ToString());
					skmaster_sql.Append(" and ");
					skmaster_sql.Append(endingRecord.ToString());
				}
				else if (beginningRecord > 0 && endingRecord < beginningRecord)
				{
					skmaster_sql.Append(" and JMRECORD >= ");
					skmaster_sql.Append(beginningRecord.ToString());
				}
				else if (beginningRecord <= 0 && endingRecord > 0)
				{
					skmaster_sql.Append(" and JMRECORD <= ");
					skmaster_sql.Append(endingRecord.ToString());
				}
				else if (beginningRecord > 0 && beginningRecord == endingRecord)
				{
					skmaster_sql.Append(" and JMRECORD = ");
					skmaster_sql.Append(beginningRecord.ToString());
				}

				// Add Card number for Single Sketches
				if (!_targetDirectory.Equals(String.Empty) && cardNumber != int.MinValue)
				{
					skmaster_sql.Append(" and JMDWELL = ");
					skmaster_sql.Append(cardNumber.ToString());
				}

				// order by
				skmaster_sql.Append(" order by JMRECORD, JMDWELL");

				// Drawing variables
				Pen pen = new Pen(Color.Black, 1.0f);
				Pen base_pen = new Pen(Color.Black, 2.0f);
				Brush brush = new SolidBrush(Color.Black);

				float em = 8;
				if (sizeInPixels < 300)
				{
					em = 6;
				}
				else if (sizeInPixels > 500)
				{
					em = 10;
				}
				Font font = new Font(FontFamily.GenericSansSerif, em);

				List<string> noLabelTypes = new List<string>();
				noLabelTypes.Add("OH");
				noLabelTypes.Add("LAG");
				noLabelTypes.Add("ATTC");
				noLabelTypes.Add("BSMT");
				noLabelTypes.Add("FBMT");

				DataTable dt_master = _db.RunSelectStatement(skmaster_sql.ToString()).Tables[0];

				foreach (DataRow dr_master in dt_master.Rows)
				{
					SortedList<string, SectionInfo> sections = new SortedList<string, SectionInfo>();

					string record = dr_master["JMRECORD"].ToString();
					string card = dr_master["JMDWELL"].ToString();
					decimal MINX = 0;
					decimal MAXX = 0;
					decimal MINY = 0;
					decimal MAXY = 0;

					// Get Sections
					_db.SetParameterValue(_cmd_section_select.Parameters, "@JSRECORD", record);
					_db.SetParameterValue(_cmd_section_select.Parameters, "@JSDWELL", card);
					IDataReader _sectReader = _cmd_section_select.ExecuteReader();

					int ord_JSSECT = _sectReader.GetOrdinal("JSSECT");
					int ord_JSTYPE = _sectReader.GetOrdinal("JSTYPE");
					int ord_JSSTORY = _sectReader.GetOrdinal("JSSTORY");
					int ord_JSSQFT = _sectReader.GetOrdinal("JSSQFT");

					while (_sectReader.Read())
					{
						SectionInfo sectInfo = new SectionInfo();
						sectInfo.SECT = _sectReader.GetString(ord_JSSECT);
						sectInfo.TYPE = _sectReader.GetString(ord_JSTYPE).Trim();
						sectInfo.STORY = _sectReader.GetDecimal(ord_JSSTORY);
						sectInfo.SQFT = _sectReader.GetDecimal(ord_JSSQFT);
						List<LineInfo> LINELIST = new List<LineInfo>();

						_db_line.SetParameterValue(_cmd_line_select.Parameters, "@JLRECORD", record);
						_db_line.SetParameterValue(_cmd_line_select.Parameters, "@JLDWELL", card);
						_db_line.SetParameterValue(_cmd_line_select.Parameters, "@JLSECT", sectInfo.SECT);
						IDataReader _lineReader = _cmd_line_select.ExecuteReader();

						int ord_JLLINE = _lineReader.GetOrdinal("JLLINE");
						int ord_JLPT1X = _lineReader.GetOrdinal("JLPT1X");
						int ord_JLPT1Y = _lineReader.GetOrdinal("JLPT1Y");
						int ord_JLPT2X = _lineReader.GetOrdinal("JLPT2X");
						int ord_JLPT2Y = _lineReader.GetOrdinal("JLPT2Y");
						int ord_JLDIRECT = _lineReader.GetOrdinal("JLDIRECT");
						int ord_JLXLEN = _lineReader.GetOrdinal("JLXLEN");
						int ord_JLYLEN = _lineReader.GetOrdinal("JLYLEN");

						List<PointF> pts = new List<PointF>();
						while (_lineReader.Read())
						{
							//int seq = Convert.ToInt32(_lineReader.GetDecimal(ord_JLLINE));
							decimal x = _lineReader.GetDecimal(ord_JLPT1X);
							decimal y = _lineReader.GetDecimal(ord_JLPT1Y);
							decimal x2 = _lineReader.GetDecimal(ord_JLPT2X);
							decimal y2 = _lineReader.GetDecimal(ord_JLPT2Y);

							PointF pt = new PointF(Convert.ToSingle(x), Convert.ToSingle(y));

							if (x < MINX)
							{
								MINX = x;
							}
							if (x > MAXX)
							{
								MAXX = x;
							}
							if (y < MINY)
							{
								MINY = y;
							}
							if (y > MAXY)
							{
								MAXY = y;
							}

							string dir = _lineReader.GetString(ord_JLDIRECT).Trim();
							if ("N".Equals(dir) || "S".Equals(dir) || "E".Equals(dir) || "W".Equals(dir))
							{
								LineInfo line = new LineInfo();
								line.DIRECTION = dir;
								line.LINE_CENTER_POINT = new PointF();
								switch (dir)
								{
									case "N":
										line.LENGTH = _lineReader.GetDecimal(ord_JLYLEN);
										line.LINE_CENTER_POINT.X = pt.X;
										line.LINE_CENTER_POINT.Y = pt.Y - Convert.ToSingle(line.LENGTH / 2);
										break;

									case "S":
										line.LENGTH = _lineReader.GetDecimal(ord_JLYLEN);
										line.LINE_CENTER_POINT.X = pt.X;
										line.LINE_CENTER_POINT.Y = pt.Y + Convert.ToSingle(line.LENGTH / 2);
										break;

									case "E":
										line.LENGTH = _lineReader.GetDecimal(ord_JLXLEN);
										line.LINE_CENTER_POINT.X = pt.X + Convert.ToSingle(line.LENGTH / 2);
										line.LINE_CENTER_POINT.Y = pt.Y;
										break;

									case "W":
										line.LENGTH = _lineReader.GetDecimal(ord_JLXLEN);
										line.LINE_CENTER_POINT.X = pt.X - Convert.ToSingle(line.LENGTH / 2);
										line.LINE_CENTER_POINT.Y = pt.Y;
										break;

									default:
										break;
								}

								LINELIST.Add(line);
							}

							pts.Add(pt);
						}
						_lineReader.Close();
						sectInfo.POINTS = pts.ToArray();
						sectInfo.LINELIST = LINELIST.ToArray();
						sections.Add(sectInfo.SECT, sectInfo);
					}
					_sectReader.Close();

					// DRAW SKETCH
					if (sections.Values.Count > 0)
					{
						_sketch = new Bitmap(sizeInPixels, sizeInPixels, PixelFormat.Format32bppPArgb);
						Graphics g = Graphics.FromImage(_sketch);
						g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, sizeInPixels, sizeInPixels));
						int buffer = 20;
						int sizeNoBuffer = sizeInPixels - (buffer * 2);

						// Calculate scale and translation
						float XDIFF = Convert.ToSingle(Math.Abs(MAXX - MINX));
						float YDIFF = Convert.ToSingle(Math.Abs(MAXY - MINY));
						float XOFFSET = Convert.ToSingle(Math.Abs(MINX));
						float YOFFSET = Convert.ToSingle(Math.Abs(MINY));
						float scale = 1.0f;

						if (XDIFF >= YDIFF)
						{
							scale = Convert.ToSingle(sizeNoBuffer) / XDIFF;
						}
						else
						{
							scale = Convert.ToSingle(sizeNoBuffer) / YDIFF;
						}

						float XDIFF_ADJ = XDIFF *= scale;
						float YDIFF_ADJ = YDIFF *= scale;
						float CENTERX_ADJ = (sizeInPixels - XDIFF_ADJ) / 2;
						float CENTERY_ADJ = (sizeInPixels - YDIFF_ADJ) / 2;
						float TOTAL_X_ADJ = (XOFFSET * scale) + CENTERX_ADJ;
						float TOTAL_Y_ADJ = (YOFFSET * scale) + CENTERY_ADJ;

						//g.ScaleTransform(scale, scale);
						//g.TranslateTransform( TOTAL_X_ADJ, TOTAL_Y_ADJ );

						foreach (SectionInfo sect in sections.Values)
						{
							for (int i = 0; i < sect.POINTS.Length; i++)
							{
								sect.POINTS[i].X *= scale;
								sect.POINTS[i].X += TOTAL_X_ADJ;
								sect.POINTS[i].Y *= scale;
								sect.POINTS[i].Y += TOTAL_Y_ADJ;
							}

							for (int j = 0; j < sect.LINELIST.Length; j++)
							{
								sect.LINELIST[j].LINE_CENTER_POINT.X *= scale;
								sect.LINELIST[j].LINE_CENTER_POINT.X += TOTAL_X_ADJ;
								sect.LINELIST[j].LINE_CENTER_POINT.Y *= scale;
								sect.LINELIST[j].LINE_CENTER_POINT.Y += TOTAL_Y_ADJ;
							}

							bool isSketchDrawn = false;
							try
							{
								if ("A".Equals(sect.SECT.Trim()))
								{
									g.DrawPolygon(base_pen, sect.POINTS);
								}
								else
								{
									g.DrawPolygon(pen, sect.POINTS);
								}
								isSketchDrawn = true;
							}
							catch (System.ArgumentException aex)
							{
								Console.WriteLine(string.Format("{0}", aex.Message));
							}

							if (isSketchDrawn)
							{
								PolygonF poly = new PolygonF(sect.POINTS);
								if (poly.Contains(poly.CenterPoint) && !noLabelTypes.Contains(sect.TYPE))
								{
									bool drawDimensions = true;
									string TYPELABEL = sect.SECT + "- " + sect.TYPE;
									SizeF sz = g.MeasureString(TYPELABEL, font);
									if (sz.Width >= poly.Bounds.Width)
									{
										TYPELABEL = sect.SECT.Trim();
										sz = g.MeasureString(TYPELABEL, font);
										drawDimensions = false;
									}

									if (sz.Height < poly.Bounds.Height)
									{
										PointF tp = poly.CenterPoint;
										tp.X -= sz.Width / 2;
										tp.Y -= sz.Height / 2;

										if ("A".Equals(sect.SECT.Trim()))
										{
											tp.Y -= sz.Height;
											sz = g.MeasureString(sect.SQFT.ToString(), font);
											PointF sq = new PointF();
											sq.X = poly.CenterPoint.X;
											sq.X -= sz.Width / 2;
											sq.Y = tp.Y + sz.Height + 2;

											sz = g.MeasureString(sect.STORY.ToString(), font);
											PointF st = new PointF();
											st.X = poly.CenterPoint.X;
											st.X -= sz.Width / 2;
											st.Y = tp.Y + sz.Height + sz.Height + 4;

											g.DrawString(TYPELABEL, font, brush, tp);
											g.DrawString(sect.SQFT.ToString(), font, brush, sq);
											g.DrawString(sect.STORY.ToString(), font, brush, st);
										}
										else
										{
											g.DrawString(TYPELABEL, font, brush, tp);
										}

										if (drawDimensions)
										{
											foreach (LineInfo line in sect.LINELIST)
											{
												SizeF dimSz = g.MeasureString(line.LENGTH.ToString(), font);

												if ("N".Equals(line.DIRECTION) || "S".Equals(line.DIRECTION))
												{
													if ((sz.Width + (dimSz.Width * 2) + 4) < poly.Bounds.Width)
													{
														PointF dimPt = new PointF();
														dimPt.X = line.LINE_CENTER_POINT.X + 2;
														dimPt.Y = line.LINE_CENTER_POINT.Y;

														dimPt.Y -= dimSz.Height / 2;
														if (!poly.Contains(dimPt))
														{
															dimPt.X -= dimSz.Width + 2;
														}
														g.DrawString(line.LENGTH.ToString(), font, brush, dimPt);
													}
												}
												else if ("E".Equals(line.DIRECTION) || "W".Equals(line.DIRECTION))
												{
													if ((sz.Height + (dimSz.Height * 2) + 4) < poly.Bounds.Height)
													{
														PointF dimPt = new PointF();
														dimPt.X = line.LINE_CENTER_POINT.X;
														dimPt.Y = line.LINE_CENTER_POINT.Y + 2;

														dimPt.X -= dimSz.Width / 2;
														if (!poly.Contains(dimPt))
														{
															dimPt.Y -= dimSz.Height + 2;
														}
														g.DrawString(line.LENGTH.ToString(), font, brush, dimPt);
													}
												}
											}
										}
									}
								}
							}
						}

						StringBuilder saveFileName = new StringBuilder();
						if (!_targetDirectory.Equals(String.Empty))
						{
							saveFileName.Append(targetDirectory);
							saveFileName.Append("\\");
							saveFileName.Append(StringStuff.RightAdjustString(record, 7, '0'));
							saveFileName.Append("_");
							saveFileName.Append(StringStuff.RightAdjustString(card, 2, '0'));
							saveFileName.Append(".");
							saveFileName.Append(Enum.GetName(typeof(ImageSketcher.SupportedTypes), type).ToLower());

							switch (type)
							{
								case SupportedTypes.BMP:
									_sketch.Save(saveFileName.ToString(), ImageFormat.Bmp);
									break;

								case SupportedTypes.GIF:
									_sketch.Save(saveFileName.ToString(), ImageFormat.Gif);
									break;

								case SupportedTypes.JPG:
									_sketch.Save(saveFileName.ToString(), ImageFormat.Jpeg);
									break;

								case SupportedTypes.PNG:
									_sketch.Save(saveFileName.ToString(), ImageFormat.Png);
									break;

								case SupportedTypes.TIF:
									_sketch.Save(saveFileName.ToString(), ImageFormat.Tiff);
									break;

								case SupportedTypes.WMF:
									_sketch.Save(saveFileName.ToString(), ImageFormat.Wmf);
									break;

								default:
									_sketch.Save(saveFileName.ToString(), ImageFormat.Jpeg);
									break;
							}
						}
						sketchesCreated++;

						if (SketchCreatedEvent != null)
						{
							SketchCreatedEvent(null, new SketchCreatedEventArgs(_sketch, int.Parse(record), int.Parse(card), saveFileName.ToString(), sketchesCreated));
						}
					}
				}
			}

			return sketchesCreated;
		}

		public struct SectionInfo
		{
			public string SECT;
			public string TYPE;
			public decimal STORY;
			public decimal SQFT;
			public PointF[] POINTS;
			public LineInfo[] LINELIST;
		}

		public struct LineInfo
		{
			public string DIRECTION;
			public decimal LENGTH;
			public PointF LINE_CENTER_POINT;
		}
	}
}