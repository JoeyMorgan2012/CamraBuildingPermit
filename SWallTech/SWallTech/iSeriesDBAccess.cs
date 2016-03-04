using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using IBM.Data.DB2.iSeries;

namespace SWallTech
{
	/// <summary>
	/// An IDBAccess implementation for IBM iSeries DB2 V4R5 or later.
	/// </summary>
	/// <remarks><para>Requires the IBM.Data.DB2.iSeries .NET Managed Provider.
	/// <para>Incorporated into the SWallTech unified namespace.
	/// </para><para>JMM 01-07-2016</para>
	/// Installed with iSeries Access V5R3.</para>
	/// <para>As of December 2015, we will only be writing code to the version 7.1 DLL, file version 13.0.0.2, client version V7R1M0
	/// </para><para>JMM 12-8-2015</para>
	/// </remarks>
	public class iSeriesDBAccess : IDBAccess
	{
		#region Variables

		private iDB2Command command;
		private iDB2DataAdapter da;
		private string dataBase;
		private string dataSource;
		private Hashtable errorStrings;
		private bool isConnected;
		private iDB2Exception lastDBError;
		private Exception lastError;
		private iDB2Connection myCon;
		private string myConString;
		private string password;
		private int port;
		private iDB2DataReader reader;
		private DataSet results;
		private string securityType;
		private string userID;

		#endregion Variables

		#region Constructors/Destructors

		/// <summary>
		/// Constructs a new iSeriesDBAccess instance based on the passed parameters.
		/// </summary>
		/// <param name="datasource">The desired DataSource, such as an IP address.  To specify a
		/// particular PORT on an IP address, append the IP address with <em>:1234</em> where "1234"
		/// indicates the specific PORT number.  If no PORT is specified, the default iSeries DB2
		/// PORT will be used.</param>
		/// <param name="userID">The user ID for this connection.</param>
		/// <param name="password">The user ID's password for this connection.</param>
		public iSeriesDBAccess(string datasource, string userid, string password)
		{
			this.errorStrings = new Hashtable();

			string[] ipPort = datasource.Split(new char[':']);
			this.dataSource = ipPort[0];
			if (ipPort.Length > 1)
			{
				try
				{
					this.Port = Convert.ToInt32(ipPort[1]);
				}
				catch (System.Exception)
				{
					this.Port = 0;
				}
			}

			this.userID = userid;
			this.password = password;

			this.connect();
		}

		public iSeriesDBAccess()
		{
		}

		/*
        ~iSeriesDBAccess()
		{
			try
			{
				this.myCon.Close();
			}
			catch ( System.Exception)
			{
			}
		}
         */

		#endregion Constructors/Destructors

		#region IDBAccess Members

		/// <summary>
		/// Returns the current Connection object for direct usage. (Read only).
		/// </summary>
		public IDbConnection Connection
		{
			get
			{
				return this.myCon;
			}
		}

		/// <summary>
		/// <b>Not Implemented.</b>The database of the connection.
		/// </summary>
		/// <remarks>This property can be used to store a value for DataBase, but it currently
		/// has no bearing on Connections or SQL statements.</remarks>
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
		/// The datasource of the connection, such as an IP address or ODBC DSN name.
		/// </summary>
		public string DataSource
		{
			get
			{
				return this.dataSource;
			}

			set
			{
				this.dataSource = value;
			}
		}

		// Properties
		/// <summary>
		/// The connection state of the instance. (Read-only)
		/// </summary>
		public bool IsConnected
		{
			get
			{
				return this.isConnected;
			}
		}

		/// <summary>
		/// The last Database specific Exception object. (Read-only)
		/// </summary>
		public Exception LastDBError
		{
			get
			{
				return this.lastDBError;
			}
		}

		/// <summary>
		/// Returns the database specific error message type. (Read-only)
		/// </summary>
		public string LastDBErrorExceptionType
		{
			get
			{
				string message = null;
				if (this.lastDBError != null)
				{
					message = this.lastDBError.GetType().ToString();
				}
				return message;
			}
		}

		public IDictionary LastDBErrorInformation
		{
			get
			{
				return this.errorStrings;
			}
		}

		public Exception LastError
		{
			get
			{
				return this.lastError;
			}
		}

		public string Password
		{
			set
			{
				this.password = value;
			}
		}

