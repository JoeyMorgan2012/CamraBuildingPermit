using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	public partial class StabMaster
	{
		public enum StabTypes
		{
			BasementType = 0,       // BAS
			CarportType,            // CAR
			Characteristic,         // CHR
			Class,                  // CLS
			Condition,              // CON
			Easement,               // EAS
			ExteriorWall,           // EXW
			FloorType,              // FLR
			Foundation,             // FND
			Fuel,                   // FUL
			GarageType,             // GAR
			Heat,                   // HT
			InteriorWall,           // INW
			Occupancy,              // OCC
			RightOfWay,             // ROW
			RoofingMaterial,        // RFG
			RoofingType,            // RFT
			Sewer,                  // SEW
			Terrain,                // TER
			Water                   // WAT
		}

		private DBAccessManager _db;
		private CAMRA_Connection _conn;
		private string _stab_filename;
		private SortedList<StabTypes, SortedList<string, StabType>> AllTypesList = new SortedList<StabTypes, SortedList<string, StabType>>();

		public StabMaster()
		{
		}

		//TODO: Change to locality version and library
		public StabMaster(CAMRA_Connection conn, bool populateLists = true)
		{
			_conn = conn;

			//_db = new DBAccessManager(DBAccessManager.DatabaseTypes.iSeriesDB2,
			//    _conn.DataSource, null, _conn.User, _conn.Password, null);
			_db = _conn.DBConnection;
			_stab_filename = string.Format(@"{0}.{1}STAB", _conn.Library, _conn.LocalityPrefix);
			if (populateLists)
			{
				this.Populate();
			}
		}

		public StabMaster Clone()
		{
			StabMaster stab = new StabMaster();
			stab._conn = _conn;
			stab._db = _db;
			stab._stab_filename = _stab_filename;
			stab.AllTypesList = AllTypesList;
			return stab;
		}

		public SortedList<string, StabType> GetStabTypeCollection(StabTypes type)
		{
			return this.AllTypesList[type];
		}

		public List<string> GetStabTypeCollectionDescriptionList(StabTypes type)
		{
			SortedList<string, StabType> l = this.AllTypesList[type];

			SortedList<string, string> output = new SortedList<string, string>();
			foreach (StabType s in l.Values)
			{
				if (!output.ContainsKey(s.Description))
				{
					output.Add(s.Description, s.ElemCode);
				}
			}

			List<string> retList = new List<string>();
			foreach (string str in output.Keys)
			{
				retList.Add(str);
			}

			return retList;
		}

		public List<string> GetStabTypeCollectionCodeList(StabTypes type)
		{
			SortedList<string, StabType> l = this.AllTypesList[type];

			SortedList<string, string> output = new SortedList<string, string>();
			foreach (StabType s in l.Values)
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

		public StabType GetStabType(StabTypes type, string code)
		{
			SortedList<string, StabType> stabType = this.AllTypesList[type];
			StabType typeO = null;
			if (stabType.ContainsKey(code))
			{
				typeO = stabType[code];
			}
			return typeO;
		}

		public string GetStabDescription(StabTypes type, string elemcode)
		{
			SortedList<string, StabType> stabType = this.AllTypesList[type];
			string desc = null;
			if (stabType.ContainsKey(elemcode))
			{
				desc = stabType[elemcode].Description;
			}
			return desc;
		}

		public string GetStabCode(StabTypes type, string description)
		{
			SortedList<string, StabType> stabType = this.AllTypesList[type];
			description = description.ToUpper();
			string code = null;

			foreach (StabType s in stabType.Values)
			{
				if (description.Equals(s.Description))
				{
					code = s.ElemCode;
					break;
				}
			}

			return code;
		}

		private void Populate()
		{
			StringBuilder sql = new StringBuilder();
			sql.Append("Select * from ");
			sql.Append(_stab_filename);

			//where ttid in ('BAS','CAR','CHR','CLS','CON','EAS'," +
			//    "'EXW','FLR','FND','FUL','GAR','HT','INW','OCC','ROW','RFG','RFT','SEW','TER','WAT')";

			try
			{
				IDataReader reader = _db.getDataReader(sql.ToString());
				using (reader)
				{
					int ord_ttid = reader.GetOrdinal("ttid");
					int ord_ttelem = reader.GetOrdinal("ttelem");
					int ord_tdescp = reader.GetOrdinal("tdescp");
					int ord_texwal = reader.GetOrdinal("texwal");

					// BasementType
					SortedList<string, StabType> basements = new SortedList<string, StabType>();
					basements.Add("0", new StabType(StabTypes.BasementType, "0", "(NOT ASSIGNED)"));

					// CarportType
					SortedList<string, StabType> carports = new SortedList<string, StabType>();
					carports.Add("0", new StabType(StabTypes.CarportType, "0", "(NOT ASSIGNED)"));

					// Characteristic
					SortedList<string, StabType> characters = new SortedList<string, StabType>();
					characters.Add(" ", new StabType(StabTypes.Characteristic, " ", "(NOT ASSIGNED)"));

					// Class
					SortedList<string, StabType> classes = new SortedList<string, StabType>();
					classes.Add(" ", new StabType(StabTypes.Class, " ", "(NOT ASSIGNED)"));

					// Condition
					SortedList<string, StabType> conditions = new SortedList<string, StabType>();
					conditions.Add(" ", new StabType(StabTypes.Condition, " ", "(NOT ASSIGNED)"));

					// Easement
					SortedList<string, StabType> easements = new SortedList<string, StabType>();
					easements.Add("0", new StabType(StabTypes.Easement, "0", "(NOT ASSIGNED)"));

					// ExteriorWall
					SortedList<string, StabType> extWalls = new SortedList<string, StabType>();
					extWalls.Add("0", new StabType(StabTypes.ExteriorWall, "0", "(NOT ASSIGNED)"));

					// FloorType
					SortedList<string, StabType> floors = new SortedList<string, StabType>();
					floors.Add("  ", new StabType(StabTypes.FloorType, "  ", "(NOT ASSIGNED)"));

					// Foundation
					SortedList<string, StabType> foundations = new SortedList<string, StabType>();
					foundations.Add("0", new StabType(StabTypes.Foundation, "0", "(NOT ASSIGNED)"));

					// Fuel
					SortedList<string, StabType> fuels = new SortedList<string, StabType>();
					fuels.Add("0", new StabType(StabTypes.Fuel, "0", "(NOT ASSIGNED)"));

					// GarageType
					SortedList<string, StabType> garages = new SortedList<string, StabType>();
					garages.Add("0", new StabType(StabTypes.GarageType, "0", "(NOT ASSIGNED)"));

					// Heat
					SortedList<string, StabType> heats = new SortedList<string, StabType>();
					heats.Add("0", new StabType(StabTypes.Heat, "0", "(NOT ASSIGNED)"));

					// InteriorWall
					SortedList<string, StabType> intWalls = new SortedList<string, StabType>();
					intWalls.Add("  ", new StabType(StabTypes.InteriorWall, "  ", "(NOT ASSIGNED)"));

					// Occupancy
					SortedList<string, StabType> occups = new SortedList<string, StabType>();
					occups.Add(" ", new StabType(StabTypes.Occupancy, " ", "(NOT ASSIGNED)"));

					// RightOfWay
					SortedList<string, StabType> rows = new SortedList<string, StabType>();
					rows.Add("0", new StabType(StabTypes.RightOfWay, "0", "(NOT ASSIGNED)"));

					// RoofingMaterial
					SortedList<string, StabType> roofMats = new SortedList<string, StabType>();
					roofMats.Add("0", new StabType(StabTypes.RoofingMaterial, "0", "(NOT ASSIGNED)"));

					// RoofingType
					SortedList<string, StabType> roofTypes = new SortedList<string, StabType>();
					roofTypes.Add("0", new StabType(StabTypes.RoofingType, "0", "(NOT ASSIGNED)"));

					// Sewer
					SortedList<string, StabType> sewers = new SortedList<string, StabType>();
					sewers.Add("0", new StabType(StabTypes.Sewer, "0", "(NOT ASSIGNED)"));

					// Terrain
					SortedList<string, StabType> terrains = new SortedList<string, StabType>();
					terrains.Add("0", new StabType(StabTypes.Terrain, "0", "(NOT ASSIGNED)"));

					// Water
					SortedList<string, StabType> waters = new SortedList<string, StabType>();
					waters.Add("0", new StabType(StabTypes.Water, "0", "(NOT ASSIGNED)"));

					while (reader.Read())
					{
						string ttid = reader.GetString(ord_ttid).Trim();
						string ttelem = reader.GetString(ord_ttelem).Trim();
						if (ttelem.Substring(0, 1).Equals("0"))
						{
							ttelem = ttelem.Substring(1);
						}

						string tdescp = reader.GetString(ord_tdescp).Trim();
						string texwal = reader.GetString(ord_texwal);

						switch (ttid)
						{
							// BasementType
							case "BAS":
								basements.Add(ttelem, new StabType(StabTypes.BasementType, ttelem, tdescp));
								break;

							// CarportType
							case "CAR":
								carports.Add(ttelem, new StabType(StabTypes.CarportType, ttelem, tdescp));
								break;

							// Characteristic
							case "CHR":
								characters.Add(ttelem, new StabType(StabTypes.Characteristic, ttelem, tdescp));
								break;

							// Class
							case "CLS":
								classes.Add(ttelem, new StabType(StabTypes.Class, ttelem, tdescp));
								break;

							// Condition
							case "CON":
								conditions.Add(ttelem, new StabType(StabTypes.Condition, ttelem, tdescp));
								break;

							// Easement
							case "EAS":
								easements.Add(ttelem, new StabType(StabTypes.Easement, ttelem, tdescp));
								break;

							// ExteriorWall
							case "EXW":
								extWalls.Add(ttelem, new StabType(StabTypes.ExteriorWall, ttelem, tdescp, texwal));
								break;

							// FloorType
							case "FLR":
								floors.Add(ttelem, new StabType(StabTypes.FloorType, ttelem, tdescp));
								break;

							// Foundation
							case "FND":
								foundations.Add(ttelem, new StabType(StabTypes.Foundation, ttelem, tdescp));
								break;

							// Fuel
							case "FUL":
								fuels.Add(ttelem, new StabType(StabTypes.Fuel, ttelem, tdescp));
								break;

							// GarageType
							case "GAR":
								garages.Add(ttelem, new StabType(StabTypes.GarageType, ttelem, tdescp));
								break;

							// Heat
							case "HT":
								heats.Add(ttelem, new StabType(StabTypes.Heat, ttelem, tdescp));
								break;

							// InteriorWall
							case "INW":
								intWalls.Add(ttelem, new StabType(StabTypes.InteriorWall, ttelem, tdescp));
								break;

							// Occupancy
							case "OCC":
								occups.Add(ttelem, new StabType(StabTypes.Occupancy, ttelem, tdescp));
								break;

							// RightOfWay
							case "ROW":
								rows.Add(ttelem, new StabType(StabTypes.RightOfWay, ttelem, tdescp));
								break;

							// RoofingMaterial
							case "RFG":
								roofMats.Add(ttelem, new StabType(StabTypes.RoofingMaterial, ttelem, tdescp));
								break;

							// RoofingType
							case "RFT":
								roofTypes.Add(ttelem, new StabType(StabTypes.RoofingType, ttelem, tdescp));
								break;

							// Sewer
							case "SEW":
								sewers.Add(ttelem, new StabType(StabTypes.Sewer, ttelem, tdescp));
								break;

							// Terrain
							case "TER":
								terrains.Add(ttelem, new StabType(StabTypes.Terrain, ttelem, tdescp));
								break;

							// Water
							case "WAT":
								waters.Add(ttelem, new StabType(StabTypes.Water, ttelem, tdescp));
								break;

							default:
								break;
						}
					}
					reader.Close();

					// BasementType
					this.AllTypesList.Add(StabTypes.BasementType, basements);

					// CarportType
					this.AllTypesList.Add(StabTypes.CarportType, carports);

					// Characteristic
					this.AllTypesList.Add(StabTypes.Characteristic, characters);

					// Class
					this.AllTypesList.Add(StabTypes.Class, classes);

					// Condition
					this.AllTypesList.Add(StabTypes.Condition, conditions);

					// Easement
					this.AllTypesList.Add(StabTypes.Easement, easements);

					// ExteriorWall
					this.AllTypesList.Add(StabTypes.ExteriorWall, extWalls);

					// FloorType
					this.AllTypesList.Add(StabTypes.FloorType, floors);

					// Foundation
					this.AllTypesList.Add(StabTypes.Foundation, foundations);

					// Fuel
					this.AllTypesList.Add(StabTypes.Fuel, fuels);

					// GarageType
					this.AllTypesList.Add(StabTypes.GarageType, garages);

					// Heat
					this.AllTypesList.Add(StabTypes.Heat, heats);

					// InteriorWall
					this.AllTypesList.Add(StabTypes.InteriorWall, intWalls);

					// Occupancy
					this.AllTypesList.Add(StabTypes.Occupancy, occups);

					// RightOfWay
					this.AllTypesList.Add(StabTypes.RightOfWay, rows);

					// RoofingMaterial
					this.AllTypesList.Add(StabTypes.RoofingMaterial, roofMats);

					// RoofingType
					this.AllTypesList.Add(StabTypes.RoofingType, roofTypes);

					// Sewer
					this.AllTypesList.Add(StabTypes.Sewer, sewers);

					// Terrain
					this.AllTypesList.Add(StabTypes.Terrain, terrains);

					// Water
					this.AllTypesList.Add(StabTypes.Water, waters);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
			}
		}
	}

	public sealed class StabType
	{
		private StabMaster.StabTypes type;
		private string elemcode;
		private string description;
		private string extension = null;

		private StabType()
		{
		}

		public StabType(StabMaster.StabTypes type, string elemcode, string description)
		{
			this.type = type;
			this.elemcode = elemcode;
			this.description = description;
		}

		public StabType(StabMaster.StabTypes type, string elemcode, string description, string extension)
			: this(type, elemcode, description)
		{
			this.extension = extension;
		}

		public string CodeAndDescription
		{
			get
			{
				return this.elemcode + " - " + this.description;
			}
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

		public string Extension
		{
			get
			{
				return this.extension;
			}
		}

		public StabMaster.StabTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public string TTID
		{
			get
			{
				string s = null;

				switch (this.type)
				{
					case StabMaster.StabTypes.BasementType:
						s = "BAS";
						break;

					case StabMaster.StabTypes.CarportType:
						s = "CAR";
						break;

					case StabMaster.StabTypes.Characteristic:
						s = "CHR";
						break;

					case StabMaster.StabTypes.Class:
						s = "CLS";
						break;

					case StabMaster.StabTypes.Condition:
						s = "CON";
						break;

					case StabMaster.StabTypes.Easement:
						s = "EAS";
						break;

					case StabMaster.StabTypes.ExteriorWall:
						s = "EXW";
						break;

					case StabMaster.StabTypes.FloorType:
						s = "FLR";
						break;

					case StabMaster.StabTypes.Foundation:
						s = "FND";
						break;

					case StabMaster.StabTypes.Fuel:
						s = "FUL";
						break;

					case StabMaster.StabTypes.GarageType:
						s = "GAR";
						break;

					case StabMaster.StabTypes.Heat:
						s = "HT";
						break;

					case StabMaster.StabTypes.InteriorWall:
						s = "INW";
						break;

					case StabMaster.StabTypes.Occupancy:
						s = "OCC";
						break;

					case StabMaster.StabTypes.RightOfWay:
						s = "ROW";
						break;

					case StabMaster.StabTypes.RoofingMaterial:
						s = "RFG";
						break;

					case StabMaster.StabTypes.RoofingType:
						s = "RFT";
						break;

					case StabMaster.StabTypes.Sewer:
						s = "SEW";
						break;

					case StabMaster.StabTypes.Terrain:
						s = "TER";
						break;

					case StabMaster.StabTypes.Water:
						s = "WAT";
						break;

					default:
						break;
				}

				return s;
			}
		}
	}
}