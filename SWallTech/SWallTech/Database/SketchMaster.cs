using System;
using System.Data;
using System.Text;

namespace SWallTech
{
	public class SketchMaster : IDBTable
	{
		#region Variables

		// JMRECORD -
		private FixedDecimal JMRECORD = new FixedDecimal(7, 0);

		// JMDWELL -
		private FixedDecimal JMDWELL = new FixedDecimal(2, 0);

		// JMSKETCH -
		private FixedString JMSKETCH = new FixedString(1);

		// JMSTORY -
		private FixedDecimal JMSTORY = new FixedDecimal(4, 2);

		// JMSTORYEX -
		private FixedString JMSTORYEX = new FixedString(3);

		// JMSCALE -
		private FixedDecimal JMSCALE = new FixedDecimal(5, 2);

		// JMTOTSQFT -
		private FixedDecimal JMTOTSQFT = new FixedDecimal(8, 1);

		private string dataBase = "CAMRALIB";
		private string fileName = "JSKMASTER";
		private string separator = ".";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;

		#endregion Variables

		#region Constructors

		private SketchMaster()
		{
		}

		public SketchMaster(IDBAccess db)
		{
			this.db = db;
		}

		public SketchMaster(IDBAccess db, FixedDecimal jmrecord, FixedDecimal jmdwell) : this(db)
		{
			this.JMRECORD = jmrecord;
			this.JMDWELL = jmdwell;
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
		/// Gets or sets the DataBase Field - JMRECORD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(7,0)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jmrecord
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
					throw new OverflowException("Value outside established bounds for the Jmrecord Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMDWELL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jmdwell
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
					throw new OverflowException("Value outside established bounds for the Jmdwell Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMSKETCH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Jmsketch
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
					throw new OverflowException("Value outside established bounds for the Jmsketch Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMSTORY
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(4,2)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jmstory
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
					throw new OverflowException("Value outside established bounds for the Jmstory Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMSTORYEX
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(3)
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Jmstoryex
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
					throw new OverflowException("Value outside established bounds for the Jmstoryex Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMSCALE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(5,2)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jmscale
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
					throw new OverflowException("Value outside established bounds for the Jmscale Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JMTOTSQFT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(8,1)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jmtotsqft
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
					throw new OverflowException("Value outside established bounds for the Jmtotsqft Property.");
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
				sb.Append("JMSKETCH = '" + this.JMSKETCH.Text + "'");
				sb.Append(", ");
				sb.Append("JMSTORY = " + this.JMSTORY.ToString());
				sb.Append(", ");
				sb.Append("JMSTORYEX = '" + this.JMSTORYEX.Text + "'");
				sb.Append(", ");
				sb.Append("JMSCALE = " + this.JMSCALE.ToString());
				sb.Append(", ");
				sb.Append("JMTOTSQFT = " + this.JMTOTSQFT.ToString());
				sb.Append(" where ");
				sb.Append("JMRECORD = " + this.JMRECORD.ToString());
				sb.Append(" and ");
				sb.Append("JMDWELL = " + this.JMDWELL.ToString());

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
				sb.Append(" (JMRECORD,JMDWELL,JMSKETCH,JMSTORY,JMSTORYEX,JMSCALE,JMTOTSQFT) ");
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
				sb.Append("JMRECORD = " + this.JMRECORD.ToString());
				sb.Append(" and ");
				sb.Append("JMDWELL = " + this.JMDWELL.ToString());

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
				sb.Append("JMRECORD = " + this.JMRECORD.ToString());
				sb.Append(" and ");
				sb.Append("JMDWELL = " + this.JMDWELL.ToString());

				string cmd = sb.ToString();
				rs = this.db.RunSelectStatement(cmd);
				dt = rs.Tables[0];
				dr = dt.Rows[0];

				// Add code here to populate variables
				this.JMSKETCH.Text = (string)dr["JMSKETCH"];
				this.JMSTORY.setValue(dr["JMSTORY"].ToString());
				this.JMSTORYEX.Text = (string)dr["JMSTORYEX"];
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

		#endregion Private Methods
	}
}