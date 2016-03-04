using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	public class Rat2Master
	{
		private DBAccessManager _db;
		private string neighborhood;
		private string _rat2_filename;
		private string rsect2 = String.Empty;
		private decimal rdca = 0M;
		private decimal rdcb = 0M;
		private decimal rdcc = 0M;
		private decimal rdcd = 0M;
		private decimal rdce = 0M;
		private decimal rdcm = 0M;
		private SortedList<string, decimal> classPercentages;
		private int ryear = 0;
		private bool rmhrnd = true;
		private decimal rmhmin = 0M;
		private decimal racamt = 0M;
		private decimal rfinbs = 0M;

		public int rstdpc
		{
			get; set;
		}

		public int rstdpr
		{
			get; set;
		}

		private Rat2Master()
		{
		}

		public Rat2Master(DBAccessManager db, string Rat2FileName, string neighborhood)
			: this()
		{
			_db = db;
			this.neighborhood = neighborhood;
			_rat2_filename = Rat2FileName;
			this.Populate();
		}

		public Rat2Master(DBAccessManager db, decimal neighborhood)
		{
			_db = db;
			this.neighborhood = Utils.FillLeadingZeroes(Convert.ToInt32(neighborhood), 4);
			this.Populate();
		}

		public Rat2Master Clone()
		{
			Rat2Master rat2 = new Rat2Master();
			rat2._db = _db;
			rat2.neighborhood = neighborhood;
			rat2._rat2_filename = _rat2_filename;
			rat2.rsect2 = rsect2;
			rat2.rdca = rdca;
			rat2.rdcb = rdcb;
			rat2.rdcc = rdcc;
			rat2.rdcd = rdcd;
			rat2.rdce = rdce;
			rat2.rdcm = rdcm;
			rat2.classPercentages = classPercentages;
			rat2.ryear = ryear;
			rat2.rmhrnd = rmhrnd;
			rat2.rmhmin = rmhmin;
			rat2.racamt = racamt;
			rat2.rfinbs = rfinbs;
			rat2.rstdpc = rstdpc;
			rat2.rstdpr = rstdpr;
			return rat2;
		}

		public decimal GetClassCodePercentage(string classCode)
		{
			if (this.classPercentages.ContainsKey(classCode))
			{
				return this.classPercentages[classCode];
			}
			else
			{
				throw new KeyNotFoundException();
			}
		}

		public int GetClassCodePercentageAsInteger(string classCode)
		{
			decimal percentage = 0M;
			try
			{
				percentage = this.GetClassCodePercentage(classCode);
			}
			catch (KeyNotFoundException kex)
			{
				Console.WriteLine(string.Format("{0}", kex.Message));
			}
			percentage *= 100M;
			int per = Convert.ToInt32(percentage);
			return per;
		}

		public int TaxYear
		{
			get
			{
				return this.ryear;
			}
		}

		public bool RoundManufacturedHousingValues
		{
			get
			{
				return this.rmhrnd;
			}
		}

		public decimal AcRate
		{
			get
			{
				return this.racamt;
			}
		}

		public decimal FinishedBasementRate
		{
			get
			{
				return this.rfinbs;
			}
		}

		public decimal ManufacturedHousingMinumumValue
		{
			get
			{
				return this.rmhmin;
			}
		}

		public string GetClassCodeFromFactorPercentage(decimal percentage)
		{
			if (this.classPercentages.ContainsValue(percentage))
			{
				return this.classPercentages.Keys[this.classPercentages.IndexOfValue(percentage)];
			}
			else
			{
				throw new KeyNotFoundException();
			}
		}

		public string GetClassCodeFromFactorPercentageAsInteger(int factor)
		{
			decimal percentage = Convert.ToDecimal(factor);
			percentage *= .01M;
			return this.GetClassCodeFromFactorPercentage(percentage);
		}

		private void Populate()
		{
			try
			{
				DataSet ds = _db.RunSelectStatement("Select * from " + _rat2_filename + " where rsect2 = '" + neighborhood + "'");
				DataTable dt = ds.Tables[0];
				if (dt.Rows.Count == 0)
				{
					throw new Exception("No row found in " + _rat2_filename + " for Neighborhood " + neighborhood);
				}
				else
				{
					DataRow dr = dt.Rows[0];
					this.rsect2 = dr["rsect2"].ToString().Trim();
					this.rdca = decimal.Parse(dr["rdca"].ToString());
					this.rdcb = decimal.Parse(dr["rdcb"].ToString());
					this.rdcc = decimal.Parse(dr["rdcc"].ToString());
					this.rdcd = decimal.Parse(dr["rdcd"].ToString());
					this.rdce = decimal.Parse(dr["rdce"].ToString());
					this.rdcm = decimal.Parse(dr["rdcm"].ToString());

					string rdate = dr["rdate"].ToString();
					this.ryear = 0;
					int ryearStart = rdate.Length - 4;
					string ryearString = string.Empty;
					if (ryearStart > -1)
					{
						ryearString = rdate.Substring(ryearStart);
					}
					if (!"".Equals(ryearString))
					{
						ryear = int.Parse(ryearString);
					}

					this.rmhmin = decimal.Parse(dr["rmhmin"].ToString());
					this.racamt = decimal.Parse(dr["racamt"].ToString());
					string rnd = dr["rmhrnd"].ToString().Trim();
					this.rmhrnd = ("Y".Equals(rnd));
					this.rfinbs = decimal.Parse(dr["rfinbs"].ToString());
					this.rstdpc = int.Parse(dr["rstdpc"].ToString());
					this.rstdpr = int.Parse(dr["rstdpr"].ToString());

					this.classPercentages = new SortedList<string, decimal>();
					this.classPercentages.Add("A", this.rdca);
					this.classPercentages.Add("B", this.rdcb);
					this.classPercentages.Add("C", this.rdcc);
					this.classPercentages.Add("D", this.rdcd);
					this.classPercentages.Add("E", this.rdce);
					this.classPercentages.Add("M", this.rdcm);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
			}
		}
	}

	public class Rat2Collection
	{
		private SortedList<string, Rat2Master> collection;
		private DBAccessManager _db;
		private CAMRA_Connection _conn;
		private string _rat2_filename;

		private Rat2Collection()
		{
			this.collection = new SortedList<string, Rat2Master>();
		}

		public Rat2Collection(CAMRA_Connection conn)
			: this()
		{
			_conn = conn;

			//_db = new DBAccessManager(DBAccessManager.DatabaseTypes.iSeriesDB2,
			//    _conn.DataSource, null, _conn.User, _conn.Password, null);
			_db = _conn.DBConnection;
			_rat2_filename = _conn.Library + "." + _conn.LocalityPrefix + "RAT2";
			this.Populate();
		}

		private void Populate()
		{
			try
			{
				DataSet ds = _db.RunSelectStatement("Select rsect2 from " + _rat2_filename + " order by rsect2");
				DataTable dt = ds.Tables[0];
				if (dt.Rows.Count == 0)
				{
					throw new Exception("No rows found in " + _rat2_filename);
				}
				else
				{
					foreach (DataRow dr in dt.Rows)
					{
						string rsect2 = dr["rsect2"].ToString();
						Rat2Master rat2 = new Rat2Master(_db, _rat2_filename, rsect2);
						this.collection.Add(rsect2, rat2);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
			}
			finally
			{
			}
		}

		public SortedList<string, Rat2Master> Collection
		{
			get
			{
				return this.collection;
			}
		}

		public Rat2Master GetRat2Master(string neighborhood)
		{
			if (this.collection.ContainsKey(neighborhood))
			{
				return this.collection[neighborhood];
			}
			else
			{
				throw new KeyNotFoundException();
			}
		}
	}
}