using System;
using System.Collections.Generic;
using System.Data;

namespace SWallTech
{
	public class Locality
	{
		private DBAccessManager _db;

		public string Prefix
		{
			get; set;
		}

		public string ShortDescription
		{
			get; set;
		}

		public string LongDescription
		{
			get; set;
		}

		public string Library
		{
			get; set;
		}

		public string ExtendedText
		{
			get
			{
				return string.Format("{0} - {1}", Prefix, LongDescription);
			}
		}

		public string Status
		{
			get; set;
		}

		public MapConfig MapConfig
		{
			get; set;
		}

		public List<string> BatchFiles
		{
			get; set;
		}

		public Locality(DBAccessManager db)
		{
			_db = db;
		}

		public void GetMapConfig()
		{
			try
			{
				MapConfig = new MapConfig(_db, Library, Prefix);
			}
			catch (Exception)
			{
			}
		}

		private const string batchSqlFormat =
			"select NAME from sysibm.sqltables where table00001 = '{0}' and name like '{1}BT%' order by NAME";

		public void GetBatchList()
		{
			BatchFiles = new List<string>();
			try
			{
				string sql = String.Format(batchSqlFormat, Library, Prefix);
				IDataReader batchReader = this._db.getDataReader(sql);
				int NAME_ord = batchReader.GetOrdinal("NAME");
				while (batchReader.Read())
				{
					string file = batchReader.GetString(NAME_ord).Trim();
					if (file.Length == 7)
					{
						BatchFiles.Add(file.Substring(5, 2));
					}
				}
				batchReader.Close();
			}
			catch (Exception)
			{
				// V5R1 error - SYSIBM may not exist
			}
		}
	}
}