		public int Port
		{
			get
			{
				return this.port;
			}

			set
			{
				this.port = value;
			}
		}

		public string SecurityType
		{
			get
			{
				return this.securityType;
			}

			set
			{
				this.securityType = value;
			}
		}

		public string SeparatorCharacter
		{
			get
			{
				return ".";
			}
		}

		public string UserID
		{
			get
			{
				return this.userID;
			}

			set
			{
				this.userID = value;
			}
		}

		public void Close()
		{
			try
			{
				this.myCon.Close();
			}
			catch (System.ObjectDisposedException)
			{
			}
		}

		public bool connect()
		{
			this.resetErrors();

			this.isConnected = false;
			this.myCon = null;
			this.myConString = "DataSource=" + this.dataSource;
			if (this.Port > 0)
			{
				this.myConString += ";port=" + this.port;
			}
			this.myConString += ";UserID=" + this.userID;
			this.myConString += ";Password=" + this.password;

			try
			{
				this.myCon = new iDB2Connection(this.myConString);
				this.myCon.Open();
				this.isConnected = true;
			}
			catch (iDB2DCFunctionErrorException dcex)
			{
				Console.WriteLine(string.Format("Error occurred in {0}, in procedure {1}: \n Error: {2}", MethodBase.GetCurrentMethod().Module, MethodBase.GetCurrentMethod().Name, dcex.Message));
				this.lastDBError = dcex;
				this.setErrorStrings();
				throw;
			}
			catch (iDB2SQLErrorException dbSqlErr)
			{
				Console.WriteLine(string.Format("Error occurred in {0}, in procedure {1}: \n Error: {2}", MethodBase.GetCurrentMethod().Module, MethodBase.GetCurrentMethod().Name, dbSqlErr.Message));
				this.lastDBError = dbSqlErr;
				this.setErrorStrings();
				throw;
			}
			catch (iDB2Exception dbErr)
			{
				Console.WriteLine(string.Format("Error occurred in {0}, in procedure {1}: \n Error: {2}", MethodBase.GetCurrentMethod().Module, MethodBase.GetCurrentMethod().Name, dbErr.Message));
				this.lastDBError = dbErr;
				this.setErrorStrings();

				throw;
			}
			catch (System.Exception err)
			{
				Console.WriteLine(string.Format("Error occurred in {0}, in procedure {1}: \n Error: {2}", MethodBase.GetCurrentMethod().Module, MethodBase.GetCurrentMethod().Name, err.Message));
				this.lastError = err;
				throw;
			}

			return this.isConnected;
		}

		/// <summary>
		/// Creates a Command object from the current Connection.  Ideal for parameterized queries.
		/// </summary>
		/// <param name="query">The SQL statement. For parameterized queries, prefix the parameter location with the "@" symbol.</param>
		/// <returns>IDbCommand object, type specific to the current DB Connection.</returns>
		public IDbCommand CreateCommand(string query)
		{
			return new iDB2Command(query, this.myCon);
		}

		/// <summary>
		/// Creates a Parameter object, used to add to the Command object Parameter collection.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.  Names are prefixed by the "@" symbol.</param>
		/// <param name="dataType">The dataType of the parameter.</param>
		/// <param name="columnName">The database column name of the parameter.</param>
		/// <returns>IDataParameter object, type specific to the current DB Connection.</returns>
		public IDataParameter CreateParameter(string parameterName, DatabaseConstants.DataTypes dataType, string columnName)
		{
			return this.CreateParameter(parameterName, dataType, columnName, Byte.MinValue, Byte.MinValue);
		}

		/// <summary>
		/// Creates a Parameter object, used to add to the Command object Parameter collection.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.  Names are prefixed by the "@" symbol.</param>
		/// <param name="dataType">The dataType of the parameter.</param>
		/// <param name="columnName">The database column name of the parameter.</param>
		/// <param name="size">Length: for char data fields</param>
		/// <returns>IDataParameter object, type specific to the current DB Connection.</returns>
		public IDataParameter CreateParameter(string parameterName, DatabaseConstants.DataTypes dataType, string columnName, byte size)
		{
			return this.CreateParameter(parameterName, dataType, columnName, size, Byte.MinValue);
		}

