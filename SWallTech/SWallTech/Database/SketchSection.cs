using System;
using System.Data;
using System.Text;

namespace SWallTech
{
	public class SketchSection : IDBTable
	{
		#region Variables

		// JSRECORD -
		private FixedDecimal JSRECORD = new FixedDecimal(7, 0);

		// JSDWELL -
		private FixedDecimal JSDWELL = new FixedDecimal(2, 0);

		// JSSECT -
		private FixedString JSSECT = new FixedString(2);

		// JSTYPE -
		private FixedString JSTYPE = new FixedString(4);

		// JSSTORY -
		private FixedDecimal JSSTORY = new FixedDecimal(4, 2);

		// JSDESC -
		private FixedString JSDESC = new FixedString(35);

		// JSSKETCH -
		private FixedString JSSKETCH = new FixedString(1);

		// JSSQFT -
		private FixedDecimal JSSQFT = new FixedDecimal(8, 1);

		private string dataBase = "CAMRALIB";
		private string fileName = "JSKSECTION";
		private string separator = ".";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;

		#endregion Variables

		#region Constructors

		private SketchSection()
		{
		}

		public SketchSection(IDBAccess db)
		{
			this.db = db;
		}

		public SketchSection(IDBAccess db, FixedDecimal jsrecord, FixedDecimal jsdwell, FixedString jssect) : this(db)
		{
			this.JSRECORD = jsrecord;
			this.JSDWELL = jsdwell;
			this.JSSECT = jssect;
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
		/// Gets or sets the DataBase Field - JSRECORD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(7,0)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jsrecord
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
					throw new OverflowException("Value outside established bounds for the Jsrecord Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSDWELL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jsdwell
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
					throw new OverflowException("Value outside established bounds for the Jsdwell Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSSECT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(2)
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Jssect
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
					throw new OverflowException("Value outside established bounds for the Jssect Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSTYPE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(4)
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Jstype
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
					throw new OverflowException("Value outside established bounds for the Jstype Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSSTORY
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(4,2)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jsstory
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
					throw new OverflowException("Value outside established bounds for the Jsstory Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSDESC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(35)
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Jsdesc
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
					throw new OverflowException("Value outside established bounds for the Jsdesc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSSKETCH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Jssketch
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
					throw new OverflowException("Value outside established bounds for the Jssketch Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JSSQFT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(8,1)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jssqft
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
					throw new OverflowException("Value outside established bounds for the Jssqft Property.");
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
				sb.Append("JSTYPE = '" + this.JSTYPE.Text + "'");
				sb.Append(", ");
				sb.Append("JSSTORY = " + this.JSSTORY.ToString());
				sb.Append(", ");
				sb.Append("JSDESC = '" + this.JSDESC.Text + "'");
				sb.Append(", ");
				sb.Append("JSSKETCH = '" + this.JSSKETCH.Text + "'");
				sb.Append(", ");
				sb.Append("JSSQFT = " + this.JSSQFT.ToString());
				sb.Append(" where ");
				sb.Append("JSRECORD = " + this.JSRECORD.ToString());
				sb.Append(" and ");
				sb.Append("JSDWELL = " + this.JSDWELL.ToString());
				sb.Append(" and ");
				sb.Append("JSSECT = '" + this.JSSECT.Text + "'");

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
				sb.Append(" (JSRECORD,JSDWELL,JSSECT,JSTYPE,JSSTORY,JSDESC,JSSKETCH,JSSQFT) ");
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
				sb.Append("JSRECORD = " + this.JSRECORD.ToString());
				sb.Append(" and ");
				sb.Append("JSDWELL = " + this.JSDWELL.ToString());
				sb.Append(" and ");
				sb.Append("JSSECT = '" + this.JSSECT.Text + "'");

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
				sb.Append("JSRECORD = " + this.JSRECORD.ToString());
				sb.Append(" and ");
				sb.Append("JSDWELL = " + this.JSDWELL.ToString());
				sb.Append(" and ");
				sb.Append("JSSECT = '" + this.JSSECT.Text + "'");

				string cmd = sb.ToString();
				rs = this.db.RunSelectStatement(cmd);
				dt = rs.Tables[0];
				dr = dt.Rows[0];

				// Add code here to populate variables
				this.JSTYPE.Text = (string)dr["JSTYPE"];
				this.JSSTORY.setValue(dr["JSSTORY"].ToString());
				this.JSDESC.Text = (string)dr["JSDESC"];
				this.JSSKETCH.Text = (string)dr["JSSKETCH"];
				this.JSSQFT.setValue(dr["JSSQFT"].ToString());

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