using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	/* C# Bean representing the following Table:
        Library  : CAMRALIB
        Table    : CAFPBAT
        Created  : 11/2/2006 9:59:41 AM
        Generator: Stonewall Technologies BeanMaker 0.0.1
    */

	public class REBatch : IDBTable
	{
		#region Variables

		private string dataBase = "CAMRALIB";
		private string fileName = "CAFPBAT";
		private string localityPrefix = "";
		private string separator = ".";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;
		public static string allFieldNamesActual = "SID,SRECNO,SDWELL";
		public static string allFieldNamesAdjusted = "SID,SRECNO,SDWELL";
		public static string nonKeyFieldsActual = "SID";
		public static string nonKeyFieldsAdjusted = "SID";
		private string selectFields = "SID,SRECNO,SDWELL";

		// SID - RECORD ID CODE
		// Managed by Property: Sid
		private FixedString SID = new FixedString(1);

		// SRECNO - PARCEL RECORD#
		// Managed by Property: Srecno
		private FixedDecimal SRECNO = new FixedDecimal(7, 0);

		// SDWELL - PARCEL DWELLING#
		// Managed by Property: Sdwell
		private FixedDecimal SDWELL = new FixedDecimal(2, 0);

		#endregion Variables

		#region Constructors

		private REBatch()
		{
		}

		public REBatch(IDBAccess db)
		{
			this.db = db;
		}

		public REBatch(IDBAccess db, FixedDecimal SRECNO, FixedDecimal SDWELL) : this(db)
		{
			this.SRECNO = SRECNO;
			this.SDWELL = SDWELL;

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
				this.fileName = value + "BT";
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
				sb.Append(" SRECNO = " + this.SRECNO.ToString());
				sb.Append(" and ");
				sb.Append(" SDWELL = " + this.SDWELL.ToString());

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
				sb.Append(" SRECNO = @SRECNO ");
				sb.Append(" and ");
				sb.Append(" SDWELL = @SDWELL ");

				sb.Append(" ");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - SID
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: RECORD ID CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Sid
		{
			get
			{
				return this.SID;
			}

			set
			{
				if (this.SID.checkValue(value))
				{
					this.SID.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Sid Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - SRECNO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,0)
		/// <para>Description: PARCEL RECORD#</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Srecno
		{
			get
			{
				return this.SRECNO;
			}

			set
			{
				if (this.SRECNO.checkValue(value))
				{
					this.SRECNO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Srecno Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - SDWELL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: PARCEL DWELLING#</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Sdwell
		{
			get
			{
				return this.SDWELL;
			}

			set
			{
				if (this.SDWELL.checkValue(value))
				{
					this.SDWELL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Sdwell Property.");
				}
			}
		}

		#endregion Properties

		#region Public Static Methods

		/// <summary>
		/// Builds a parameterized string for Updating the file.
		/// </summary>
		/// <param name="QualifiedDatabaseAndTableName">The qualified database and Table name for the update.</param>
		/// <example>string sql = REBatch.ParameterizedUpdateSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedUpdateSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("update ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" set ");
			string[] updFieldsActual = REBatch.nonKeyFieldsActual.Split(new char[] { ',' });
			string[] updFieldsAdjusted = REBatch.nonKeyFieldsAdjusted.Split(new char[] { ',' });
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
		/// <example>string sql = REBatch.ParameterizedInsertSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedInsertSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("insert into ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" (");
			sb.Append(REBatch.allFieldNamesActual);
			sb.Append(") ");
			sb.Append("values( ");
			string[] insFields = REBatch.allFieldNamesAdjusted.Split(new char[] { ',' });
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
			IDataParameter parm_SID = db.CreateParameter("@SID", DatabaseConstants.DataTypes.Char, "SID", 1, 0);
			parms.Add(parm_SID);
			IDataParameter parm_SRECNO = db.CreateParameter("@SRECNO", DatabaseConstants.DataTypes.Numeric, "SRECNO", 7, 0);
			parms.Add(parm_SRECNO);
			IDataParameter parm_SDWELL = db.CreateParameter("@SDWELL", DatabaseConstants.DataTypes.Numeric, "SDWELL", 2, 0);
			parms.Add(parm_SDWELL);

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
				this.db.SetParameterValue(comm.Parameters, "@SID", this.SID.Value);
				this.db.SetParameterValue(comm.Parameters, "@SRECNO", this.SRECNO.Value);
				this.db.SetParameterValue(comm.Parameters, "@SDWELL", this.SDWELL.Value);

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

				this.SID.setValue(dr["SID"].ToString());
				this.SRECNO.setValue(dr["SRECNO"].ToString());
				this.SDWELL.setValue(dr["SDWELL"].ToString());

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
				sb.Append(REBatch.allFieldNamesActual);
				sb.Append(" ) ");
				sb.Append("values( ");
				sb.Append("'" + this.SID.Text + "'");
				sb.Append(", ");
				sb.Append(this.SRECNO.ToString());
				sb.Append(", ");
				sb.Append(this.SDWELL.ToString());

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
				sb.Append("SID = '" + this.SID.Text + "'");
				sb.Append(", ");
				sb.Append("SRECNO = " + this.SRECNO.ToString());
				sb.Append(", ");
				sb.Append("SDWELL = " + this.SDWELL.ToString());

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