		//TODO: Simplify this if you have time. JMM
		public IDataParameter CreateParameter(string parameterName, DatabaseConstants.DataTypes dataType, string columnName, byte precision, byte scale)
		{
			bool isPrecisionNull = (precision == Byte.MinValue);
			bool isScaleNull = (!isPrecisionNull && scale == Byte.MinValue);

			iDB2Parameter parm = new iDB2Parameter();
			parm.ParameterName = parameterName;
			parm.SourceColumn = columnName;
			parm.SourceColumnNullMapping = false;
			switch (dataType)
			{
				case DatabaseConstants.DataTypes.BigInt:
					parm.iDB2DbType = iDB2DbType.iDB2BigInt;
					parm.Value = 0;
					break;

				case DatabaseConstants.DataTypes.Binary:
				case DatabaseConstants.DataTypes.Blob:
					parm.iDB2DbType = iDB2DbType.iDB2Binary;
					break;

				case DatabaseConstants.DataTypes.Char:
					parm.iDB2DbType = iDB2DbType.iDB2Char;
					if (isPrecisionNull || precision == 0)
					{
						throw new FormatException("The parameter data type requires a length.");
					}
					else
					{
						parm.Size = precision;
					}
					parm.Value = "";
					break;

				case DatabaseConstants.DataTypes.Date:
					parm.iDB2DbType = iDB2DbType.iDB2Date;
					break;

				case DatabaseConstants.DataTypes.Decimal:
					parm.iDB2DbType = iDB2DbType.iDB2Decimal;
					if (isPrecisionNull || precision == 0)
					{
						throw new FormatException("The parameter data type requires a precision value.");
					}
					else
					{
						parm.Precision = precision;
					}
					if (isPrecisionNull || precision < scale)
					{
						throw new FormatException("The parameter data type requires a scale value less than or equal to the scale.");
					}
					else
					{
						parm.Scale = scale;
					}
					parm.Value = 0;
					break;

				case DatabaseConstants.DataTypes.Double:
					parm.iDB2DbType = iDB2DbType.iDB2Double;
					parm.Value = 0;
					break;

				case DatabaseConstants.DataTypes.Integer:
					parm.iDB2DbType = iDB2DbType.iDB2Integer;
					parm.Value = 0;
					break;

				case DatabaseConstants.DataTypes.Numeric:
					parm.iDB2DbType = iDB2DbType.iDB2Numeric;
					if (isPrecisionNull || precision == 0)
					{
						throw new FormatException("The parameter data type requires a precision value.");
					}
					else
					{
						parm.Precision = precision;
					}
					if (isPrecisionNull || precision < scale)
					{
						throw new FormatException("The parameter data type requires a scale value less than or equal to the scale.");
					}
					else
					{
						parm.Scale = scale;
					}
					parm.Value = 0;
					break;

				case DatabaseConstants.DataTypes.Real:
					parm.iDB2DbType = iDB2DbType.iDB2Real;
					parm.Value = 0;
					break;

				case DatabaseConstants.DataTypes.SmallInt:
				case DatabaseConstants.DataTypes.TinyInt:
					parm.iDB2DbType = iDB2DbType.iDB2SmallInt;
					parm.Value = 0;
					break;

				case DatabaseConstants.DataTypes.Time:
					parm.iDB2DbType = iDB2DbType.iDB2Time;
					break;

				case DatabaseConstants.DataTypes.Timestamp:
				case DatabaseConstants.DataTypes.DateTime:
					parm.iDB2DbType = iDB2DbType.iDB2TimeStamp;
					break;

				case DatabaseConstants.DataTypes.VarChar:
					parm.iDB2DbType = iDB2DbType.iDB2VarChar;
					if (isPrecisionNull || precision == 0)
					{
						throw new FormatException("The parameter data type requires a length.");
					}
					else
					{
						parm.Size = precision;
					}
					parm.Value = "";
					break;

				default:
					break;
			}

			return parm;
		}

		public int ExecuteNonSelectStatement(string query)
		{
			this.resetErrors();

			int numAffected = 0;
			try
			{
				this.command = new iDB2Command(query, this.myCon);
				this.command.CommandTimeout = 0;
				numAffected = this.command.ExecuteNonQuery();
			}
			catch (iDB2Exception dbErr)
			{
				this.lastDBError = dbErr;
				this.setErrorStrings();
				numAffected = -1;
				throw;
			}
			catch (System.Exception err)
			{
				this.lastError = err;
				numAffected = -1;
				throw;
			}

			return numAffected;
		}

