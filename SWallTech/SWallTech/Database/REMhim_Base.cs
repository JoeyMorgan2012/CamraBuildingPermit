using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	/* C# Bean representing the following Table:
        Library  : CAMRALIB
        Table    : CAFPMHIM
        Created  : 5/14/2007 3:47:11 PM
        Generator: Stonewall Technologies BeanMaker 0.0.1

	This class is an Abstract base class for this Database Table. SWallTech.REMhim
	inherits from this class so that you can regenerate this Base class
	to reflect any database changes without losing your custom code.

    */

	public abstract class REMhim_Base : IDBTable
	{
		#region Variables

		private string dataBase = "CAMRALIB";
		private string fileName = "CAFPMHIM";
		private string separator = ".";
		protected IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;
		public static string allFieldNamesActual = "IID,IRECNO,IDWELL,ISEQNO,IDESC,ILEN,IWID,ICOND,IFILL1,ITOTV,IDEPR,IRATE,IFILL2,ICODE,IFILL3";
		public static string allFieldNamesAdjusted = "IID,IRECNO,IDWELL,ISEQNO,IDESC,ILEN,IWID,ICOND,IFILL1,ITOTV,IDEPR,IRATE,IFILL2,ICODE,IFILL3";
		public static string nonKeyFieldsActual = "IID,IDESC,ILEN,IWID,ICOND,IFILL1,ITOTV,IDEPR,IRATE,IFILL2,ICODE,IFILL3";
		public static string nonKeyFieldsAdjusted = "IID,IDESC,ILEN,IWID,ICOND,IFILL1,ITOTV,IDEPR,IRATE,IFILL2,ICODE,IFILL3";
		private string selectFields = "IID,IRECNO,IDWELL,ISEQNO,IDESC,ILEN,IWID,ICOND,IFILL1,ITOTV,IDEPR,IRATE,IFILL2,ICODE,IFILL3";

		// IID - RECORD ID CODE
		// Managed by Property: Iid
		private FixedString IID = new FixedString(1);

		// IRECNO - RECORD NUMBER
		// Managed by Property: Irecno
		private FixedDecimal IRECNO = new FixedDecimal(7, 0);

		// IDWELL - DWELLING NO
		// Managed by Property: Idwell
		private FixedDecimal IDWELL = new FixedDecimal(2, 0);

		// ISEQNO - SEQUENCE NO
		// Managed by Property: Iseqno
		private FixedDecimal ISEQNO = new FixedDecimal(2, 0);

		// IDESC - DESCRIPTION
		// Managed by Property: Idesc
		private FixedString IDESC = new FixedString(20);

		// ILEN - LENGTH
		// Managed by Property: Ilen
		private FixedDecimal ILEN = new FixedDecimal(6, 1);

		// IWID - WIDTH
		// Managed by Property: Iwid
		private FixedDecimal IWID = new FixedDecimal(6, 1);

		// ICOND - CONDITION
		// Managed by Property: Icond
		private FixedString ICOND = new FixedString(1);

		// IFILL1 - FILLER 1
		// Managed by Property: Ifill1
		private FixedString IFILL1 = new FixedString(5);

		// ITOTV - TOTAL VALUE
		// Managed by Property: Itotv
		private FixedDecimal ITOTV = new FixedDecimal(8, 0);

		// IDEPR - PERCENT DEPREC
		// Managed by Property: Idepr
		private FixedDecimal IDEPR = new FixedDecimal(3, 2);

		// IRATE - SQ FT RATE OR VALUE
		// Managed by Property: Irate
		private FixedDecimal IRATE = new FixedDecimal(9, 2);

		// IFILL2 - FILLER 2
		// Managed by Property: Ifill2
		private FixedString IFILL2 = new FixedString(8);

		// ICODE - DESCRIPTION CODE
		// Managed by Property: Icode
		private FixedDecimal ICODE = new FixedDecimal(3, 0);

		// IFILL3 - FILLER 3
		// Managed by Property: Ifill3
		private FixedString IFILL3 = new FixedString(3);

		#endregion Variables

		#region Constructors

		public REMhim_Base()
		{
		}

		public REMhim_Base(IDBAccess db)
		{
			this.db = db;
		}

		public REMhim_Base(IDBAccess db, FixedDecimal IRECNO, FixedDecimal IDWELL, FixedDecimal ISEQNO) : this(db)
		{
			this.IRECNO = IRECNO;
			this.IDWELL = IDWELL;
			this.ISEQNO = ISEQNO;

			this.populate();
		}

		#endregion Constructors

		#region Properties

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
		/// Gets the Database Filename Separator.
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
				sb.Append(" IRECNO = " + this.IRECNO.ToString());
				sb.Append(" and ");
				sb.Append(" IDWELL = " + this.IDWELL.ToString());
				sb.Append(" and ");
				sb.Append(" ISEQNO = " + this.ISEQNO.ToString());

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
				sb.Append(" IRECNO = @IRECNO ");
				sb.Append(" and ");
				sb.Append(" IDWELL = @IDWELL ");
				sb.Append(" and ");
				sb.Append(" ISEQNO = @ISEQNO ");

				sb.Append(" ");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - IID
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: RECORD ID CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Iid
		{
			get
			{
				return this.IID;
			}

			set
			{
				if (this.IID.checkValue(value))
				{
					this.IID.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Iid Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - IRECNO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,0)
		/// <para>Description: RECORD NUMBER</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Irecno
		{
			get
			{
				return this.IRECNO;
			}

			set
			{
				if (this.IRECNO.checkValue(value))
				{
					this.IRECNO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Irecno Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - IDWELL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: DWELLING NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Idwell
		{
			get
			{
				return this.IDWELL;
			}

			set
			{
				if (this.IDWELL.checkValue(value))
				{
					this.IDWELL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Idwell Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - ISEQNO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: SEQUENCE NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Iseqno
		{
			get
			{
				return this.ISEQNO;
			}

			set
			{
				if (this.ISEQNO.checkValue(value))
				{
					this.ISEQNO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Iseqno Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - IDESC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(20)
		/// <para>Description: DESCRIPTION</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Idesc
		{
			get
			{
				return this.IDESC;
			}

			set
			{
				if (this.IDESC.checkValue(value))
				{
					this.IDESC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Idesc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - ILEN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (6,1)
		/// <para>Description: LENGTH</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Ilen
		{
			get
			{
				return this.ILEN;
			}

			set
			{
				if (this.ILEN.checkValue(value))
				{
					this.ILEN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Ilen Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - IWID
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (6,1)
		/// <para>Description: WIDTH</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Iwid
		{
			get
			{
				return this.IWID;
			}

			set
			{
				if (this.IWID.checkValue(value))
				{
					this.IWID.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Iwid Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - ICOND
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: CONDITION</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Icond
		{
			get
			{
				return this.ICOND;
			}

			set
			{
				if (this.ICOND.checkValue(value))
				{
					this.ICOND.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Icond Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - IFILL1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(5)
		/// <para>Description: FILLER 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Ifill1
		{
			get
			{
				return this.IFILL1;
			}

			set
			{
				if (this.IFILL1.checkValue(value))
				{
					this.IFILL1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Ifill1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - ITOTV
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: TOTAL VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Itotv
		{
			get
			{
				return this.ITOTV;
			}

			set
			{
				if (this.ITOTV.checkValue(value))
				{
					this.ITOTV.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Itotv Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - IDEPR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: PERCENT DEPREC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Idepr
		{
			get
			{
				return this.IDEPR;
			}

			set
			{
				if (this.IDEPR.checkValue(value))
				{
					this.IDEPR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Idepr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - IRATE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,2)
		/// <para>Description: SQ FT RATE OR VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Irate
		{
			get
			{
				return this.IRATE;
			}

			set
			{
				if (this.IRATE.checkValue(value))
				{
					this.IRATE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Irate Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - IFILL2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(8)
		/// <para>Description: FILLER 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Ifill2
		{
			get
			{
				return this.IFILL2;
			}

			set
			{
				if (this.IFILL2.checkValue(value))
				{
					this.IFILL2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Ifill2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - ICODE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,0)
		/// <para>Description: DESCRIPTION CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Icode
		{
			get
			{
				return this.ICODE;
			}

			set
			{
				if (this.ICODE.checkValue(value))
				{
					this.ICODE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Icode Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - IFILL3
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(3)
		/// <para>Description: FILLER 3</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Ifill3
		{
			get
			{
				return this.IFILL3;
			}

			set
			{
				if (this.IFILL3.checkValue(value))
				{
					this.IFILL3.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Ifill3 Property.");
				}
			}
		}

		#endregion Properties

		#region Public Static Methods

		/// <summary>
		/// Builds a parameterized string for Updating the file.
		/// </summary>
		/// <param name="QualifiedDatabaseAndTableName">The qualified database and Table name for the update.</param>
		/// <example>string sql = REMhim.ParameterizedUpdateSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedUpdateSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("update ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" set ");
			string[] updFieldsActual = REMhim.nonKeyFieldsActual.Split(new char[] { ',' });
			string[] updFieldsAdjusted = REMhim.nonKeyFieldsAdjusted.Split(new char[] { ',' });
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
		/// <example>string sql = REMhim.ParameterizedInsertSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedInsertSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("insert into ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" (");
			sb.Append(REMhim.allFieldNamesActual);
			sb.Append(") ");
			sb.Append("values( ");
			string[] insFields = REMhim.allFieldNamesAdjusted.Split(new char[] { ',' });
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
			IDataParameter parm_IID = db.CreateParameter("@IID", DatabaseConstants.DataTypes.Char, "IID", 1, 0);
			parms.Add(parm_IID);
			IDataParameter parm_IRECNO = db.CreateParameter("@IRECNO", DatabaseConstants.DataTypes.Char, "IRECNO", 7, 0);
			parms.Add(parm_IRECNO);
			IDataParameter parm_IDWELL = db.CreateParameter("@IDWELL", DatabaseConstants.DataTypes.Char, "IDWELL", 2, 0);
			parms.Add(parm_IDWELL);
			IDataParameter parm_ISEQNO = db.CreateParameter("@ISEQNO", DatabaseConstants.DataTypes.Char, "ISEQNO", 2, 0);
			parms.Add(parm_ISEQNO);
			IDataParameter parm_IDESC = db.CreateParameter("@IDESC", DatabaseConstants.DataTypes.Char, "IDESC", 20, 0);
			parms.Add(parm_IDESC);
			IDataParameter parm_ILEN = db.CreateParameter("@ILEN", DatabaseConstants.DataTypes.Char, "ILEN", 6, 1);
			parms.Add(parm_ILEN);
			IDataParameter parm_IWID = db.CreateParameter("@IWID", DatabaseConstants.DataTypes.Char, "IWID", 6, 1);
			parms.Add(parm_IWID);
			IDataParameter parm_ICOND = db.CreateParameter("@ICOND", DatabaseConstants.DataTypes.Char, "ICOND", 1, 0);
			parms.Add(parm_ICOND);
			IDataParameter parm_IFILL1 = db.CreateParameter("@IFILL1", DatabaseConstants.DataTypes.Char, "IFILL1", 5, 0);
			parms.Add(parm_IFILL1);
			IDataParameter parm_ITOTV = db.CreateParameter("@ITOTV", DatabaseConstants.DataTypes.Char, "ITOTV", 8, 0);
			parms.Add(parm_ITOTV);
			IDataParameter parm_IDEPR = db.CreateParameter("@IDEPR", DatabaseConstants.DataTypes.Char, "IDEPR", 3, 2);
			parms.Add(parm_IDEPR);
			IDataParameter parm_IRATE = db.CreateParameter("@IRATE", DatabaseConstants.DataTypes.Char, "IRATE", 9, 2);
			parms.Add(parm_IRATE);
			IDataParameter parm_IFILL2 = db.CreateParameter("@IFILL2", DatabaseConstants.DataTypes.Char, "IFILL2", 8, 0);
			parms.Add(parm_IFILL2);
			IDataParameter parm_ICODE = db.CreateParameter("@ICODE", DatabaseConstants.DataTypes.Char, "ICODE", 3, 0);
			parms.Add(parm_ICODE);
			IDataParameter parm_IFILL3 = db.CreateParameter("@IFILL3", DatabaseConstants.DataTypes.Char, "IFILL3", 3, 0);
			parms.Add(parm_IFILL3);

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
				this.db.SetParameterValue(comm.Parameters, "@IID", this.IID.Value);
				this.db.SetParameterValue(comm.Parameters, "@IRECNO", this.IRECNO.Value);
				this.db.SetParameterValue(comm.Parameters, "@IDWELL", this.IDWELL.Value);
				this.db.SetParameterValue(comm.Parameters, "@ISEQNO", this.ISEQNO.Value);
				this.db.SetParameterValue(comm.Parameters, "@IDESC", this.IDESC.Value);
				this.db.SetParameterValue(comm.Parameters, "@ILEN", this.ILEN.Value);
				this.db.SetParameterValue(comm.Parameters, "@IWID", this.IWID.Value);
				this.db.SetParameterValue(comm.Parameters, "@ICOND", this.ICOND.Value);
				this.db.SetParameterValue(comm.Parameters, "@IFILL1", this.IFILL1.Value);
				this.db.SetParameterValue(comm.Parameters, "@ITOTV", this.ITOTV.Value);
				this.db.SetParameterValue(comm.Parameters, "@IDEPR", this.IDEPR.Value);
				this.db.SetParameterValue(comm.Parameters, "@IRATE", this.IRATE.Value);
				this.db.SetParameterValue(comm.Parameters, "@IFILL2", this.IFILL2.Value);
				this.db.SetParameterValue(comm.Parameters, "@ICODE", this.ICODE.Value);
				this.db.SetParameterValue(comm.Parameters, "@IFILL3", this.IFILL3.Value);

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

				this.IID.setValue(dr["IID"].ToString());
				this.IRECNO.setValue(dr["IRECNO"].ToString());
				this.IDWELL.setValue(dr["IDWELL"].ToString());
				this.ISEQNO.setValue(dr["ISEQNO"].ToString());
				this.IDESC.setValue(dr["IDESC"].ToString());
				this.ILEN.setValue(dr["ILEN"].ToString());
				this.IWID.setValue(dr["IWID"].ToString());
				this.ICOND.setValue(dr["ICOND"].ToString());
				this.IFILL1.setValue(dr["IFILL1"].ToString());
				this.ITOTV.setValue(dr["ITOTV"].ToString());
				this.IDEPR.setValue(dr["IDEPR"].ToString());
				this.IRATE.setValue(dr["IRATE"].ToString());
				this.IFILL2.setValue(dr["IFILL2"].ToString());
				this.ICODE.setValue(dr["ICODE"].ToString());
				this.IFILL3.setValue(dr["IFILL3"].ToString());

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
				sb.Append(REMhim.allFieldNamesActual);
				sb.Append(" ) ");
				sb.Append("values( ");
				sb.Append("'" + this.IID.Text + "'");
				sb.Append(", ");
				sb.Append(this.IRECNO.ToString());
				sb.Append(", ");
				sb.Append(this.IDWELL.ToString());
				sb.Append(", ");
				sb.Append(this.ISEQNO.ToString());
				sb.Append(", ");
				sb.Append("'" + this.IDESC.Text + "'");
				sb.Append(", ");
				sb.Append(this.ILEN.ToString());
				sb.Append(", ");
				sb.Append(this.IWID.ToString());
				sb.Append(", ");
				sb.Append("'" + this.ICOND.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.IFILL1.Text + "'");
				sb.Append(", ");
				sb.Append(this.ITOTV.ToString());
				sb.Append(", ");
				sb.Append(this.IDEPR.ToString());
				sb.Append(", ");
				sb.Append(this.IRATE.ToString());
				sb.Append(", ");
				sb.Append("'" + this.IFILL2.Text + "'");
				sb.Append(", ");
				sb.Append(this.ICODE.ToString());
				sb.Append(", ");
				sb.Append("'" + this.IFILL3.Text + "'");

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
				sb.Append("IID = '" + this.IID.Text + "'");
				sb.Append(", ");
				sb.Append("IRECNO = " + this.IRECNO.ToString());
				sb.Append(", ");
				sb.Append("IDWELL = " + this.IDWELL.ToString());
				sb.Append(", ");
				sb.Append("ISEQNO = " + this.ISEQNO.ToString());
				sb.Append(", ");
				sb.Append("IDESC = '" + this.IDESC.Text + "'");
				sb.Append(", ");
				sb.Append("ILEN = " + this.ILEN.ToString());
				sb.Append(", ");
				sb.Append("IWID = " + this.IWID.ToString());
				sb.Append(", ");
				sb.Append("ICOND = '" + this.ICOND.Text + "'");
				sb.Append(", ");
				sb.Append("IFILL1 = '" + this.IFILL1.Text + "'");
				sb.Append(", ");
				sb.Append("ITOTV = " + this.ITOTV.ToString());
				sb.Append(", ");
				sb.Append("IDEPR = " + this.IDEPR.ToString());
				sb.Append(", ");
				sb.Append("IRATE = " + this.IRATE.ToString());
				sb.Append(", ");
				sb.Append("IFILL2 = '" + this.IFILL2.Text + "'");
				sb.Append(", ");
				sb.Append("ICODE = " + this.ICODE.ToString());
				sb.Append(", ");
				sb.Append("IFILL3 = '" + this.IFILL3.Text + "'");

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
				sb.Append("delete from ");
				sb.Append(this.FullFileName);
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

		#endregion Public Methods

		#region Private Methods

		#endregion Private Methods
	}
}