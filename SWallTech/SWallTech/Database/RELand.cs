using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	[Serializable]
	public class RELand : IDBTable
	{
		#region Variables

		// LID - Record Id Code
		private FixedString LID = new FixedString(1);

		// LRECNO - Record Number
		private FixedDecimal LRECNO = new FixedDecimal(7, 0);

		// LDWELL - Dwelling No
		private FixedDecimal LDWELL = new FixedDecimal(2, 0);

		// LSEQNO - Sequence No
		private FixedDecimal LSEQNO = new FixedDecimal(2, 0);

		// LACCOD - Acreage Type Code
		private FixedDecimal LACCOD = new FixedDecimal(3, 0);

		// LHS - Homesite Code
		private FixedString LHS = new FixedString(1);

		// LACRE - No. Acres
		private FixedString LACRE = new FixedString(9);

		// LVALUE - Land Value
		private FixedDecimal LVALUE = new FixedDecimal(8, 0);

		// LLP - Lump Sum/ Per Acre
		private FixedString LLP = new FixedString(1);

		// LADJ - Adjustment Percent
		private FixedDecimal LADJ = new FixedDecimal(3, 2);

		// LACRE# - No. Acres Numeric
		private FixedDecimal LACRE_Num = new FixedDecimal(11, 5);

		// LTOTAL - Total Value
		private FixedDecimal LTOTAL = new FixedDecimal(8, 0);

		// LDESCR - Additional Description
		private FixedString LDESCR = new FixedString(20);

		// LWATER - Water Code
		private FixedDecimal LWATER = new FixedDecimal(2, 0);

		// LSEWER - Sewer Code
		private FixedDecimal LSEWER = new FixedDecimal(2, 0);

		// LUTIL - Utility Value
		private FixedDecimal LUTIL = new FixedDecimal(5, 0);

		private string dataBase = "CAMRALIB";
		private string fileName = "CAFPLAND";
		public static string allFieldNamesAdjustedSelect = "LID,LRECNO,LDWELL,LSEQNO,LACCOD,LHS,LACRE,LVALUE,LLP,LADJ,LACRE# as LACRE_Num,LTOTAL,LDESCR,LWATER,LSEWER,LUTIL";
		public static string allFieldNamesAdjusted = "LID,LRECNO,LDWELL,LSEQNO,LACCOD,LHS,LACRE,LVALUE,LLP,LADJ,LACRE_Num,LTOTAL,LDESCR,LWATER,LSEWER,LUTIL";
		public static string allFieldNamesActual = "LID,LRECNO,LDWELL,LSEQNO,LACCOD,LHS,LACRE,LVALUE,LLP,LADJ,LACRE#,LTOTAL,LDESCR,LWATER,LSEWER,LUTIL";
		public static string keyFields = "LRECNO,LDWELL,LSEQNO";
		public static string nonKeyFieldsActual = "LID,LACCOD,LHS,LACRE,LVALUE,LLP,LADJ,LACRE#,LTOTAL,LDESCR,LWATER,LSEWER,LUTIL";
		public static string nonKeyFieldsAdjusted = "LID,LACCOD,LHS,LACRE,LVALUE,LLP,LADJ,LACRE_Num,LTOTAL,LDESCR,LWATER,LSEWER,LUTIL";
		private string separator = ".";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;

		#endregion Variables

		#region Constructors

		private RELand()
		{
		}

		public RELand(IDBAccess db)
		{
			this.db = db;
		}

		public RELand(IDBAccess db, FixedDecimal lrecno, FixedDecimal ldwell, FixedDecimal lseqno) : this(db)
		{
			this.LRECNO = lrecno;
			this.LDWELL = ldwell;
			this.LSEQNO = lseqno;
			this.populate();
		}

		public RELand(IDBAccess db, string library, string localityPrefix, int record, int card, int seq)
			: this(db)
		{
			this.dataBase = library;
			this.FileName = localityPrefix + "LAND";
			this.LRECNO.setValue(record);
			this.LDWELL.setValue(card);
			this.LSEQNO.setValue(seq);
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

		/// <summary>
		/// Gets or sets the DataBase Field - LID
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Record Id Code</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Lid
		{
			get
			{
				return this.LID;
			}

			set
			{
				if (this.LID.checkValue(value))
				{
					this.LID.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Lid Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LRECNO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(7,0)
		/// <para>Description: Record Number</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Lrecno
		{
			get
			{
				return this.LRECNO;
			}

			set
			{
				if (this.LRECNO.checkValue(value))
				{
					this.LRECNO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Lrecno Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LDWELL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(2,0)
		/// <para>Description: Dwelling No</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Ldwell
		{
			get
			{
				return this.LDWELL;
			}

			set
			{
				if (this.LDWELL.checkValue(value))
				{
					this.LDWELL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Ldwell Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LSEQNO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(2,0)
		/// <para>Description: Sequence No</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Lseqno
		{
			get
			{
				return this.LSEQNO;
			}

			set
			{
				if (this.LSEQNO.checkValue(value))
				{
					this.LSEQNO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Lseqno Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LACCOD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(3,0)
		/// <para>Description: Acreage Type Code</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Laccod
		{
			get
			{
				return this.LACCOD;
			}

			set
			{
				if (this.LACCOD.checkValue(value))
				{
					this.LACCOD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Laccod Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LHS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Homesite Code</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Lhs
		{
			get
			{
				return this.LHS;
			}

			set
			{
				if (this.LHS.checkValue(value))
				{
					this.LHS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Lhs Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LACRE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(9)
		/// <para>Description: No. Acres</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Lacre
		{
			get
			{
				return this.LACRE;
			}

			set
			{
				if (this.LACRE.checkValue(value))
				{
					this.LACRE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Lacre Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LVALUE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(8,0)
		/// <para>Description: Land Value</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Lvalue
		{
			get
			{
				return this.LVALUE;
			}

			set
			{
				if (this.LVALUE.checkValue(value))
				{
					this.LVALUE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Lvalue Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LLP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Lump Sum/ Per Acre</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Llp
		{
			get
			{
				return this.LLP;
			}

			set
			{
				if (this.LLP.checkValue(value))
				{
					this.LLP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Llp Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LADJ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(3,2)
		/// <para>Description: Adjustment Percent</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Ladj
		{
			get
			{
				return this.LADJ;
			}

			set
			{
				if (this.LADJ.checkValue(value))
				{
					this.LADJ.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Ladj Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LACRE#
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(11,5)
		/// <para>Description: No. Acres Numeric</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Lacre_num
		{
			get
			{
				return this.LACRE_Num;
			}

			set
			{
				if (this.LACRE_Num.checkValue(value))
				{
					this.LACRE_Num.setValue(value);
					string ac = this.LACRE_Num.toString(false, true);
					this.LACRE.Text = ac.Substring(0, ac.Length - 2);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Lacre_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LTOTAL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(8,0)
		/// <para>Description: Total Value</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Ltotal
		{
			get
			{
				return this.LTOTAL;
			}

			set
			{
				if (this.LTOTAL.checkValue(value))
				{
					this.LTOTAL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Ltotal Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LDESCR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(20)
		/// <para>Description: Additional Description</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Ldescr
		{
			get
			{
				return this.LDESCR;
			}

			set
			{
				if (this.LDESCR.checkValue(value))
				{
					this.LDESCR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Ldescr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LWATER
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(2,0)
		/// <para>Description: Water Code</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Lwater
		{
			get
			{
				return this.LWATER;
			}

			set
			{
				if (this.LWATER.checkValue(value))
				{
					this.LWATER.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Lwater Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LSEWER
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(2,0)
		/// <para>Description: Sewer Code</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Lsewer
		{
			get
			{
				return this.LSEWER;
			}

			set
			{
				if (this.LSEWER.checkValue(value))
				{
					this.LSEWER.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Lsewer Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - LUTIL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(5,0)
		/// <para>Description: Utility Value</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Lutil
		{
			get
			{
				return this.LUTIL;
			}

			set
			{
				if (this.LUTIL.checkValue(value))
				{
					this.LUTIL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Lutil Property.");
				}
			}
		}

		private string WhereClause
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(" where ");
				sb.Append("LRECNO = " + this.LRECNO.ToString());
				sb.Append(" and ");
				sb.Append("LDWELL = " + this.LDWELL.ToString());
				sb.Append(" and ");
				sb.Append("LSEQNO = " + this.LSEQNO.ToString());
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
				sb.Append("LRECNO = @LRECNO");
				sb.Append(" and ");
				sb.Append("LDWELL = @LDWELL");
				sb.Append(" and ");
				sb.Append("LSEQNO = @LSEQNO");
				sb.Append(" ");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Builds a parameterized string for Updating the file.
		/// </summary>
		/// <param name="QualifiedDatabaseAndTableName">The qualified database and Table name for the update.</param>
		/// <example>string sql = REImprovement.ParameterizedUpdateSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedUpdateSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("update ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" set ");
			string[] updFieldsActual = RELand.nonKeyFieldsActual.Split(new char[] { ',' });
			string[] updFieldsAdjusted = RELand.nonKeyFieldsAdjusted.Split(new char[] { ',' });
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
		/// <example>string sql = REImprovement.ParameterizedInsertSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedInsertSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("insert into ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" (");
			sb.Append(RELand.allFieldNamesActual);
			sb.Append(") ");
			sb.Append("values( ");
			string[] insFields = RELand.allFieldNamesAdjusted.Split(new char[] { ',' });
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
			IDataParameter parm_LID = db.CreateParameter("@LID", DatabaseConstants.DataTypes.Char, "IID", 1);
			parms.Add(parm_LID);
			IDataParameter parm_LRECNO = db.CreateParameter("@LRECNO", DatabaseConstants.DataTypes.Numeric, "LRECNO", 7, 0);
			parms.Add(parm_LRECNO);
			IDataParameter parm_LDWELL = db.CreateParameter("@LDWELL", DatabaseConstants.DataTypes.Numeric, "LDWELL", 2, 0);
			parms.Add(parm_LDWELL);
			IDataParameter parm_LSEQNO = db.CreateParameter("@LSEQNO", DatabaseConstants.DataTypes.Numeric, "LSEQNO", 2, 0);
			parms.Add(parm_LSEQNO);
			IDataParameter parm_LACCOD = db.CreateParameter("@LACCOD", DatabaseConstants.DataTypes.Numeric, "LACCOD", 3, 0);
			parms.Add(parm_LACCOD);
			IDataParameter parm_LHS = db.CreateParameter("@LHS", DatabaseConstants.DataTypes.Char, "LHS", 1);
			parms.Add(parm_LHS);
			IDataParameter parm_LACRE = db.CreateParameter("@LACRE", DatabaseConstants.DataTypes.Char, "LACRE", 9);
			parms.Add(parm_LACRE);
			IDataParameter parm_LVALUE = db.CreateParameter("@LVALUE", DatabaseConstants.DataTypes.Numeric, "LVALUE", 8, 0);
			parms.Add(parm_LVALUE);
			IDataParameter parm_LLP = db.CreateParameter("@LLP", DatabaseConstants.DataTypes.Char, "LLP", 1);
			parms.Add(parm_LLP);
			IDataParameter parm_LADJ = db.CreateParameter("@LADJ", DatabaseConstants.DataTypes.Numeric, "LADJ", 3, 2);
			parms.Add(parm_LADJ);
			IDataParameter parm_LACRE_Num = db.CreateParameter("@LACRE_Num", DatabaseConstants.DataTypes.Numeric, "LACRE#", 11, 5);
			parms.Add(parm_LACRE_Num);
			IDataParameter parm_LTOTAL = db.CreateParameter("@LTOTAL", DatabaseConstants.DataTypes.Numeric, "LTOTAL", 8, 0);
			parms.Add(parm_LTOTAL);
			IDataParameter parm_LDESCR = db.CreateParameter("@LDESCR", DatabaseConstants.DataTypes.Char, "LDESCR", 20);
			parms.Add(parm_LDESCR);
			IDataParameter parm_LWATER = db.CreateParameter("@LWATER", DatabaseConstants.DataTypes.Numeric, "LWATER", 2, 0);
			parms.Add(parm_LWATER);
			IDataParameter parm_LSEWER = db.CreateParameter("@LSEWER", DatabaseConstants.DataTypes.Numeric, "LSEWER", 2, 0);
			parms.Add(parm_LSEWER);
			IDataParameter parm_LUTIL = db.CreateParameter("@LUTIL", DatabaseConstants.DataTypes.Numeric, "LUTIL", 5, 0);
			parms.Add(parm_LUTIL);

			return parms;
		}

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
				this.db.SetParameterValue(comm.Parameters, "@LID", this.LID.Value);
				this.db.SetParameterValue(comm.Parameters, "@LRECNO", this.LRECNO.Value);
				this.db.SetParameterValue(comm.Parameters, "@LDWELL", this.LDWELL.Value);
				this.db.SetParameterValue(comm.Parameters, "@LSEQNO", this.LSEQNO.Value);
				this.db.SetParameterValue(comm.Parameters, "@LACCOD", this.LACCOD.Value);
				this.db.SetParameterValue(comm.Parameters, "@LHS", this.LHS.Value);
				this.db.SetParameterValue(comm.Parameters, "@LACRE", this.LACRE_Num.Value);
				this.db.SetParameterValue(comm.Parameters, "@LVALUE", this.LVALUE.Value);
				this.db.SetParameterValue(comm.Parameters, "@LLP", this.LLP.Value);
				this.db.SetParameterValue(comm.Parameters, "@LADJ", this.LADJ.Value);
				this.db.SetParameterValue(comm.Parameters, "@LACRE_Num", this.LACRE_Num.Value);
				this.db.SetParameterValue(comm.Parameters, "@LTOTAL", this.LTOTAL.Value);
				this.db.SetParameterValue(comm.Parameters, "@LDESCR", this.LDESCR.Value);
				this.db.SetParameterValue(comm.Parameters, "@LWATER", this.LWATER.Value);
				this.db.SetParameterValue(comm.Parameters, "@LSEWER", this.LSEWER.Value);
				this.db.SetParameterValue(comm.Parameters, "@LUTIL", this.LUTIL.Value);

				rowCount = comm.ExecuteNonQuery();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
			}
			return rowCount;
		}

		#endregion Properties

		#region Public Methods

		/// <summary>
		/// Populates the instance properties with data from the database table based on the
		/// current key settings.
		/// </summary>
		public bool populate()
		{
			return this.getTableData();
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
				sb.Append("LID = '" + this.LID.Text + "'");
				sb.Append(", ");
				sb.Append("LACCOD = " + this.LACCOD.ToString());
				sb.Append(", ");
				sb.Append("LHS = '" + this.LHS.Text + "'");
				sb.Append(", ");
				sb.Append("LACRE = '" + this.LACRE.Text + "'");
				sb.Append(", ");
				sb.Append("LVALUE = " + this.LVALUE.ToString());
				sb.Append(", ");
				sb.Append("LLP = '" + this.LLP.Text + "'");
				sb.Append(", ");
				sb.Append("LADJ = " + this.LADJ.ToString());
				sb.Append(", ");
				sb.Append("LACRE# = " + this.LACRE_Num.ToString());
				sb.Append(", ");
				sb.Append("LTOTAL = " + this.LTOTAL.ToString());
				sb.Append(", ");
				sb.Append("LDESCR = '" + this.LDESCR.Text + "'");
				sb.Append(", ");
				sb.Append("LWATER = " + this.LWATER.ToString());
				sb.Append(", ");
				sb.Append("LSEWER = " + this.LSEWER.ToString());
				sb.Append(", ");
				sb.Append("LUTIL = " + this.LUTIL.ToString());
				sb.Append(this.WhereClause);
				/*
                sb.Append( " where " );
                sb.Append( "LRECNO = " + this.LRECNO.ToString() );
                sb.Append( " and " );
                sb.Append( "LDWELL = " + this.LDWELL.ToString() );
                sb.Append( " and " );
                sb.Append( "LSEQNO = " + this.LSEQNO.ToString() );
                */

				string cmd = sb.ToString().ToUpper();
				rowCount = this.db.ExecuteNonSelectStatement(cmd);
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return rowCount;
		}

		/// <summary>
		/// Inserts a record into the database table using all current property values.
		/// </summary>
		///<returns>The number of rows inserted.</returns>
		public int insert()
		{
			if ("".Equals(this.LID.Text.Trim()))
			{
				this.LID.Text = "L";
			}
			this.lastException = null;
			int rowCount = -1;
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("insert into ");
				sb.Append(this.FullFileName);
				sb.Append(" (");
				sb.Append(RELand.allFieldNamesActual);
				sb.Append(") ");
				sb.Append("values( ");
				sb.Append("'" + this.LID.Text + "'");
				sb.Append(", ");
				sb.Append(this.LRECNO.ToString());
				sb.Append(", ");
				sb.Append(this.LDWELL.ToString());
				sb.Append(", ");
				sb.Append(this.LSEQNO.ToString());
				sb.Append(", ");
				sb.Append(this.LACCOD.ToString());
				sb.Append(", ");
				sb.Append("'" + this.LHS.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.LACRE.Text + "'");
				sb.Append(", ");
				sb.Append(this.LVALUE.ToString());
				sb.Append(", ");
				sb.Append("'" + this.LLP.Text + "'");
				sb.Append(", ");
				sb.Append(this.LADJ.ToString());
				sb.Append(", ");
				sb.Append(this.LACRE_Num.ToString());
				sb.Append(", ");
				sb.Append(this.LTOTAL.ToString());
				sb.Append(", ");
				sb.Append("'" + this.LDESCR.Text + "'");
				sb.Append(", ");
				sb.Append(this.LWATER.ToString());
				sb.Append(", ");
				sb.Append(this.LSEWER.ToString());
				sb.Append(", ");
				sb.Append(this.LUTIL.ToString());
				sb.Append(" )");

				string cmd = sb.ToString().ToUpper();
				rowCount = this.db.ExecuteNonSelectStatement(cmd);
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return rowCount;
		}

		/// <summary>
		/// Sets all necessary fields to blank to allow CAMRA to delete the record.
		/// This is the preferred method of deleting land and improvements in CAMRA.
		/// </summary>
		/// <returns>Number of rows affected.</returns>
		public int delete()
		{
			this.LACCOD.setValue(0);
			this.LHS.Text = "";
			this.LACRE.Text = "";
			this.LVALUE.setValue(0);
			this.LLP.Text = "";
			this.LADJ.setValue(0);
			this.LACRE_Num.setValue(0);
			this.LDESCR.Text = "";
			this.LWATER.setValue(0);
			this.LSEWER.setValue(0);
			return this.update();
		}

		/// <summary>
		/// Deletes from the database table all records
		/// with the current key settings.
		/// </summary>
		///<returns>The number of rows deleted.</returns>
		public int DeleteForReal()
		{
			this.lastException = null;
			int rowCount = -1;
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("delete from ");
				sb.Append(this.FullFileName);
				sb.Append(this.WhereClause);
				/*
                sb.Append(" where ");
                sb.Append( "LRECNO = " + this.LRECNO.ToString() );
                sb.Append( " and " );
                sb.Append( "LDWELL = " + this.LDWELL.ToString() );
                sb.Append( " and " );
                sb.Append( "LSEQNO = " + this.LSEQNO.ToString() );
                */
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

		private bool getTableData()
		{
			bool isOK = false;
			this.lastException = null;
			try
			{
				StringBuilder sb = new StringBuilder();

				// Add code here to read table
				sb.Append("Select ");
				sb.Append(RELand.allFieldNamesAdjustedSelect);
				sb.Append(" from ");
				sb.Append(this.FullFileName);
				sb.Append(this.WhereClause);
				/*
                sb.Append(" where ");
                sb.Append("LRECNO = " + this.LRECNO.ToString());
                sb.Append(" and ");
                sb.Append("LDWELL = " + this.LDWELL.ToString());
                sb.Append(" and ");
                sb.Append("LSEQNO = " + this.LSEQNO.ToString());
                */
				string cmd = sb.ToString();
				rs = this.db.RunSelectStatement(cmd);
				dt = rs.Tables[0];
				dr = dt.Rows[0];

				// Add code here to populate variables
				this.LID.Text = (string)dr["LID"];
				this.LACCOD.setValue(dr["LACCOD"].ToString());
				this.LHS.Text = (string)dr["LHS"];
				this.LACRE.Text = (string)dr["LACRE"];
				this.LVALUE.setValue(dr["LVALUE"].ToString());
				this.LLP.Text = (string)dr["LLP"];
				this.LADJ.setValue(dr["LADJ"].ToString());
				this.LACRE_Num.setValue(dr["LACRE_Num"].ToString());
				this.LTOTAL.setValue(dr["LTOTAL"].ToString());
				this.LDESCR.Text = (string)dr["LDESCR"];
				this.LWATER.setValue(dr["LWATER"].ToString());
				this.LSEWER.setValue(dr["LSEWER"].ToString());
				this.LUTIL.setValue(dr["LUTIL"].ToString());

				isOK = true;
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return isOK;
		}

		#endregion Private Methods
	}
}