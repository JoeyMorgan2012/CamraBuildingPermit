using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	public class Rat1Master
	{
		public enum Rat1Types
		{
			CommercialSection = 0,      // 'C'
			Homesite,                   // 'H'
			Improvement,                // 'I'
			Land,                       // 'L'
			ResidentialSection,         // 'P'
			Subdivision,                // 'D'
			UserCode,                   // 'U'
			MagisterialCode,            // 'M'
			LandUseCode,                // 'E'
			AssessorCode,               // 'B'
			SiteCode                    // 'S'
		}

		private DBAccessManager _db;
		private CAMRA_Connection _conn;
		private string _rat1_filename;
		private SortedList<Rat1Types, SortedList<string, Rat1Type>> AllTypesList = new SortedList<Rat1Types, SortedList<string, Rat1Type>>();
		private decimal SINGLEWIDE_RATE = 0;
		private decimal DOUBLEWIDE_RATE = 0;

		private Rat1Master()
		{
		}

		public Rat1Master(CAMRA_Connection conn)
		{
			_conn = conn;

			//_db = new DBAccessManager(DBAccessManager.DatabaseTypes.iSeriesDB2,
			//    _conn.DataSource, null, _conn.User, _conn.Password, null);
			_db = _conn.DBConnection;
			_rat1_filename = _conn.Library + "." + _conn.LocalityPrefix + "RAT1";
			this.Populate();
		}

		public Rat1Master Clone()
		{
			Rat1Master rat1 = new Rat1Master();
			rat1._conn = _conn;
			rat1._db = _db;
			rat1._rat1_filename = _rat1_filename;
			rat1.AllTypesList = AllTypesList;
			rat1.SINGLEWIDE_RATE = SINGLEWIDE_RATE;
			rat1.DOUBLEWIDE_RATE = DOUBLEWIDE_RATE;
			return rat1;
		}

		public decimal SingleWideRate
		{
			get
			{
				return this.SINGLEWIDE_RATE;
			}
		}

		public decimal DoubleWideRate
		{
			get
			{
				return this.DOUBLEWIDE_RATE;
			}
		}

		public SortedList<string, Rat1Type> GetRat1TypeCollection(Rat1Types type)
		{
			return this.AllTypesList[type];
		}

		public List<string> GetRat1TypeCollectionDescriptionList(Rat1Types type)
		{
			return this.GetRat1TypeCollectionDescriptionList(type, false);
		}

		public List<string> GetRat1TypeCollectionDescriptionList(Rat1Types type, bool includeCode)
		{
			SortedList<string, Rat1Type> l = this.AllTypesList[type];

			SortedList<string, string> output = new SortedList<string, string>();
			foreach (Rat1Type s in l.Values)
			{
				if (!output.ContainsKey(s.Description))
				{
					string description = s.Description;

					if (includeCode && !"(NOT ASSIGNED)".Equals(s.Description))
					{
						string code = String.Empty;
						if (type == Rat1Types.UserCode && s.ElemCode.Length == 4)
						{
							code = s.ElemCode.Substring(3, 1);
						}
						else
						{
							code = s.ElemCode;
						}
						code += ":";
						description = code + description;
					}

					output.Add(description, s.ElemCode);
				}
			}

			List<string> retList = new List<string>();
			foreach (string str in output.Keys)
			{
				retList.Add(str);
			}

			return retList;
		}

		public List<string> GetRat1TypeCollectionCodeList(Rat1Types type)
		{
			SortedList<string, Rat1Type> l = this.AllTypesList[type];

			SortedList<string, string> output = new SortedList<string, string>();
			foreach (Rat1Type s in l.Values)
			{
				output.Add(s.ElemCode, s.Description);
			}

			List<string> retList = new List<string>();
			foreach (string str in output.Keys)
			{
				retList.Add(str);
			}

			return retList;
		}

		/// <summary>
		/// Gets the collection of Rates.  Only functional for Homesite codes.
		/// </summary>
		/// <param name="type">Rat1Types.Homesite</param>
		/// <returns>A List of Rates in numeric order.</returns>
		public List<decimal> GetRat1TypeCollectionRateList(Rat1Types type)
		{
			List<decimal> retList = new List<decimal>();

			if (type == Rat1Types.Homesite)
			{
				SortedList<string, Rat1Type> l = this.AllTypesList[type];

				SortedList<decimal, string> output = new SortedList<decimal, string>();
				foreach (Rat1Type s in l.Values)
				{
					if (!output.ContainsKey(s.Rate))
					{
						output.Add(s.Rate, s.ElemCode);
					}
				}

				foreach (decimal dec in output.Keys)
				{
					retList.Add(dec);
				}
			}

			return retList;
		}

		public Rat1Type GetRat1Type(Rat1Types type, string code)
		{
			SortedList<string, Rat1Type> rat1Type = this.AllTypesList[type];
			Rat1Type typeO = null;
			if (rat1Type.ContainsKey(code))
			{
				typeO = rat1Type[code];
			}
			return typeO;
		}

		public string GetRat1Description(Rat1Types type, string elemcode)
		{
			return this.GetRat1Description(type, elemcode, false);
		}

		public string GetRat1Description(Rat1Types type, string elemcode, bool containsCode)
		{
			SortedList<string, Rat1Type> rat1Type = this.AllTypesList[type];
			string desc = null;
			if (rat1Type.ContainsKey(elemcode))
			{
				desc = rat1Type[elemcode].Description;
			}

			if (containsCode)
			{
				string code = String.Empty;
				if (type == Rat1Types.UserCode)
				{
					if (elemcode.Length == 4)
					{
						code = elemcode.Substring(3);
					}
				}
				else
				{
					code = elemcode;
				}
				code = code + ":";
				desc = code + desc;
			}

			return desc;
		}

		public string GetRat1Code(Rat1Types type, string description)
		{
			return this.GetRat1Code(type, description, false);
		}

		public string GetRat1Code(Rat1Types type, string description, bool containsCode)
		{
			SortedList<string, Rat1Type> rat1Type = this.AllTypesList[type];
			description = description.ToUpper();
			string code = null;

			foreach (Rat1Type s in rat1Type.Values)
			{
				if (containsCode)
				{
					try
					{
						int colonPos = description.IndexOf(":");
						if (colonPos >= 0 && colonPos <= 5)
						{
							description = description.Substring(colonPos + 1);
						}
					}
					catch (System.Exception ex)
					{
						Console.WriteLine(string.Format("{0}", ex.Message));
					}
				}

				if (description.Equals(s.Description))
				{
					code = s.ElemCode;
					break;
				}
			}

			return code;
		}

		public string GetRat1CodeFromRate(Rat1Types type, decimal rate)
		{
			SortedList<string, Rat1Type> rat1Type = this.AllTypesList[type];
			string code = null;

			foreach (Rat1Type s in rat1Type.Values)
			{
				if (rate.Equals(s.Rate))
				{
					code = s.ElemCode;
					break;
				}
			}

			return code;
		}

		public decimal GetRat1Rate(Rat1Types type, string elemcode)
		{
			SortedList<string, Rat1Type> rat1Type = this.AllTypesList[type];
			decimal rate = 0M;
			if (rat1Type.ContainsKey(elemcode))
			{
				rate = rat1Type[elemcode].Rate;
			}
			return rate;
		}

		private void Populate()
		{
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * from ");
			sql.Append(_rat1_filename);
			try
			{
				IDataReader reader = _db.getDataReader(sql.ToString());
				using (reader)
				{
					int ord_rid = reader.GetOrdinal("rid");
					int ord_rsecto = reader.GetOrdinal("rsecto");
					int ord_rdesc = reader.GetOrdinal("rdesc");
					int ord_rrpa = reader.GetOrdinal("rrpa");
					int ord_rrpsf = reader.GetOrdinal("rrpsf");
					int ord_rincsf = reader.GetOrdinal("rincsf");

					// CommercialSection
					SortedList<string, Rat1Type> comm = new SortedList<string, Rat1Type>();

					//comm.Add("", new Rat1Type(Rat1Types.CommercialSection, "", "(NOT ASSIGNED)"));
					// Homesite
					SortedList<string, Rat1Type> hs = new SortedList<string, Rat1Type>();

					//hs.Add("", new Rat1Type(Rat1Types.Homesite, "", "(NOT ASSIGNED)"));
					// Improvement
					SortedList<string, Rat1Type> impr = new SortedList<string, Rat1Type>();

					//impr.Add("", new Rat1Type(Rat1Types.Improvement, "", "(NOT ASSIGNED)"));
					// Land
					SortedList<string, Rat1Type> land = new SortedList<string, Rat1Type>();

					//land.Add("", new Rat1Type(Rat1Types.Land, "", "(NOT ASSIGNED)"));
					// ResidentialSection
					SortedList<string, Rat1Type> res = new SortedList<string, Rat1Type>();

					//res.Add("", new Rat1Type(Rat1Types.ResidentialSection, "", "(NOT ASSIGNED)"));
					// Subdivision
					SortedList<string, Rat1Type> sub = new SortedList<string, Rat1Type>();

					//sub.Add("", new SubdivisionRat1Type(Rat1Types.Subdivision, "", "(NOT ASSIGNED)", 0, String.Empty));
					// UserCode
					SortedList<string, Rat1Type> user = new SortedList<string, Rat1Type>();

					//user.Add("", new Rat1Type(Rat1Types.UserCode, "", "(NOT ASSIGNED)"));
					// MagisterialCode
					SortedList<string, Rat1Type> mag = new SortedList<string, Rat1Type>();

					//mag.Add("", new Rat1Type(Rat1Types.MagisterialCode, "", "(NOT ASSIGNED)"));

					// MagisterialCode
					SortedList<string, Rat1Type> landuse = new SortedList<string, Rat1Type>();

					// MagisterialCode
					SortedList<string, Rat1Type> ass = new SortedList<string, Rat1Type>();

					// SiteCode
					SortedList<string, Rat1Type> site = new SortedList<string, Rat1Type>();

					while (reader.Read())
					{
						string rid = reader.GetString(ord_rid);
						string rsecto = reader.GetString(ord_rsecto);
						string rdesc = reader.GetString(ord_rdesc).Trim();
						decimal rrpa = reader.GetDecimal(ord_rrpa);
						decimal rrpsf = reader.GetDecimal(ord_rrpsf);
						string rincsf = reader.GetString(ord_rincsf);

						switch (rid)
						{
							// CommercialSection
							case "C":
								comm.Add(rsecto, new Rat1Type(Rat1Types.CommercialSection, rsecto, rdesc));
								break;

							// Homesite
							case "H":
								hs.Add(rsecto.Substring(1), new Rat1Type(Rat1Types.Homesite, rsecto, rdesc, rrpa));
								break;

							// Improvement
							case "I":
								impr.Add(rsecto, new Rat1Type(Rat1Types.Improvement, rsecto, rdesc));
								break;

							// Land
							case "L":
								land.Add(rsecto.Substring(1), new Rat1Type(Rat1Types.Land, rsecto, rdesc));
								break;

							// Site
							case "S":
								site.Add(rsecto.Substring(1), new Rat1Type(Rat1Types.SiteCode, rsecto, rdesc, rrpa));
								break;

							// ResidentialSection
							case "P":
								res.Add(rsecto, new Rat1Type(Rat1Types.ResidentialSection, rsecto, rdesc));
								if ("SWMH".Equals(rsecto.Trim()))
								{
									this.SINGLEWIDE_RATE = rrpsf;
								}
								else if ("DWMH".Equals(rsecto.Trim()))
								{
									this.DOUBLEWIDE_RATE = rrpsf;
								}
								break;

							// Subdivision
							case "D":
								sub.Add(rsecto.Substring(1), new SubdivisionRat1Type(Rat1Types.Subdivision, rsecto, rdesc, rrpsf, rincsf));
								break;

							// UserCode
							case "U":
								user.Add(rsecto.Substring(1), new Rat1Type(Rat1Types.UserCode, rsecto, rdesc));
								break;

							// MagisterialCode
							case "M":
								mag.Add(rsecto.Substring(0, 2), new Rat1Type(Rat1Types.MagisterialCode, rsecto.Substring(0, 2), rdesc));
								break;

							// LandUseCode
							case "E":
								landuse.Add(rsecto, new Rat1Type(Rat1Types.UserCode, rsecto, rdesc));
								break;

							// UserCode
							case "B":
								ass.Add(rsecto, new Rat1Type(Rat1Types.UserCode, rsecto, rdesc));
								break;

							default:
								break;
						}
					}
					reader.Close();

					// CommercialSection
					this.AllTypesList.Add(Rat1Types.CommercialSection, comm);

					// Homesite
					this.AllTypesList.Add(Rat1Types.Homesite, hs);

					// Improvement
					this.AllTypesList.Add(Rat1Types.Improvement, impr);

					// Land
					this.AllTypesList.Add(Rat1Types.Land, land);

					// ResidentialSection
					this.AllTypesList.Add(Rat1Types.ResidentialSection, res);

					// Subdivision
					this.AllTypesList.Add(Rat1Types.Subdivision, sub);

					// UserCode
					if (!user.Keys.Contains("USR9"))
					{
						user.Add("USR9", new Rat1Type(Rat1Types.UserCode, "USR9", "911 ADDRESS CHANGED"));
					}
					if (!user.Keys.Contains("."))
					{
						user.Add("USR.", new Rat1Type(Rat1Types.UserCode, "USR.", "REMARKS REMOVED"));
					}
					this.AllTypesList.Add(Rat1Types.UserCode, user);

					// MagisterialCode
					this.AllTypesList.Add(Rat1Types.MagisterialCode, mag);

					// LandUseCode
					this.AllTypesList.Add(Rat1Types.LandUseCode, landuse);

					// MagisterialCode
					this.AllTypesList.Add(Rat1Types.AssessorCode, ass);

					// SiteCodes
					this.AllTypesList.Add(Rat1Types.SiteCode, site);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
			}
		}
	}

	public class Rat1Type
	{
		private Rat1Master.Rat1Types type;
		private string elemcode;
		private string description;
		private decimal rate = 0M;

		private Rat1Type()
		{
		}

		public Rat1Type(Rat1Master.Rat1Types type, string elemcode, string description)
		{
			this.type = type;
			this.elemcode = elemcode;
			this.description = description;
		}

		public Rat1Type(Rat1Master.Rat1Types type, string elemcode, string description, decimal rate)
			: this(type, elemcode, description)
		{
			this.rate = rate;
		}

		public string ElemCode
		{
			get
			{
				return this.elemcode;
			}
		}

		public string Description
		{
			get
			{
				return this.description;
			}
		}

		public decimal Rate
		{
			get
			{
				return this.rate;
			}
		}

		public Rat1Master.Rat1Types Type
		{
			get
			{
				return this.type;
			}
		}

		public string RID
		{
			get
			{
				string s = null;

				switch (this.type)
				{
					case Rat1Master.Rat1Types.CommercialSection:
						s = "C";
						break;

					case Rat1Master.Rat1Types.Homesite:
						s = "H";
						break;

					case Rat1Master.Rat1Types.Improvement:
						s = "I";
						break;

					case Rat1Master.Rat1Types.Land:
						s = "L";
						break;

					case Rat1Master.Rat1Types.ResidentialSection:
						s = "P";
						break;

					case Rat1Master.Rat1Types.UserCode:
						s = "U";
						break;

					case Rat1Master.Rat1Types.SiteCode:
						s = "S";
						break;

					default:
						break;
				}

				return s;
			}
		}
	}

	public class SubdivisionRat1Type : Rat1Type
	{
		public SubdivisionRat1Type(Rat1Master.Rat1Types type, string elemcode, string description, decimal qualityFactor, string qualityCode)
			: base(type, elemcode, description)
		{
			QualityFactor = qualityFactor;
			QualityCode = qualityCode;
		}

		public decimal QualityFactor
		{
			get; internal set;
		}

		public string QualityCode
		{
			get; internal set;
		}
	}
}