		public object ExecuteScalar(string query)
		{
			this.resetErrors();

			object retValue = null;

			try
			{
				this.command = new iDB2Command(query, this.myCon);
				this.command.CommandTimeout = 0;
				retValue = this.command.ExecuteScalar();
			}
			catch (iDB2Exception dbErr)
			{
				this.lastDBError = dbErr;
				this.setErrorStrings();
				throw;
			}
			catch (System.Exception err)
			{
				this.lastError = err;
				throw;
			}

			return retValue;
		}

		public IDataReader getDataReader(string SQL)
		{
			try
			{
				if (reader != null && !this.reader.IsClosed)
				{
					this.reader.Close();
				}
			}
			catch (System.NullReferenceException)
			{
			}

			this.reader = null;
			if (this.isConnected)
			{
				try
				{
					this.command = new iDB2Command(SQL, this.myCon);
					this.reader = this.command.ExecuteReader();
				}
				catch (iDB2Exception dbErr)
				{
					this.lastDBError = dbErr;
					this.setErrorStrings();
					throw;
				}
				catch (System.Exception ex)
				{
					this.lastError = ex;
					throw;
				}
			}
			return this.reader;
		}

		public string getDBErrorData(string s)
		{
			s = s.ToLower();
			string msg = "";
			if (this.errorStrings != null)
			{
				if (this.errorStrings.ContainsKey(s))
				{
					msg = (string)this.errorStrings[s];
				}
			}
			return msg;
		}

		public DataSet RunSelectStatement(string query)
		{
			this.resetErrors();

			this.results = null;

			try
			{
				this.command = new iDB2Command(query, this.myCon);
				this.command.CommandTimeout = 0;
				da = new iDB2DataAdapter();
				da.SelectCommand = this.command;
				this.results = new DataSet("iSeries");
				da.Fill(this.results, "iSeries_Table");
			}
			catch (iDB2Exception dbErr)
			{
				this.lastDBError = dbErr;
				this.setErrorStrings();
				throw;
			}
			catch (System.Exception err)
			{
				this.lastError = err;
				throw;
			}

			return this.results;
		}

		public IDataParameterCollection SetParameterValue(IDataParameterCollection coll, string parameterName, object value)
		{
			iDB2ParameterCollection parms = (iDB2ParameterCollection)coll;

			parms[parameterName].Value = value;

			return parms;
		}

		#endregion IDBAccess Members

		#region Implementation specific methods

		public IBMException IBMExceptionInfo;

		public string LastDBErrorMessage
		{
			get
			{
				string message = null;
				if (this.lastDBError != null)
				{
					message = this.lastDBError.Message;
				}
				return message;
			}
		}

		public string LastDBErrorMessageCode
		{
			get
			{
				string message = null;
				if (this.lastDBError != null)
				{
					message = this.lastDBError.MessageCode.ToString();
				}
				return message;
			}
		}

		public string LastDBErrorMessageDetails
		{
			get
			{
				string message = null;
				if (this.lastDBError != null)
				{
					message = this.lastDBError.MessageDetails;
				}
				return message;
			}
		}

		public string LastDBErrorSource
		{
			get
			{
				string message = null;
				if (this.lastDBError != null)
				{
					message = this.lastDBError.Source;
				}
				return message;
			}
		}

		public string LastDBErrorSQLState
		{
			get
			{
				string message = null;
				if (this.lastDBError != null)
				{
					message = this.lastDBError.SqlState;
				}
				return message;
			}
		}

		#endregion Implementation specific methods

		#region private methods

		private void resetErrors()
		{
			this.lastError = null;
			this.lastDBError = null;
			this.errorStrings.Clear();
		}

		private void setErrorStrings()
		{
			this.errorStrings.Add("message", this.lastDBError.Message);
			this.errorStrings.Add("source", this.lastDBError.Source);
			this.errorStrings.Add("stacktrace", this.lastDBError.StackTrace);
			this.errorStrings.Add("sqlstate", this.lastDBError.SqlState);
			this.errorStrings.Add("messagecode", this.lastDBError.MessageCode.ToString());
			this.errorStrings.Add("messagedetails", this.lastDBError.MessageDetails);
		}

		#endregion private methods
	}
}