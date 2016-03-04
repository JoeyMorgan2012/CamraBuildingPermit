using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	/* C# Bean representing the following Table:
        Library  : CAMRALIB
        Table    : JSKMASTER
        Created  : 11/2/2006 10:04:03 AM
        Generator: Stonewall Technologies BeanMaker 0.0.1
    */

	public class RESketchMaster : IDBTable
	{
		#region Variables

		private string dataBase = "CAMRALIB";
		private string fileName = "JSKMASTER";
		private string localityPrefix = "";
		private string separator = ".";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;
		public static string allFieldNamesActual = "JMRECORD,JMDWELL,JMSKETCH,JMSTORY,JMSTORYEX,JMSCALE,JMTOTSQFT";
		public static string allFieldNamesAdjusted = "JMRECORD,JMDWELL,JMSKETCH,JMSTORY,JMSTORYEX,JMSCALE,JMTOTSQFT";
		public static string nonKeyFieldsActual = "JMSKETCH,JMSTORY,JMSTORYEX,JMSCALE,JMTOTSQFT";
		public static string nonKeyFieldsAdjusted = "JMSKETCH,JMSTORY,JMSTORYEX,JMSCALE,JMTOTSQFT";
		private string selectFields = "JMRECORD,JMDWELL,JMSKETCH,JMSTORY,JMSTORYEX,JMSCALE,JMTOTSQFT";

		// JMRECORD - Description Undefined
		// Managed by Property: Record
		private FixedDecimal JMRECORD = new FixedDecimal(7, 0);

		// JMDWELL - Description Undefined
		// Managed by Property: Card
		private FixedDecimal JMDWELL = new FixedDecimal(2, 0);

		// JMSKETCH - Description Undefined
		// Managed by Property: Hassketch
		private FixedString JMSKETCH = new FixedString(1);

		// JMSTORY - Description Undefined
		// Managed by Property: Story
		private FixedDecimal JMSTORY = new FixedDecimal(4, 2);

		// JMSTORYEX - Description Undefined
		// Managed by Property: Storyextension
		private FixedString JMSTORYEX = new FixedString(3);

		// JMSCALE - Description Undefined
		// Managed by Property: Scale
		private FixedDecimal JMSCALE = new FixedDecimal(5, 2);

		// JMTOTSQFT - Description Undefined
		// Managed by Property: Totalsqft
		private FixedDecimal JMTOTSQFT = new FixedDecimal(8, 1);

		#endregion Variables

		#region Constructors

		private RESketchMaster()
		{
		}

		public RESketchMaster(IDBAccess db)
		{
			this.db = db;
		}

		public RESketchMaster(IDBAccess db, FixedDecimal JMRECORD, FixedDecimal JMDWELL) : this(db)
		{
			this.JMRECORD = JMRECORD;
			this.JMDWELL = JMDWELL;

			this.populate();
		}

		public RESketchMaster(IDBAccess db, string library, string localityPrefix, int record, int card)
			: this(db)
		{
			this.dataBase = library;
			this.LocalityPrefix = localityPrefix;

			//this.FileName = localityPrefix + "MASTER";
			this.JMRECORD.setValue(record);
			this.JMDWELL.setValue(card);
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
				this.fileName = value + "MASTER";
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
				sb.Append(" JMRECORD = " + this.JMRECORD.ToString());
				sb.Append(" and ");
				sb.Append(" JMDWELL = " + this.JMDWELL.ToString());

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
				sb.Append(" JMRECORD = @JMRECORD ");
				sb.Append(" and ");
				sb.Append(" JMDWELL = @JMDWELL ");

				sb.Append(" ");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMRECORD
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
				return this.JMRECORD;
			}

			set
			{
				if (this.JMRECORD.checkValue(value))
				{
					this.JMRECORD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Record Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMDWELL
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
				return this.JMDWELL;
			}

			set
			{
				if (this.JMDWELL.checkValue(value))
				{
					this.JMDWELL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Card Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMSKETCH
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
				return this.JMSKETCH;
			}

			set
			{
				if (this.JMSKETCH.checkValue(value))
				{
					this.JMSKETCH.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hassketch Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMSTORY
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
				return this.JMSTORY;
			}

			set
			{
				if (this.JMSTORY.checkValue(value))
				{
					this.JMSTORY.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Story Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMSTORYEX
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(3)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Storyextension
		{
			get
			{
				return this.JMSTORYEX;
			}

			set
			{
				if (this.JMSTORYEX.checkValue(value))
				{
					this.JMSTORYEX.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Storyextension Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMSCALE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(5,2)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Scale
		{
			get
			{
				return this.JMSCALE;
			}

			set
			{
				if (this.JMSCALE.checkValue(value))
				{
					this.JMSCALE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Scale Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMTOTSQFT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(8,1)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Totalsqft
		{
			get
			{
				return this.JMTOTSQFT;
			}

			set
			{
				if (this.JMTOTSQFT.checkValue(value))
				{
					this.JMTOTSQFT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Totalsqft Property.");
				}
			}
		}

		#endregion Properties

		#region Public Static Methods

		/// <summary>
		/// Builds a parameterized string for Updating the file.
		/// </summary>
		/// <param name="QualifiedDatabaseAndTableName">The qualified database and Table name for the update.</param>
		/// <example>string sql = RESketchMaster.ParameterizedUpdateSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedUpdateSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("update ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" set ");
			string[] updFieldsActual = RESketchMaster.nonKeyFieldsActual.Split(new char[] { ',' });
			string[] updFieldsAdjusted = RESketchMaster.nonKeyFieldsAdjusted.Split(new char[] { ',' });
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
		/// <example>string sql = RESketchMaster.ParameterizedInsertSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedInsertSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("insert into ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" (");
			sb.Append(RESketchMaster.allFieldNamesActual);
			sb.Append(") ");
			sb.Append("values( ");
			string[] insFields = RESketchMaster.allFieldNamesAdjusted.Split(new char[] { ',' });
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
			IDataParameter parm_JMRECORD = db.CreateParameter("@JMRECORD", DatabaseConstants.DataTypes.Numeric, "JMRECORD", 7, 0);
			parms.Add(parm_JMRECORD);
			IDataParameter parm_JMDWELL = db.CreateParameter("@JMDWELL", DatabaseConstants.DataTypes.Numeric, "JMDWELL", 2, 0);
			parms.Add(parm_JMDWELL);
			IDataParameter parm_JMSKETCH = db.CreateParameter("@JMSKETCH", DatabaseConstants.DataTypes.Char, "JMSKETCH", 1, 0);
			parms.Add(parm_JMSKETCH);
			IDataParameter parm_JMSTORY = db.CreateParameter("@JMSTORY", DatabaseConstants.DataTypes.Numeric, "JMSTORY", 4, 2);
			parms.Add(parm_JMSTORY);
			IDataParameter parm_JMSTORYEX = db.CreateParameter("@JMSTORYEX", DatabaseConstants.DataTypes.Char, "JMSTORYEX", 3, 0);
			parms.Add(parm_JMSTORYEX);
			IDataParameter parm_JMSCALE = db.CreateParameter("@JMSCALE", DatabaseConstants.DataTypes.Numeric, "JMSCALE", 5, 2);
			parms.Add(parm_JMSCALE);
			IDataParameter parm_JMTOTSQFT = db.CreateParameter("@JMTOTSQFT", DatabaseConstants.DataTypes.Numeric, "JMTOTSQFT", 8, 1);
			parms.Add(parm_JMTOTSQFT);

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
				this.db.SetParameterValue(comm.Parameters, "@JMRECORD", this.JMRECORD.Value);
				this.db.SetParameterValue(comm.Parameters, "@JMDWELL", this.JMDWELL.Value);
				this.db.SetParameterValue(comm.Parameters, "@JMSKETCH", this.JMSKETCH.Value);
				this.db.SetParameterValue(comm.Parameters, "@JMSTORY", this.JMSTORY.Value);
				this.db.SetParameterValue(comm.Parameters, "@JMSTORYEX", this.JMSTORYEX.Value);
				this.db.SetParameterValue(comm.Parameters, "@JMSCALE", this.JMSCALE.Value);
				this.db.SetParameterValue(comm.Parameters, "@JMTOTSQFT", this.JMTOTSQFT.Value);

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

				this.JMRECORD.setValue(dr["JMRECORD"].ToString());
				this.JMDWELL.setValue(dr["JMDWELL"].ToString());
				this.JMSKETCH.setValue(dr["JMSKETCH"].ToString());
				this.JMSTORY.setValue(dr["JMSTORY"].ToString());
				this.JMSTORYEX.setValue(dr["JMSTORYEX"].ToString());
				this.JMSCALE.setValue(dr["JMSCALE"].ToString());
				this.JMTOTSQFT.setValue(dr["JMTOTSQFT"].ToString());

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
				sb.Append(RESketchMaster.allFieldNamesActual);
				sb.Append(" ) ");
				sb.Append("values( ");
				sb.Append(this.JMRECORD.ToString());
				sb.Append(", ");
				sb.Append(this.JMDWELL.ToString());
				sb.Append(", ");
				sb.Append("'" + this.JMSKETCH.Text + "'");
				sb.Append(", ");
				sb.Append(this.JMSTORY.ToString());
				sb.Append(", ");
				sb.Append("'" + this.JMSTORYEX.Text + "'");
				sb.Append(", ");
				sb.Append(this.JMSCALE.ToString());
				sb.Append(", ");
				sb.Append(this.JMTOTSQFT.ToString());

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
				sb.Append("JMRECORD = " + this.JMRECORD.ToString());
				sb.Append(", ");
				sb.Append("JMDWELL = " + this.JMDWELL.ToString());
				sb.Append(", ");
				sb.Append("JMSKETCH = '" + this.JMSKETCH.Text + "'");
				sb.Append(", ");
				sb.Append("JMSTORY = " + this.JMSTORY.ToString());
				sb.Append(", ");
				sb.Append("JMSTORYEX = '" + this.JMSTORYEX.Text + "'");
				sb.Append(", ");
				sb.Append("JMSCALE = " + this.JMSCALE.ToString());
				sb.Append(", ");
				sb.Append("JMTOTSQFT = " + this.JMTOTSQFT.ToString());

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

			StringBuilder sb = new StringBuilder();

			if (!"".Equals(this.localityPrefix))
			{
				// Delete all lines first
				sb.Append("delete from ");
				sb.Append(this.dataBase);
				sb.Append(this.db.SeparatorCharacter);
				sb.Append(localityPrefix);
				sb.Append("LINE where JLRECORD = ");
				sb.Append(this.Record.ToString());
				sb.Append(" and JLDWELL = ");
				sb.Append(this.Card.ToString());
				int delLineCount = this.db.ExecuteNonSelectStatement(sb.ToString());

				// Delete All Sections
				sb.Length = 0;
				sb.Append("delete from ");
				sb.Append(this.dataBase);
				sb.Append(this.db.SeparatorCharacter);
				sb.Append(localityPrefix);
				sb.Append("SECTION where JSRECORD = ");
				sb.Append(this.Record.ToString());
				sb.Append(" and JSDWELL = ");
				sb.Append(this.Card.ToString());
				int delSectCount = this.db.ExecuteNonSelectStatement(sb.ToString());
			}

			// Delete Master Record
			sb.Length = 0;
			sb.Append("delete from ");
			sb.Append(this.FullFileName);
			sb.Append(this.WhereClause);

			rowCount = this.db.ExecuteNonSelectStatement(sb.ToString());

			return rowCount;
		}

		public void Reset()
		{
			this.JMSKETCH.setValue("N");
			this.JMSTORY.setValue(0);
			this.JMSTORYEX.setValue("");
			this.JMSCALE.setValue(0);
			this.JMTOTSQFT.setValue(0);
		}

		#endregion Public Methods

		#region Private Methods

		#endregion Private Methods
	}
}