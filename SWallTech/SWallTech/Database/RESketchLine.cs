using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	/* C# Bean representing the following Table:
        Library  : CAMRALIB
        Table    : JSKLINE
        Created  : 11/2/2006 10:11:01 AM
        Generator: Stonewall Technologies BeanMaker 0.0.1
    */

	public class RESketchLine : IDBTable
	{
		#region Variables

		private string dataBase = "CAMRALIB";
		private string fileName = "JSKLINE";
		private string localityPrefix = "";
		private string separator = ".";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;
		public static string allFieldNamesActual = "JLRECORD,JLDWELL,JLSECT,JLLINE#,JLDIRECT,JLXLEN,JLYLEN,JLLINELEN,JLANGLE,JLPT1X,JLPT1Y,JLPT2X,JLPT2Y,JLATTACH";
		public static string allFieldNamesAdjusted = "JLRECORD,JLDWELL,JLSECT,JLLINE_NUM,JLDIRECT,JLXLEN,JLYLEN,JLLINELEN,JLANGLE,JLPT1X,JLPT1Y,JLPT2X,JLPT2Y,JLATTACH";
		public static string nonKeyFieldsActual = "JLDIRECT,JLXLEN,JLYLEN,JLLINELEN,JLANGLE,JLPT1X,JLPT1Y,JLPT2X,JLPT2Y,JLATTACH";
		public static string nonKeyFieldsAdjusted = "JLDIRECT,JLXLEN,JLYLEN,JLLINELEN,JLANGLE,JLPT1X,JLPT1Y,JLPT2X,JLPT2Y,JLATTACH";
		private string selectFields = "JLRECORD,JLDWELL,JLSECT,JLLINE# as JLLINE_NUM,JLDIRECT,JLXLEN,JLYLEN,JLLINELEN,JLANGLE,JLPT1X,JLPT1Y,JLPT2X,JLPT2Y,JLATTACH";

		// JLRECORD - Description Undefined
		// Managed by Property: Record
		private FixedDecimal JLRECORD = new FixedDecimal(7, 0);

		// JLDWELL - Description Undefined
		// Managed by Property: Card
		private FixedDecimal JLDWELL = new FixedDecimal(2, 0);

		// JLSECT - Description Undefined
		// Managed by Property: Sectionletter
		private FixedString JLSECT = new FixedString(2);

		// JLLINE_NUM - Description Undefined
		// Managed by Property: Linenumber
		private FixedDecimal JLLINE_NUM = new FixedDecimal(3, 0);

		// JLDIRECT - Description Undefined
		// Managed by Property: Directional
		private FixedString JLDIRECT = new FixedString(2);

		// JLXLEN - Description Undefined
		// Managed by Property: Xlength
		private FixedDecimal JLXLEN = new FixedDecimal(4, 1);

		// JLYLEN - Description Undefined
		// Managed by Property: Ylength
		private FixedDecimal JLYLEN = new FixedDecimal(4, 1);

		// JLLINELEN - Description Undefined
		// Managed by Property: Linelength
		private FixedDecimal JLLINELEN = new FixedDecimal(4, 1);

		// JLANGLE - Description Undefined
		// Managed by Property: Angle
		private FixedDecimal JLANGLE = new FixedDecimal(4, 1);

		// JLPT1X - Description Undefined
		// Managed by Property: Point1x
		private FixedDecimal JLPT1X = new FixedDecimal(9, 4);

		// JLPT1Y - Description Undefined
		// Managed by Property: Point1y
		private FixedDecimal JLPT1Y = new FixedDecimal(9, 4);

		// JLPT2X - Description Undefined
		// Managed by Property: Point2x
		private FixedDecimal JLPT2X = new FixedDecimal(9, 4);

		// JLPT2Y - Description Undefined
		// Managed by Property: Point2y
		private FixedDecimal JLPT2Y = new FixedDecimal(9, 4);

		// JLATTACH - Description Undefined
		// Managed by Property: Attachment
		private FixedString JLATTACH = new FixedString(2);

		#endregion Variables

		#region Constructors

		private RESketchLine()
		{
		}

		public RESketchLine(IDBAccess db)
		{
			this.db = db;
		}

		public RESketchLine(IDBAccess db, FixedDecimal JLRECORD, FixedDecimal JLDWELL, FixedString JLSECT, FixedDecimal JLLINE_NUM) : this(db)
		{
			this.JLRECORD = JLRECORD;
			this.JLDWELL = JLDWELL;
			this.JLSECT = JLSECT;
			this.JLLINE_NUM = JLLINE_NUM;

			this.populate();
		}

		public RESketchLine(IDBAccess db, string library, string localityPrefix, int record, int card, string sectionLetter, int lineNumber)
			: this(db)
		{
			this.dataBase = library;
			this.LocalityPrefix = localityPrefix;

			//this.FileName = localityPrefix + "LINE";
			this.JLRECORD.setValue(record);
			this.JLDWELL.setValue(card);
			this.JLSECT.setValue(sectionLetter);
			this.JLLINE_NUM.setValue(lineNumber);
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
				this.fileName = value + "LINE";
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
				sb.Append(" JLRECORD = " + this.JLRECORD.ToString());
				sb.Append(" and ");
				sb.Append(" JLDWELL = " + this.JLDWELL.ToString());
				sb.Append(" and ");
				sb.Append(" JLSECT = '" + this.JLSECT.ToString() + "'");
				sb.Append(" and ");
				sb.Append(" JLLINE_NUM = " + this.JLLINE_NUM.ToString());

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
				sb.Append(" JLRECORD = @JLRECORD ");
				sb.Append(" and ");
				sb.Append(" JLDWELL = @JLDWELL ");
				sb.Append(" and ");
				sb.Append(" JLSECT = @JLSECT ");
				sb.Append(" and ");
				sb.Append(" JLLINE_NUM = @JLLINE_NUM ");

				sb.Append(" ");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLRECORD
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
				return this.JLRECORD;
			}

			set
			{
				if (this.JLRECORD.checkValue(value))
				{
					this.JLRECORD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Record Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLDWELL
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
				return this.JLDWELL;
			}

			set
			{
				if (this.JLDWELL.checkValue(value))
				{
					this.JLDWELL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Card Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLSECT
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
				return this.JLSECT;
			}

			set
			{
				if (this.JLSECT.checkValue(value))
				{
					this.JLSECT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Sectionletter Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLLINE_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(3,0)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Linenumber
		{
			get
			{
				return this.JLLINE_NUM;
			}

			set
			{
				if (this.JLLINE_NUM.checkValue(value))
				{
					this.JLLINE_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Linenumber Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLDIRECT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Directional
		{
			get
			{
				return this.JLDIRECT;
			}

			set
			{
				if (this.JLDIRECT.checkValue(value))
				{
					this.JLDIRECT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Directional Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLXLEN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(4,1)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Xlength
		{
			get
			{
				return this.JLXLEN;
			}

			set
			{
				if (this.JLXLEN.checkValue(value))
				{
					this.JLXLEN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Xlength Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLYLEN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(4,1)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Ylength
		{
			get
			{
				return this.JLYLEN;
			}

			set
			{
				if (this.JLYLEN.checkValue(value))
				{
					this.JLYLEN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Ylength Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLLINELEN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(4,1)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Linelength
		{
			get
			{
				return this.JLLINELEN;
			}

			set
			{
				if (this.JLLINELEN.checkValue(value))
				{
					this.JLLINELEN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Linelength Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLANGLE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(4,1)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Angle
		{
			get
			{
				return this.JLANGLE;
			}

			set
			{
				if (this.JLANGLE.checkValue(value))
				{
					this.JLANGLE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Angle Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLPT1X
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(9,4)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Point1x
		{
			get
			{
				return this.JLPT1X;
			}

			set
			{
				if (this.JLPT1X.checkValue(value))
				{
					this.JLPT1X.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Point1x Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLPT1Y
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(9,4)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Point1y
		{
			get
			{
				return this.JLPT1Y;
			}

			set
			{
				if (this.JLPT1Y.checkValue(value))
				{
					this.JLPT1Y.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Point1y Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLPT2X
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(9,4)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Point2x
		{
			get
			{
				return this.JLPT2X;
			}

			set
			{
				if (this.JLPT2X.checkValue(value))
				{
					this.JLPT2X.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Point2x Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLPT2Y
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as DECIMAL(9,4)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Point2y
		{
			get
			{
				return this.JLPT2Y;
			}

			set
			{
				if (this.JLPT2Y.checkValue(value))
				{
					this.JLPT2Y.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Point2y Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLATTACH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: Description Undefined</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Attachment
		{
			get
			{
				return this.JLATTACH;
			}

			set
			{
				if (this.JLATTACH.checkValue(value))
				{
					this.JLATTACH.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Attachment Property.");
				}
			}
		}

		#endregion Properties

		#region Public Static Methods

		/// <summary>
		/// Builds a parameterized string for Updating the file.
		/// </summary>
		/// <param name="QualifiedDatabaseAndTableName">The qualified database and Table name for the update.</param>
		/// <example>string sql = RESketchLine.ParameterizedUpdateSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedUpdateSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("update ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" set ");
			string[] updFieldsActual = RESketchLine.nonKeyFieldsActual.Split(new char[] { ',' });
			string[] updFieldsAdjusted = RESketchLine.nonKeyFieldsAdjusted.Split(new char[] { ',' });
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
		/// <example>string sql = RESketchLine.ParameterizedInsertSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedInsertSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("insert into ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" (");
			sb.Append(RESketchLine.allFieldNamesActual);
			sb.Append(") ");
			sb.Append("values( ");
			string[] insFields = RESketchLine.allFieldNamesAdjusted.Split(new char[] { ',' });
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
			IDataParameter parm_JLRECORD = db.CreateParameter("@JLRECORD", DatabaseConstants.DataTypes.Numeric, "JLRECORD", 7, 0);
			parms.Add(parm_JLRECORD);
			IDataParameter parm_JLDWELL = db.CreateParameter("@JLDWELL", DatabaseConstants.DataTypes.Numeric, "JLDWELL", 2, 0);
			parms.Add(parm_JLDWELL);
			IDataParameter parm_JLSECT = db.CreateParameter("@JLSECT", DatabaseConstants.DataTypes.Char, "JLSECT", 2, 0);
			parms.Add(parm_JLSECT);
			IDataParameter parm_JLLINE_NUM = db.CreateParameter("@JLLINE_NUM", DatabaseConstants.DataTypes.Numeric, "JLLINE#", 3, 0);
			parms.Add(parm_JLLINE_NUM);
			IDataParameter parm_JLDIRECT = db.CreateParameter("@JLDIRECT", DatabaseConstants.DataTypes.Char, "JLDIRECT", 2, 0);
			parms.Add(parm_JLDIRECT);
			IDataParameter parm_JLXLEN = db.CreateParameter("@JLXLEN", DatabaseConstants.DataTypes.Numeric, "JLXLEN", 4, 1);
			parms.Add(parm_JLXLEN);
			IDataParameter parm_JLYLEN = db.CreateParameter("@JLYLEN", DatabaseConstants.DataTypes.Numeric, "JLYLEN", 4, 1);
			parms.Add(parm_JLYLEN);
			IDataParameter parm_JLLINELEN = db.CreateParameter("@JLLINELEN", DatabaseConstants.DataTypes.Numeric, "JLLINELEN", 4, 1);
			parms.Add(parm_JLLINELEN);
			IDataParameter parm_JLANGLE = db.CreateParameter("@JLANGLE", DatabaseConstants.DataTypes.Numeric, "JLANGLE", 4, 1);
			parms.Add(parm_JLANGLE);
			IDataParameter parm_JLPT1X = db.CreateParameter("@JLPT1X", DatabaseConstants.DataTypes.Numeric, "JLPT1X", 9, 4);
			parms.Add(parm_JLPT1X);
			IDataParameter parm_JLPT1Y = db.CreateParameter("@JLPT1Y", DatabaseConstants.DataTypes.Numeric, "JLPT1Y", 9, 4);
			parms.Add(parm_JLPT1Y);
			IDataParameter parm_JLPT2X = db.CreateParameter("@JLPT2X", DatabaseConstants.DataTypes.Numeric, "JLPT2X", 9, 4);
			parms.Add(parm_JLPT2X);
			IDataParameter parm_JLPT2Y = db.CreateParameter("@JLPT2Y", DatabaseConstants.DataTypes.Numeric, "JLPT2Y", 9, 4);
			parms.Add(parm_JLPT2Y);
			IDataParameter parm_JLATTACH = db.CreateParameter("@JLATTACH", DatabaseConstants.DataTypes.Char, "JLATTACH", 2, 0);
			parms.Add(parm_JLATTACH);

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
				this.db.SetParameterValue(comm.Parameters, "@JLRECORD", this.JLRECORD.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLDWELL", this.JLDWELL.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLSECT", this.JLSECT.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLLINE_NUM", this.JLLINE_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLDIRECT", this.JLDIRECT.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLXLEN", this.JLXLEN.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLYLEN", this.JLYLEN.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLLINELEN", this.JLLINELEN.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLANGLE", this.JLANGLE.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLPT1X", this.JLPT1X.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLPT1Y", this.JLPT1Y.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLPT2X", this.JLPT2X.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLPT2Y", this.JLPT2Y.Value);
				this.db.SetParameterValue(comm.Parameters, "@JLATTACH", this.JLATTACH.Value);

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

				this.JLRECORD.setValue(dr["JLRECORD"].ToString());
				this.JLDWELL.setValue(dr["JLDWELL"].ToString());
				this.JLSECT.setValue(dr["JLSECT"].ToString());
				this.JLLINE_NUM.setValue(dr["JLLINE_NUM"].ToString());
				this.JLDIRECT.setValue(dr["JLDIRECT"].ToString());
				this.JLXLEN.setValue(dr["JLXLEN"].ToString());
				this.JLYLEN.setValue(dr["JLYLEN"].ToString());
				this.JLLINELEN.setValue(dr["JLLINELEN"].ToString());
				this.JLANGLE.setValue(dr["JLANGLE"].ToString());
				this.JLPT1X.setValue(dr["JLPT1X"].ToString());
				this.JLPT1Y.setValue(dr["JLPT1Y"].ToString());
				this.JLPT2X.setValue(dr["JLPT2X"].ToString());
				this.JLPT2Y.setValue(dr["JLPT2Y"].ToString());
				this.JLATTACH.setValue(dr["JLATTACH"].ToString());

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
				sb.Append(RESketchLine.allFieldNamesActual);
				sb.Append(" ) ");
				sb.Append("values( ");
				sb.Append(this.JLRECORD.ToString());
				sb.Append(", ");
				sb.Append(this.JLDWELL.ToString());
				sb.Append(", ");
				sb.Append("'" + this.JLSECT.Text + "'");
				sb.Append(", ");
				sb.Append(this.JLLINE_NUM.ToString());
				sb.Append(", ");
				sb.Append("'" + this.JLDIRECT.Text + "'");
				sb.Append(", ");
				sb.Append(this.JLXLEN.ToString());
				sb.Append(", ");
				sb.Append(this.JLYLEN.ToString());
				sb.Append(", ");
				sb.Append(this.JLLINELEN.ToString());
				sb.Append(", ");
				sb.Append(this.JLANGLE.ToString());
				sb.Append(", ");
				sb.Append(this.JLPT1X.ToString());
				sb.Append(", ");
				sb.Append(this.JLPT1Y.ToString());
				sb.Append(", ");
				sb.Append(this.JLPT2X.ToString());
				sb.Append(", ");
				sb.Append(this.JLPT2Y.ToString());
				sb.Append(", ");
				sb.Append("'" + this.JLATTACH.Text + "'");

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
				sb.Append("JLRECORD = " + this.JLRECORD.ToString());
				sb.Append(", ");
				sb.Append("JLDWELL = " + this.JLDWELL.ToString());
				sb.Append(", ");
				sb.Append("JLSECT = '" + this.JLSECT.Text + "'");
				sb.Append(", ");
				sb.Append("JLLINE# = " + this.JLLINE_NUM.ToString());
				sb.Append(", ");
				sb.Append("JLDIRECT = '" + this.JLDIRECT.Text + "'");
				sb.Append(", ");
				sb.Append("JLXLEN = " + this.JLXLEN.ToString());
				sb.Append(", ");
				sb.Append("JLYLEN = " + this.JLYLEN.ToString());
				sb.Append(", ");
				sb.Append("JLLINELEN = " + this.JLLINELEN.ToString());
				sb.Append(", ");
				sb.Append("JLANGLE = " + this.JLANGLE.ToString());
				sb.Append(", ");
				sb.Append("JLPT1X = " + this.JLPT1X.ToString());
				sb.Append(", ");
				sb.Append("JLPT1Y = " + this.JLPT1Y.ToString());
				sb.Append(", ");
				sb.Append("JLPT2X = " + this.JLPT2X.ToString());
				sb.Append(", ");
				sb.Append("JLPT2Y = " + this.JLPT2Y.ToString());
				sb.Append(", ");
				sb.Append("JLATTACH = '" + this.JLATTACH.Text + "'");

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