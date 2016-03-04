using System;
using System.Data;
using System.Text;

namespace SWallTech
{
	public class SketchLine : IDBTable
	{
		#region Variables

		// JLRECORD -
		private FixedDecimal JLRECORD = new FixedDecimal(7, 0);

		// JLDWELL -
		private FixedDecimal JLDWELL = new FixedDecimal(2, 0);

		// JLSECT -
		private FixedString JLSECT = new FixedString(2);

		// JLLINE# -
		private FixedDecimal JLLINE_Num = new FixedDecimal(3, 0);

		// JLDIRECT -
		private FixedString JLDIRECT = new FixedString(2);

		// JLXLEN -
		private FixedDecimal JLXLEN = new FixedDecimal(4, 1);

		// JLYLEN -
		private FixedDecimal JLYLEN = new FixedDecimal(4, 1);

		// JLLINELEN -
		private FixedDecimal JLLINELEN = new FixedDecimal(4, 1);

		// JLANGLE -
		private FixedDecimal JLANGLE = new FixedDecimal(4, 1);

		// JLPT1X -
		private FixedDecimal JLPT1X = new FixedDecimal(9, 4);

		// JLPT1Y -
		private FixedDecimal JLPT1Y = new FixedDecimal(9, 4);

		// JLPT2X -
		private FixedDecimal JLPT2X = new FixedDecimal(9, 4);

		// JLPT2Y -
		private FixedDecimal JLPT2Y = new FixedDecimal(9, 4);

		// JLATTACH -
		private FixedString JLATTACH = new FixedString(2);

		private string dataBase = "CAMRALIB";
		private string fileName = "JSKLINE";
		private string separator = ".";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;

		#endregion Variables

		#region Constructors

		private SketchLine()
		{
		}

		public SketchLine(IDBAccess db)
		{
			this.db = db;
		}

		public SketchLine(IDBAccess db, FixedDecimal jlrecord, FixedDecimal jldwell, FixedString jlsect, FixedDecimal jlline_num) : this(db)
		{
			this.JLRECORD = jlrecord;
			this.JLDWELL = jldwell;
			this.JLSECT = jlsect;
			this.JLLINE_Num = jlline_num;
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
		/// Gets or sets the DataBase Field - JLRECORD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(7,0)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jlrecord
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
					throw new OverflowException("Value outside established bounds for the Jlrecord Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLDWELL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jldwell
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
					throw new OverflowException("Value outside established bounds for the Jldwell Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLSECT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(2)
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Jlsect
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
					throw new OverflowException("Value outside established bounds for the Jlsect Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLLINE#
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(3,0)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jlline_num
		{
			get
			{
				return this.JLLINE_Num;
			}

			set
			{
				if (this.JLLINE_Num.checkValue(value))
				{
					this.JLLINE_Num.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Jlline_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLDIRECT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(2)
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Jldirect
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
					throw new OverflowException("Value outside established bounds for the Jldirect Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLXLEN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(4,1)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jlxlen
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
					throw new OverflowException("Value outside established bounds for the Jlxlen Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLYLEN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(4,1)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jlylen
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
					throw new OverflowException("Value outside established bounds for the Jlylen Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLLINELEN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(4,1)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jllinelen
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
					throw new OverflowException("Value outside established bounds for the Jllinelen Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLANGLE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(4,1)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jlangle
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
					throw new OverflowException("Value outside established bounds for the Jlangle Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLPT1X
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(9,4)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jlpt1x
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
					throw new OverflowException("Value outside established bounds for the Jlpt1x Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLPT1Y
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(9,4)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jlpt1y
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
					throw new OverflowException("Value outside established bounds for the Jlpt1y Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLPT2X
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(9,4)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jlpt2x
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
					throw new OverflowException("Value outside established bounds for the Jlpt2x Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLPT2Y
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(9,4)
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Jlpt2y
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
					throw new OverflowException("Value outside established bounds for the Jlpt2y Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - JLATTACH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(2)
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Jlattach
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
					throw new OverflowException("Value outside established bounds for the Jlattach Property.");
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
				sb.Append(" where ");
				sb.Append("JLRECORD = " + this.JLRECORD.ToString());
				sb.Append(" and ");
				sb.Append("JLDWELL = " + this.JLDWELL.ToString());
				sb.Append(" and ");
				sb.Append("JLSECT = '" + this.JLSECT.Text + "'");
				sb.Append(" and ");
				sb.Append("JLLINE# = " + this.JLLINE_Num.ToString());

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
				sb.Append(" (JLRECORD,JLDWELL,JLSECT,JLLINE#,JLDIRECT,JLXLEN,JLYLEN,JLLINELEN,JLANGLE,JLPT1X,JLPT1Y,JLPT2X,JLPT2Y,JLATTACH) ");
				sb.Append("values( ");
				sb.Append(this.JLRECORD.ToString());
				sb.Append(", ");
				sb.Append(this.JLDWELL.ToString());
				sb.Append(", ");
				sb.Append("'" + this.JLSECT.Text + "'");
				sb.Append(", ");
				sb.Append(this.JLLINE_Num.ToString());
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
				sb.Append("JLRECORD = " + this.JLRECORD.ToString());
				sb.Append(" and ");
				sb.Append("JLDWELL = " + this.JLDWELL.ToString());
				sb.Append(" and ");
				sb.Append("JLSECT = '" + this.JLSECT.Text + "'");
				sb.Append(" and ");
				sb.Append("JLLINE# = " + this.JLLINE_Num.ToString());

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
				sb.Append("JLRECORD = " + this.JLRECORD.ToString());
				sb.Append(" and ");
				sb.Append("JLDWELL = " + this.JLDWELL.ToString());
				sb.Append(" and ");
				sb.Append("JLSECT = '" + this.JLSECT.Text + "'");
				sb.Append(" and ");
				sb.Append("JLLINE# = " + this.JLLINE_Num.ToString());

				string cmd = sb.ToString();
				rs = this.db.RunSelectStatement(cmd);
				dt = rs.Tables[0];
				dr = dt.Rows[0];

				// Add code here to populate variables
				this.JLDIRECT.Text = (string)dr["JLDIRECT"];
				this.JLXLEN.setValue(dr["JLXLEN"].ToString());
				this.JLYLEN.setValue(dr["JLYLEN"].ToString());
				this.JLLINELEN.setValue(dr["JLLINELEN"].ToString());
				this.JLANGLE.setValue(dr["JLANGLE"].ToString());
				this.JLPT1X.setValue(dr["JLPT1X"].ToString());
				this.JLPT1Y.setValue(dr["JLPT1Y"].ToString());
				this.JLPT2X.setValue(dr["JLPT2X"].ToString());
				this.JLPT2Y.setValue(dr["JLPT2Y"].ToString());
				this.JLATTACH.Text = (string)dr["JLATTACH"];

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