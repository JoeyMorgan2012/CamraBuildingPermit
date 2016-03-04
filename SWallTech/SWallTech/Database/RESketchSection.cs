using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	/* C# Bean representing the following Table:
        Library  : CAMRALIB
        Table    : JSKSECTION
        Created  : 11/2/2006 10:07:38 AM
        Generator: Stonewall Technologies BeanMaker 0.0.1
    */

	public class RESketchSection : IDBTable
	{
		#region Variables

		private string dataBase = "CAMRALIB";
		private string fileName = "JSKSECTION";
		private string separator = ".";
		private string localityPrefix = "";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;
		public static string allFieldNamesActual = "JSRECORD,JSDWELL,JSSECT,JSTYPE,JSSTORY,JSDESC,JSSKETCH,JSSQFT,JS0DEPR,JSCLASS,JSVALUE,JSFACTOR,JSDEPRC";
		public static string allFieldNamesAdjusted = "JSRECORD,JSDWELL,JSSECT,JSTYPE,JSSTORY,JSDESC,JSSKETCH,JSSQFT,JS0DEPR,JSCLASS,JSVALUE,JSFACTOR,JSDEPRC";
		public static string nonKeyFieldsActual = "JSTYPE,JSSTORY,JSDESC,JSSKETCH,JSSQFT";
		public static string nonKeyFieldsAdjusted = "JSTYPE,JSSTORY,JSDESC,JSSKETCH,JSSQFT";
		private string selectFields = "JSRECORD,JSDWELL,JSSECT,JSTYPE,JSSTORY,JSDESC,JSSKETCH,JSSQFT,JS0DEPR,JSCLASS,JSVALUE,JSFACTOR,JSDEPRC";

		// JSRECORD - Description Undefined
		// Managed by Property: Record
		private FixedDecimal JSRECORD = new FixedDecimal(7, 0);

		// JSDWELL - Description Undefined
		// Managed by Property: Card
		private FixedDecimal JSDWELL = new FixedDecimal(2, 0);

		// JSSECT - Description Undefined
		// Managed by Property: Sectionletter
		private FixedString JSSECT = new FixedString(2);

		// JSTYPE - Description Undefined
		// Managed by Property: Sectiontype
		private FixedString JSTYPE = new FixedString(4);

		// JSSTORY - Description Undefined
		// Managed by Property: Story
		private FixedDecimal JSSTORY = new FixedDecimal(4, 2);

		// JSDESC - Description Undefined
		// Managed by Property: Description
		private FixedString JSDESC = new FixedString(35);

		// JSSKETCH - Description Undefined
		// Managed by Property: Hassketch
		private FixedString JSSKETCH = new FixedString(1);

		// JSSQFT - Description Undefined
		// Managed by Property: Sectionsqft
		private FixedDecimal JSSQFT = new FixedDecimal(8, 1);

		// JS0DEPR - Description Undefined
		// Managed by Property: ZeroDepreciation
		private FixedString JS0DEPR = new FixedString(1);

		// JSCLASS - Description Undefined
		// Managed by Property: SectionClass
		private FixedString JSCLASS = new FixedString(1);

		// JSVALUE - Description Undefined
		// Managed by Property: SectionValue
		private FixedDecimal JSVALUE = new FixedDecimal(9, 2);

		// JSFACTOR - Description Undefined
		// Managed by Property: Factor
		private FixedDecimal JSFACTOR = new FixedDecimal(3, 2);

		// JSDEPRC - Description Undefined
		// Managed by Property: Depreciation
		private FixedDecimal JSDEPRC = new FixedDecimal(3, 2);

		#endregion Variables

		#region Constructors

		private RESketchSection()
		{
		}

		public RESketchSection(IDBAccess db)
		{
			this.db = db;
		}

		public RESketchSection(IDBAccess db, FixedDecimal JSRECORD, FixedDecimal JSDWELL, FixedString JSSECT) : this(db)
		{
			this.JSRECORD = JSRECORD;
			this.JSDWELL = JSDWELL;
			this.JSSECT = JSSECT;

			this.populate();
		}

		public RESketchSection(IDBAccess db, string library, string localityPrefix, int record, int card, string sectionLetter)
			: this(db)
		{
			this.dataBase = library;
			this.LocalityPrefix = localityPrefix;

			//this.FileName = localityPrefix + "SECTION";
			this.JSRECORD.setValue(record);
			this.JSDWELL.setValue(card);
			this.JSSECT.setValue(sectionLetter);
			this.populate();
		}

		#endregion Constructors

		#region Properties

		public string LocalityPrefix
		{
			get
			{
				return this.localityPrefix;
			}

			set
			{
				this.localityPrefix = value;
				this.fileName = value + "SECTION";
			}
		}

		/// <summary>
		/// Gets or sets IDBAccess Connection Object.
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

		/// <summary>
		/// Gets or sets the DataBase name.
		/// </summary>
		public string DataBase
		{
			get
			{
				return this.dataBase;
			}

			set
			{
				this.dataBase = value;
			}
		}

		/// <summary>
		/// Gets or sets the Database Table name.
		/// </summary>
		public string FileName
		{
			get
			{
				return this.fileName;
			}

			set
			{
				this.fileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the Database Filename Separator.
		/// </summary>
		public string Separator
		{
			get
			{
				return this.separator;
			}

			set
			{
				this.separator = value;
			}
		}

		/// <summary>
		/// Gets the fully qualified Database Table name.
		/// </summary>
		public string FullFileName
		{
			get
			{
				string fullFileName = this.dataBase + this.Separator + this.fileName;
				return fullFileName;
			}
		}

		/// <summary>
		/// Gets the Database Exception object from the
		/// most recent Database operation.
		/// </summary>
		/// <remarks>
		/// Returns NULL if no Exception occurred.
		/// </remarks>
		public Exception LastException
		{
			get
			{
				return this.lastException;
			}
		}

		private string WhereClause
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(" where ");
				sb.Append(" JSRECORD = " + this.JSRECORD.ToString());
				sb.Append(" and ");
				sb.Append(" JSDWELL = " + this.JSDWELL.ToString());
				sb.Append(" and ");
				sb.Append(" JSSECT = '" + this.JSSECT.ToString() + "'");

				sb.Append(" ");
				return sb.ToString();
			}
		}

		private static string WhereClauseParameterized
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(" where ");
				sb.Append(" JSRECORD = @JSRECORD ");
				sb.Append(" and ");
				sb.Append(" JSDWELL = @JSDWELL ");
				sb.Append(" and ");
				sb.Append(" JSSECT = @JSSECT ");

				sb.Append(" ");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSRECORD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(7,0)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Record
		{
			get
			{
				return this.JSRECORD;
			}

			set
			{
				if (this.JSRECORD.checkValue(value))
				{
					this.JSRECORD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Record Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSDWELL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(2,0)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Card
		{
			get
			{
				return this.JSDWELL;
			}

			set
			{
				if (this.JSDWELL.checkValue(value))
				{
					this.JSDWELL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Card Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSSECT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Sectionletter
		{
			get
			{
				return this.JSSECT;
			}

			set
			{
				if (this.JSSECT.checkValue(value))
				{
					this.JSSECT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Sectionletter Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSTYPE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Sectiontype
		{
			get
			{
				return this.JSTYPE;
			}

			set
			{
				if (this.JSTYPE.checkValue(value))
				{
					this.JSTYPE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Sectiontype Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSSTORY
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(4,2)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Story
		{
			get
			{
				return this.JSSTORY;
			}

			set
			{
				if (this.JSSTORY.checkValue(value))
				{
					this.JSSTORY.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Story Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSDESC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Description
		{
			get
			{
				return this.JSDESC;
			}

			set
			{
				if (this.JSDESC.checkValue(value))
				{
					this.JSDESC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Description Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSSKETCH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hassketch
		{
			get
			{
				return this.JSSKETCH;
			}

			set
			{
				if (this.JSSKETCH.checkValue(value))
				{
					this.JSSKETCH.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hassketch Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSSQFT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(8,1)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Sectionsqft
		{
			get
			{
				return this.JSSQFT;
			}

			set
			{
				if (this.JSSQFT.checkValue(value))
				{
					this.JSSQFT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Sectionsqft Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JS0DEPR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString ZeroDepreciation
		{
			get
			{
				return this.JS0DEPR;
			}

			set
			{
				if (this.JS0DEPR.checkValue(value))
				{
					this.JS0DEPR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the ZeroDepreciation Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSCLASS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString SectionClass
		{
			get
			{
				return this.JSCLASS;
			}

			set
			{
				if (this.JSCLASS.checkValue(value))
				{
					this.JSCLASS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the SectionClass Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSVALUE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(9,2)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal SectionValue
		{
			get
			{
				return this.JSVALUE;
			}

			set
			{
				if (this.JSVALUE.checkValue(value))
				{
					this.JSVALUE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the SectionValue Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSFACTOR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(3,2)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Factor
		{
			get
			{
				return this.JSFACTOR;
			}

			set
			{
				if (this.JSFACTOR.checkValue(value))
				{
					this.JSFACTOR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Factor Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSDEPRC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(3,2)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Depreciation
		{
			get
			{
				return this.JSDEPRC;
			}

			set
			{
				if (this.JSDEPRC.checkValue(value))
				{
					this.JSDEPRC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Depreciation Property.");
				}
			}
		}

		#endregion Properties

		#region Public Static Methods

		/// <summary>
		/// Builds a parameterized string for Updating the file.
		/// </summary>
		/// <param name="QualifiedDatabaseAndTableName">The qualified database and Table name for the update.</param>
		/// <example>string sql = RESketchSection.ParameterizedUpdateSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedUpdateSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("update ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" set ");
			string[] updFieldsActual = RESketchSection.nonKeyFieldsActual.Split(new char[] { ',' });
			string[] updFieldsAdjusted = RESketchSection.nonKeyFieldsAdjusted.Split(new char[] { ',' });
			for (int i = 0; i < updFieldsActual.Length; i++)
			{
				if (i > 0)
				{
					sb.Append(", ");
				}
				sb.Append(updFieldsActual[i]);
				sb.Append(" = @");
				sb.Append(updFieldsAdjusted[i]);
			}
			sb.Append(WhereClauseParameterized);
			return sb.ToString();
		}

		/// <summary>
		/// Builds a parameterized string for Inserting into the file.
		/// </summary>
		/// <param name="QualifiedDatabaseAndTableName">The qualified database and Table name for the update.</param>
		/// <example>string sql = RESketchSection.ParameterizedInsertSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedInsertSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("insert into ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" (");
			sb.Append(RESketchSection.allFieldNamesActual);
			sb.Append(") ");
			sb.Append("values( ");
			string[] insFields = RESketchSection.allFieldNamesAdjusted.Split(new char[] { ',' });
			for (int i = 0; i < insFields.Length; i++)
			{
				if (i > 0)
				{
					sb.Append(", ");
				}
				sb.Append("@");
				sb.Append(insFields[i]);
			}
			sb.Append(" ) ");
			return sb.ToString();
		}

		/// <summary>
		/// A generic List of IDbDataParameter objects.  Useful for Parameterized queries.
		/// </summary>
		/// <param name="db"></param>
		/// <returns></returns>
		public static List<IDataParameter> ParameterCollection(DBAccessManager db)
		{
			List<IDataParameter> parms = new List<IDataParameter>();
			IDataParameter parm_JSRECORD = db.CreateParameter("@JSRECORD", DatabaseConstants.DataTypes.Numeric, "JSRECORD", 7, 0);
			parms.Add(parm_JSRECORD);
			IDataParameter parm_JSDWELL = db.CreateParameter("@JSDWELL", DatabaseConstants.DataTypes.Numeric, "JSDWELL", 2, 0);
			parms.Add(parm_JSDWELL);
			IDataParameter parm_JSSECT = db.CreateParameter("@JSSECT", DatabaseConstants.DataTypes.Char, "JSSECT", 2, 0);
			parms.Add(parm_JSSECT);
			IDataParameter parm_JSTYPE = db.CreateParameter("@JSTYPE", DatabaseConstants.DataTypes.Char, "JSTYPE", 4, 0);
			parms.Add(parm_JSTYPE);
			IDataParameter parm_JSSTORY = db.CreateParameter("@JSSTORY", DatabaseConstants.DataTypes.Numeric, "JSSTORY", 4, 2);
			parms.Add(parm_JSSTORY);
			IDataParameter parm_JSDESC = db.CreateParameter("@JSDESC", DatabaseConstants.DataTypes.Char, "JSDESC", 35, 0);
			parms.Add(parm_JSDESC);
			IDataParameter parm_JSSKETCH = db.CreateParameter("@JSSKETCH", DatabaseConstants.DataTypes.Char, "JSSKETCH", 1, 0);
			parms.Add(parm_JSSKETCH);
			IDataParameter parm_JSSQFT = db.CreateParameter("@JSSQFT", DatabaseConstants.DataTypes.Numeric, "JSSQFT", 8, 1);
			parms.Add(parm_JSSQFT);
			IDataParameter parm_JS0DEPR = db.CreateParameter("@JS0DEPR", DatabaseConstants.DataTypes.Char, "JS0DEPR", 1, 0);
			parms.Add(parm_JS0DEPR);
			IDataParameter parm_JSCLASS = db.CreateParameter("@JSCLASS", DatabaseConstants.DataTypes.Char, "JSCLASS", 1, 0);
			parms.Add(parm_JSCLASS);
			IDataParameter parm_JSVALUE = db.CreateParameter("@JSVALUE", DatabaseConstants.DataTypes.Numeric, "JSVALUE", 9, 2);
			parms.Add(parm_JSVALUE);
			IDataParameter parm_JSFACTOR = db.CreateParameter("@JSFACTOR", DatabaseConstants.DataTypes.Numeric, "JSFACTOR", 8, 1);
			parms.Add(parm_JSFACTOR);
			IDataParameter parm_JSDEPRC = db.CreateParameter("@JSDEPRC", DatabaseConstants.DataTypes.Numeric, "JSDEPRC", 8, 1);
			parms.Add(parm_JSDEPRC);

			return parms;
		}

		#endregion Public Static Methods

		#region Public Methods

		/// <summary>
		/// Populates the Parameter collection and Executes the passed command.  Only used for Parameterized Non-Select statements.
		/// </summary>
		/// <param name="comm">The parameterized command to execute.</param>
		/// <returns>The number of rows affected by the command.</returns>
		public int ExecuteByDataParameterCollection(IDbCommand comm)
		{
			int rowCount = 0;
			try
			{
				this.db.SetParameterValue(comm.Parameters, "@JSRECORD", this.JSRECORD.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSDWELL", this.JSDWELL.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSSECT", this.JSSECT.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSTYPE", this.JSTYPE.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSSTORY", this.JSSTORY.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSDESC", this.JSDESC.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSSKETCH", this.JSSKETCH.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSSQFT", this.JSSQFT.Value);
				this.db.SetParameterValue(comm.Parameters, "@JS0DEPR", this.JS0DEPR.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSCLASS", this.JSCLASS.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSVALUE", this.JSVALUE.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSFACTOR", this.JSFACTOR.Value);
				this.db.SetParameterValue(comm.Parameters, "@JSDEPRC", this.JSDEPRC.Value);

				rowCount = comm.ExecuteNonQuery();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
			}
			return rowCount;
		}

		/// <summary>
		/// Populates the instance properties with data from the database table based on the
		/// current key settings.
		/// </summary>
		public bool populate()
		{
			bool isOK = false;
			this.lastException = null;
			try
			{
				StringBuilder sb = new StringBuilder();

				// Add code here to read table
				sb.Append("Select ");
				sb.Append(this.selectFields);
				sb.Append(" from ");
				sb.Append(this.FullFileName);
				sb.Append(this.WhereClause);

				string cmd = sb.ToString();
				rs = this.db.RunSelectStatement(cmd);
				dt = rs.Tables[0];
				dr = dt.Rows[0];

				this.JSRECORD.setValue(dr["JSRECORD"].ToString());
				this.JSDWELL.setValue(dr["JSDWELL"].ToString());
				this.JSSECT.setValue(dr["JSSECT"].ToString());
				this.JSTYPE.setValue(dr["JSTYPE"].ToString());
				this.JSSTORY.setValue(dr["JSSTORY"].ToString());
				this.JSDESC.setValue(dr["JSDESC"].ToString());
				this.JSSKETCH.setValue(dr["JSSKETCH"].ToString());
				this.JSSQFT.setValue(dr["JSSQFT"].ToString());
				this.JS0DEPR.setValue(dr["JS0DEPR"].ToString());
				this.JSCLASS.setValue(dr["JSCLASS"].ToString());
				this.JSVALUE.setValue(dr["JSVALUE"].ToString());
				this.JSFACTOR.setValue(dr["JSFACTOR"].ToString());
				this.JSDEPRC.setValue(dr["JSDEPRC"].ToString());

				isOK = true;
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return isOK;
		}

		/// <summary>
		/// Inserts a record into the database table using all current property values.
		/// </summary>
		///<returns>The number of rows inserted.</returns>
		public int insert()
		{
			this.lastException = null;
			int rowCount = -1;
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("insert into ");
				sb.Append(this.FullFileName);
				sb.Append(" ( ");
				sb.Append(RESketchSection.allFieldNamesActual);
				sb.Append(" ) ");
				sb.Append("values( ");
				sb.Append(this.JSRECORD.ToString());
				sb.Append(", ");
				sb.Append(this.JSDWELL.ToString());
				sb.Append(", ");
				sb.Append("'" + this.JSSECT.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.JSTYPE.Text + "'");
				sb.Append(", ");
				sb.Append(this.JSSTORY.ToString());
				sb.Append(", ");
				sb.Append("'" + this.JSDESC.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.JSSKETCH.Text + "'");
				sb.Append(", ");
				sb.Append(this.JSSQFT.ToString());
				sb.Append(", ");
				sb.Append("'" + this.JS0DEPR.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.JSCLASS.Text + "'");
				sb.Append(", ");
				sb.Append(this.JSVALUE.ToString());
				sb.Append(", ");
				sb.Append(this.JSFACTOR.ToString());
				sb.Append(", ");
				sb.Append(this.JSDEPRC.ToString());

				sb.Append(" )");

				string cmd = sb.ToString();
				rowCount = this.db.ExecuteNonSelectStatement(cmd);
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return rowCount;
		}

		/// <summary>
		/// Updates the database table with the current property values using the
		/// current key settings.
		/// </summary>
		///<returns>The number of rows updated.</returns>
		public int update()
		{
			this.lastException = null;
			int rowCount = -1;
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("update ");
				sb.Append(this.FullFileName);
				sb.Append(" set ");
				sb.Append("JSRECORD = " + this.JSRECORD.ToString());
				sb.Append(", ");
				sb.Append("JSDWELL = " + this.JSDWELL.ToString());
				sb.Append(", ");
				sb.Append("JSSECT = '" + this.JSSECT.Text + "'");
				sb.Append(", ");
				sb.Append("JSTYPE = '" + this.JSTYPE.Text + "'");
				sb.Append(", ");
				sb.Append("JSSTORY = " + this.JSSTORY.ToString());
				sb.Append(", ");
				sb.Append("JSDESC = '" + this.JSDESC.Text + "'");
				sb.Append(", ");
				sb.Append("JSSKETCH = '" + this.JSSKETCH.Text + "'");
				sb.Append(", ");
				sb.Append("JSSQFT = " + this.JSSQFT.ToString());
				sb.Append(", ");
				sb.Append("JS0DEPR = '" + this.JS0DEPR.Text + "'");
				sb.Append(", ");
				sb.Append("JSCLASS = '" + this.JSCLASS.Text + "'");
				sb.Append(", ");
				sb.Append("JSVALUE = " + this.JSVALUE.ToString());
				sb.Append(", ");
				sb.Append("JSFACTOR = " + this.JSFACTOR.ToString());
				sb.Append(", ");
				sb.Append("JSDEPRC = " + this.JSDEPRC.ToString());

				sb.Append(this.WhereClause);

				string cmd = sb.ToString();
				rowCount = this.db.ExecuteNonSelectStatement(cmd);
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return rowCount;
		}

		/// <summary>
		/// Deletes from the database table all records
		/// with the current key settings.
		/// </summary>
		///<returns>The number of rows deleted.</returns>
		public int delete()
		{
			this.lastException = null;
			int rowCount = -1;
			try
			{
				StringBuilder sb = new StringBuilder();

				// Delete all section lines first
				if (!"".Equals(this.localityPrefix))
				{
					sb.Append("delete from ");
					sb.Append(localityPrefix);
					sb.Append("LINE where JLRECORD = ");
					sb.Append(this.Record.ToString());
					sb.Append(" and JLDWELL = ");
					sb.Append(this.Card.ToString());
					sb.Append(" and JLSECT = '");
					sb.Append(this.Sectionletter.Value);
					sb.Append("'");
					int delCount = this.db.ExecuteNonSelectStatement(sb.ToString());
				}

				// Delete Section
				sb.Length = 0;
				sb.Append("delete from ");
				sb.Append(this.FullFileName);
				sb.Append(this.WhereClause);
				rowCount = this.db.ExecuteNonSelectStatement(sb.ToString());
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return rowCount;
		}

		#endregion Public Methods

		#region Private Methods

		#endregion Private Methods
	}
}