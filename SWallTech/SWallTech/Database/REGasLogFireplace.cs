using System;
using System.Data;
using System.Text;

namespace SWallTech
{
	public class REGasLogFireplace : IDBTable
	{
		#region Variables

		// GRECNO - Parcel Record#
		private FixedDecimal GRECNO = new FixedDecimal(7, 0);

		// GDWELL - Parcel Dwelling#
		private FixedDecimal GDWELL = new FixedDecimal(2, 0);

		// GNOGAS - No Of Gas Logs
		private FixedDecimal GNOGAS = new FixedDecimal(2, 0);

		private string dataBase = "CAMRALIB";
		private string fileName = "CAFPGASLG";
		private string separator = ".";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;

		#endregion Variables

		#region Constructors

		private REGasLogFireplace()
		{
		}

		public REGasLogFireplace(IDBAccess db)
		{
			this.db = db;
		}

		public REGasLogFireplace(IDBAccess db, FixedDecimal grecno, FixedDecimal gdwell) : this(db)
		{
			this.GRECNO = grecno;
			this.GDWELL = gdwell;
			this.populate();
		}

		public REGasLogFireplace(IDBAccess db, string library, string localityPrefix, int record, int card)
			: this(db)
		{
			this.dataBase = library;
			this.FileName = localityPrefix + "GASLG";
			this.GRECNO.setValue(record);
			this.GDWELL.setValue(card);
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
		/// Gets or sets the DataBase Field - GRECNO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(7,0)
		/// <para>Description: Parcel Record#</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Grecno
		{
			get
			{
				return this.GRECNO;
			}

			set
			{
				if (this.GRECNO.checkValue(value))
				{
					this.GRECNO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Grecno Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - GDWELL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(2,0)
		/// <para>Description: Parcel Dwelling#</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Gdwell
		{
			get
			{
				return this.GDWELL;
			}

			set
			{
				if (this.GDWELL.checkValue(value))
				{
					this.GDWELL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Gdwell Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - GNOGAS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as SIGNED(2,0)
		/// <para>Description: No Of Gas Logs</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Gnogas
		{
			get
			{
				return this.GNOGAS;
			}

			set
			{
				if (this.GNOGAS.checkValue(value))
				{
					this.GNOGAS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Gnogas Property.");
				}
			}
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
				sb.Append("GNOGAS = " + this.GNOGAS.ToString());
				sb.Append(" where ");
				sb.Append("GRECNO = " + this.GRECNO.ToString());
				sb.Append(" and ");
				sb.Append("GDWELL = " + this.GDWELL.ToString());

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
				sb.Append(" (GRECNO,GDWELL,GNOGAS) ");
				sb.Append("values( ");
				sb.Append(this.GRECNO.ToString());
				sb.Append(", ");
				sb.Append(this.GDWELL.ToString());
				sb.Append(", ");
				sb.Append(this.GNOGAS.ToString());
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
		/// Deletes from the database table all records /// with the current key settings.
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
				sb.Append(" where ");
				sb.Append("GRECNO = " + this.GRECNO.ToString());
				sb.Append(" and ");
				sb.Append("GDWELL = " + this.GDWELL.ToString());

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
				sb.Append("Select * from ");
				sb.Append(this.FullFileName);
				sb.Append(" where ");
				sb.Append("GRECNO = " + this.GRECNO.ToString());
				sb.Append(" and ");
				sb.Append("GDWELL = " + this.GDWELL.ToString());

				string cmd = sb.ToString();
				rs = this.db.RunSelectStatement(cmd);
				dt = rs.Tables[0];
				dr = dt.Rows[0];

				// Add code here to populate variables
				this.GNOGAS.setValue(dr["GNOGAS"].ToString());

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