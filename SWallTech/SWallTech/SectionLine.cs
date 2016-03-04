using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace SWallTech
{
	/// <summary>
	/// Summary description for SectionLine.
	/// </summary>
	public class SectionLine
	{
		#region Variables

		// Data File fields
		private FixedDecimal JLRECORD = new FixedDecimal(7, 0, false);

		private FixedDecimal JLDWELL = new FixedDecimal(2, 0, false);
		private FixedString JLSECT = new FixedString(2);
		private FixedDecimal JLLINE = new FixedDecimal(3, 0, false);
		private FixedString JLDIRECT = new FixedString(2);
		private FixedDecimal JLXLEN = new FixedDecimal(4, 1, false);
		private FixedDecimal JLYLEN = new FixedDecimal(4, 1, false);
		private FixedDecimal JLLINELEN = new FixedDecimal(4, 1, false);
		private FixedDecimal JLANGLE = new FixedDecimal(4, 1, false);
		private FixedDecimal JLPT1X = new FixedDecimal(9, 4);
		private FixedDecimal JLPT1Y = new FixedDecimal(9, 4);
		private FixedDecimal JLPT2X = new FixedDecimal(9, 4);
		private FixedDecimal JLPT2Y = new FixedDecimal(9, 4);
		private FixedString JLATTACH = new FixedString(2);

		private string locality;
		private string fileNameLines;
		private IDBAccess db;

		private DataSet rs;
		private DataTable dt;
		private DataRow dr;

		#endregion Variables

		#region Constructors

		private SectionLine()
		{
		}

		/// <summary>
		/// Creates a new SketchSection instance for the specified database connection.
		/// </summary>
		/// <param name="db">The IDBAccess Database connection object to use.</param>
		public SectionLine(IDBAccess db)
		{
			this.db = db;
		}

		/// <summary>
		/// Creates a new SectionLine instance for the specified database connection and populates
		/// its properties for the specified parcel/card/section/lineNumber.
		/// </summary>
		/// <param name="db">The IDBAccess Database connection object to use.</param>
		/// <param name="locality">Specifies the locality code for this table.</param>
		/// <param name="parcel">The parcel number.</param>
		/// <param name="card">The card number.</param>
		/// <param name="sect">The section letter.</param>
		/// <param name="lineNumber">The sequential line number.</param>
		public SectionLine(IDBAccess db, string locality, int parcel, int card, string sect, int lineNumber)
		{
			this.db = db;
			this.Locality = locality;
			this.Parcel = parcel;
			this.Card = card;
			this.Section = sect;
			this.LineNumber = lineNumber;
			this.populate();
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets or sets the Locality code.
		/// </summary>
		/// <remarks>A locality code must have a length of 3.  On a Set operation,
		/// if the length is anything other than 3 an <see cref="OverflowException"/>
		/// is thrown.</remarks>
		public string Locality
		{
			get
			{
				return this.locality;
			}

			set
			{
				if (value.Length == 3)
				{
					this.locality = value;
					this.fileNameLines = "native." + locality + "line";
				}
				else
				{
					throw new OverflowException("Value length invalid.  Length must be 3");
				}
			}
		}

		/// <summary>
		/// Gets the full file name for the database table.
		/// </summary>
		/// <remarks>Filename format is "%DataBase%.%Locality%section".</remarks>
		public string FileName
		{
			get
			{
				return this.fileNameLines;
			}
		}

		/// <summary>
		/// Gets or sets the current Parcel number.
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the Parcel property.</remarks>
		public int Parcel
		{
			get
			{
				return Convert.ToInt32(this.JLRECORD.Number);
			}

			set
			{
				if (this.JLRECORD.checkValue(value))
				{
					this.JLRECORD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Parcel number.\r\n" +
						"Must be between " + this.JLRECORD.MinValue.ToString() + " and " +
						this.JLRECORD.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the current Card number.
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the Card property.</remarks>
		public int Card
		{
			get
			{
				return Convert.ToInt32(this.JLDWELL.Number);
			}

			set
			{
				if (this.JLDWELL.checkValue(value))
				{
					this.JLDWELL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Card number.\r\n" +
						"Must be between " + this.JLDWELL.MinValue.ToString() + " and " +
						this.JLDWELL.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the current Section.
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the Section property.</remarks>
		public string Section
		{
			get
			{
				return this.JLSECT.Text;
			}

			set
			{
				if (this.JLSECT.checkValue(value))
				{
					this.JLSECT.Text = value;
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for Section.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the current sequential line number.
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the Card property.</remarks>
		public decimal LineNumber
		{
			get
			{
				return Convert.ToInt32(this.JLLINE.Number);
			}

			set
			{
				if (this.JLLINE.checkValue(value))
				{
					this.JLLINE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Line number.\r\n" +
						"Must be between " + this.JLLINE.MinValue.ToString() + " and " +
						this.JLLINE.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the current directional.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item>
		/// <description>N</description>
		/// </item>
		/// <item>
		/// <description>S</description>
		/// </item>
		/// <item>
		/// <description>E</description>
		/// </item>
		/// <item>
		/// <description>W</description>
		/// </item>
		/// <item>
		/// <description>NE</description>
		/// </item>
		/// <item>
		/// <description>NW</description>
		/// </item>
		/// <item>
		/// <description>SE</description>
		/// </item>
		/// <item>
		/// <description>SW</description>
		/// </item>
		/// </list>
		/// <para>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the Section property.</para></remarks>
		public string Directional
		{
			get
			{
				return this.JLDIRECT.Text;
			}

			set
			{
				if (this.JLDIRECT.checkValue(value))
				{
					this.JLDIRECT.Text = value;
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for Directional.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the Northing (X-Axis) length of the line in feet (1 decimal place).
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the XLength property.</remarks>
		public decimal XLength
		{
			get
			{
				return Convert.ToInt32(this.JLXLEN.Number);
			}

			set
			{
				if (this.JLXLEN.checkValue(value))
				{
					this.JLXLEN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Line number.\r\n" +
						"Must be between " + this.JLXLEN.MinValue.ToString() + " and " +
						this.JLXLEN.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the Easting (Y-Axis) length of the line in feet (1 decimal place).
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the YLength property.</remarks>
		public decimal YLength
		{
			get
			{
				return Convert.ToInt32(this.JLYLEN.Number);
			}

			set
			{
				if (this.JLYLEN.checkValue(value))
				{
					this.JLYLEN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Line number.\r\n" +
						"Must be between " + this.JLYLEN.MinValue.ToString() + " and " +
						this.JLYLEN.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the Length of the line in feet (1 decimal place).
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the LineLength property.</remarks>
		public decimal LineLength
		{
			get
			{
				return Convert.ToInt32(this.JLLINELEN.Number);
			}

			set
			{
				if (this.JLLINELEN.checkValue(value))
				{
					this.JLLINELEN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Line number.\r\n" +
						"Must be between " + this.JLLINELEN.MinValue.ToString() + " and " +
						this.JLLINELEN.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the Angle of the line (relative to 0).
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the LineAngle property.</remarks>
		public decimal LineAngle
		{
			get
			{
				return Convert.ToInt32(this.JLANGLE.Number);
			}

			set
			{
				if (this.JLANGLE.checkValue(value))
				{
					this.JLANGLE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Line number.\r\n" +
						"Must be between " + this.JLANGLE.MinValue.ToString() + " and " +
						this.JLANGLE.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the X Coordinate of the theoretical start point.
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the StartX property.</remarks>
		public decimal StartX
		{
			get
			{
				return Convert.ToInt32(this.JLPT1X.Number);
			}

			set
			{
				if (this.JLPT1X.checkValue(value))
				{
					this.JLPT1X.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Line number.\r\n" +
						"Must be between " + this.JLPT1X.MinValue.ToString() + " and " +
						this.JLPT1X.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the Y Coordinate of the theoretical start point.
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the StartY property.</remarks>
		public decimal StartY
		{
			get
			{
				return Convert.ToInt32(this.JLPT1Y.Number);
			}

			set
			{
				if (this.JLPT1Y.checkValue(value))
				{
					this.JLPT1Y.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Line number.\r\n" +
						"Must be between " + this.JLPT1Y.MinValue.ToString() + " and " +
						this.JLPT1Y.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the X Coordinate of the theoretical end point.
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the EndX property.</remarks>
		public decimal EndX
		{
			get
			{
				return Convert.ToInt32(this.JLPT2X.Number);
			}

			set
			{
				if (this.JLPT2X.checkValue(value))
				{
					this.JLPT2X.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Line number.\r\n" +
						"Must be between " + this.JLPT2X.MinValue.ToString() + " and " +
						this.JLPT2X.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the Y Coordinate of the theoretical end point.
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the EndY property.</remarks>
		public decimal EndY
		{
			get
			{
				return Convert.ToInt32(this.JLPT1Y.Number);
			}

			set
			{
				if (this.JLPT1Y.checkValue(value))
				{
					this.JLPT1Y.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for a Line number.\r\n" +
						"Must be between " + this.JLPT1Y.MinValue.ToString() + " and " +
						this.JLPT1Y.MaxValue.ToString());
				}
			}
		}

		/// <summary>
		/// Gets or sets the initial theoretical point in space of the start of the line.
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the either the X or Y value is outside
		/// acceptable bounds.</remarks>
		public PointF StartPointF
		{
			get
			{
				return new PointF(Convert.ToSingle(this.StartX), Convert.ToSingle(this.StartY));
			}

			set
			{
				this.StartX = Convert.ToDecimal(value.X);
				this.StartY = Convert.ToDecimal(value.Y);
			}
		}

		/// <summary>
		/// Gets or sets the initial theoretical point in space of the end of the line.
		/// </summary>
		/// <remarks>Throws an <see cref="OverflowException"/> if the either the X or Y value is outside
		/// acceptable bounds.</remarks>
		public PointF EndPointF
		{
			get
			{
				return new PointF(Convert.ToSingle(this.EndX), Convert.ToSingle(this.EndY));
			}

			set
			{
				this.EndX = Convert.ToDecimal(value.X);
				this.EndY = Convert.ToDecimal(value.Y);
			}
		}

		/// <summary>
		/// Gets or sets the section letter (if any) attached at the end of this line.
		/// </summary>
		/// <remarks>
		/// <para>The ending of this line serves as relative (0,0) for the start of the
		/// attached section.</para>
		/// <para>Throws an <see cref="OverflowException"/> if the value is outside the established
		/// bounds of the Section property.</para></remarks>
		public string Attachment
		{
			get
			{
				return this.JLATTACH.Text;
			}

			set
			{
				if (this.JLATTACH.checkValue(value))
				{
					this.JLATTACH.Text = value;
				}
				else
				{
					throw new OverflowException("Value outside the established bounds for Attachment.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the IDBAccess object.
		/// </summary>
		public IDBAccess DBAccessObject
		{
			get
			{
				return this.db;
			}

			set
			{
				this.db = value;
			}
		}

		#endregion Properties

		#region Public Methods

		/// <summary>
		/// Populates the instance properties with data from the database table based on the
		/// current Locality, Parcel, Card, Section, and LineNumber settings.
		/// </summary>
		public void populate()
		{
			this.getSectionLineData();
		}

		#endregion Public Methods

		#region Private Methods

		private bool getSectionLineData()
		{
			bool isOK = false;

			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("select * from " + this.fileNameLines);
				sb.Append(" where JLRECORD = " + this.JLRECORD.ToString());
				sb.Append(" and JLDWELL = " + this.JLDWELL.ToString());
				sb.Append(" and JLSECT = '" + this.JLSECT.Text + "'");
				sb.Append(" and JLLINE# = " + this.JLLINE.ToString());

				rs = this.db.RunSelectStatement(sb.ToString());
				dt = rs.Tables[0];
				dr = dt.Rows[0];
				this.JLDIRECT.Text = (string)dr["JLDIRECT"];
				this.JLXLEN.setValue(dr["JLXLEN"].ToString());
				this.JLYLEN.setValue(dr["JLYLEN"].ToString());
				this.JLLINELEN.setValue(dr["JLLINELEN"].ToString());
				this.JLANGLE.setValue(dr["JLANGLE"].ToString());
				this.JLPT1X.setValue(dr["JLPT1X"].ToString());
				this.JLPT1Y.setValue(dr["JLPT1Y"].ToString());
				this.JLPT2X.setValue(dr["JLPT2X"].ToString());
				this.JLPT2Y.setValue(dr["JLPT2Y"].ToString());
				this.JLATTACH.Text = (string)dr["JLATTACH"];

				isOK = true;
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(string.Format("{0}", ex.Message));
#if DEBUG
				Debug.WriteLine(string.Format("Error occurred in {0}, in procedure {1}.", MethodBase.GetCurrentMethod().Module, MethodBase.GetCurrentMethod().Name));
				Debug.WriteLine(string.Format("{0}", ex.Message));
				Logger.Error(ex, MethodBase.GetCurrentMethod().Name); 
#endif
				throw;
			}
			return isOK;
		}

		#endregion Private Methods
	}
}