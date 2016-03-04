using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SWallTech
{
	/// <summary>
	/// An IDBAccess implementation for Sql Server 2000 and later.
	/// </summary>
	public class SqlServerDBAccess : IDBAccess, IDisposable
	{
		#region Variables

		private string dataSource;
		private int port;
		private string dataBase;
		private string userID;
		private string password;
		private string securityType;

		private string myConString;
		private bool isConnected;

		private DataSet results;
		private Exception lastError;

		private SqlConnection myCon;
		private SqlCommand command;
		private SqlException lastDBError;
		private SqlDataAdapter da;
		private SqlDataReader reader;

		private Hashtable errorStrings;
		private bool useIntegratedSecurity;

		#endregion Variables

		#region Constructors/Destructors

		private SqlServerDBAccess()
		{
		}

		/// <summary>
		/// Contructs a new SqlServerDBAccess instance based on the passed parameters.
		/// </summary>
		/// <remarks>This Constructor will implement SecurityType "SSPI" (Windows Integrated Security) automatically.</remarks>
		/// <param name="datasource">The desired DataSource, such as an IP address.  To specify a
		/// particular PORT on an IP address, append the IP address with <em>:1234</em> where "1234"
		/// indicates the specific PORT number.  If no PORT is specified, the default SqlServer
		/// PORT will be used.</param>
		/// <param name="database">The default database name for this connection. <b>Optional</b></param>
		/// <param name="userID">The user ID for this connection.</param>
		/// <param name="password">The user ID's password for this connection.</param>
		public SqlServerDBAccess(string datasource, string database, string userid, string password) :
			this(datasource, database, userid, password, true)
		{
			/* replaced by alternate constructor call
			 * 			this.errorStrings = new Hashtable();

						string[] ipPort = datasource.Split( new char[':'] );
						this.dataSource = ipPort[0];
						if ( ipPort.Length > 1 )
						{
							try
							{
								this.Port = Convert.ToInt32( ipPort[1] );
							}
							catch ( System.Exception)
							{
								this.Port = 0 ;
							}
						}
						this.dataBase = database ;
						this.userID = userid ;
						this.password = password ;
						this.useIntegratedSecurity = true ;
						this.SecurityType = "SSPI" ;
						this.connect();
			*/
		}

		/// <summary>
		/// Contructs a new SqlServerDBAccess instance based on the passed parameters.
		/// </summary>
		/// <param name="datasource">The desired DataSource, such as an IP address.  To specify a
		/// particular PORT on an IP address, append the IP address with <em>:1234</em> where "1234"
		/// indicates the specific PORT number.  If no PORT is specified, the default SqlServer
		/// PORT will be used.</param>
		/// <param name="database">The default database name for this connection. <b>Optional</b></param>
		/// <param name="userID">The user ID for this connection.</param>
		/// <param name="password">The user ID's password for this connection.</param>
		/// <param name="integratedSecurity">Indicates whether or not to use "SSPI" security for the connection.</param>
		public SqlServerDBAccess(string datasource, string database, string userid, string password, bool integratedSecurity)
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
				catch (System.Exception ex)
				{
					Console.WriteLine(string.Format("{0}", ex.Message));
					this.Port = 0;
				}
			}
			this.dataSource = datasource;
			this.dataBase = database;
			this.userID = userid;
			this.password = password;
			this.useIntegratedSecurity = integratedSecurity;
			if (this.useIntegratedSecurity)
			{
				this.SecurityType = "SSPI";
			}
			else
			{
				this.SecurityType = "";
			}
			this.connect();
		}

		/// <summary>
		/// Contructs a new SqlServerDBAccess instance based on the passed parameters.
		/// </summary>
		/// <param name="datasource">The desired DataSource, such as an IP address.  To specify a
		/// particular PORT on an IP address, append the IP address with <em>:1234</em> where "1234"
		/// indicates the specific PORT number.  If no PORT is specified, the default SqlServer
		/// PORT will be used.</param>
		/// <param name="database">The default database name for this connection. <b>Optional</b></param>
		/// <param name="userID">The user ID for this connection.</param>
		/// <param name="password">The user ID's password for this connection.</param>
		/// <param name="securityType">The security type for the connection.</param>
		public SqlServerDBAccess(string datasource, string database, string userid, string password, string securityType)
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
				catch (System.Exception ex)
				{
					Console.WriteLine(string.Format("{0}", ex.Message));
					this.Port = 0;
				}
			}
			this.dataSource = datasource;
			this.dataBase = database;
			this.userID = userid;
			this.password = password;
			if (securityType != null)
			{
				this.SecurityType = securityType;
			}
			else
			{
				this.SecurityType = "";
			}
			this.connect();
		}

		~SqlServerDBAccess()
		{
			try
			{
				this.myCon.Close();
			}
			catch (System.Exception)
			{
			}
		}

		#endregion Constructors/Destructors

		#region IDBAccess Members

		/// <summary>
		/// Closes the current IDBAccess instance and connection.
		/// </summary>
		public void Close()
		{
			this.myCon.Close();
		}

		/// <summary>
		/// Attempt to connect to the database.
		/// </summary>
		/// <returns>TRUE if the connection was successful, FALSE if it was not.</returns>
		public bool connect()
		{
			this.resetErrors();

			this.isConnected = false;
			this.myCon = null;
			this.myConString = "server=" + this.dataSource;
			if (this.Port > 0)
			{
				this.myConString += ";port=" + this.port;
			}
			this.myConString += ";database=" + this.dataBase;
			if (this.SecurityType != "")
			{
				this.myConString += ";Integrated Security=" + this.SecurityType;
			}
			else
			{
				this.myConString += ";uid=" + this.userID;
				this.myConString += ";pwd=" + this.password;
			}

			try
			{
				this.myCon = new SqlConnection(this.myConString);
				this.myCon.Open();
				this.isConnected = true;
			}
			catch (SqlException dbErr)
			{
				this.lastDBError = dbErr;
				this.setErrorStrings();
			}
			catch (System.Exception err)
			{
				this.lastError = err;
			}

			return this.isConnected;
		}

		/// <summary>
		/// Runs the specified SQL <em>Select</em> statement on the current database connection.
		/// </summary>
		/// <param name="query">The SQL <em>Select</em> statement to run.</param>
		/// <returns>A DataSet containing the results.</returns>
		public DataSet RunSelectStatement(string query)
		{
			this.resetErrors();

			this.results = null;
			try
			{
				this.command = new SqlCommand(query, this.myCon);
				this.command.CommandTimeout = 0;
				da = new SqlDataAdapter();
				da.SelectCommand = this.command;
				this.results = new DataSet("Sql_Server");
				da.Fill(this.results, "Sql_Server_Table");
			}
			catch (SqlException dbErr)
			{
				this.lastDBError = dbErr;
				this.setErrorStrings();
			}
			catch (System.Exception err)
			{
				this.lastError = err;
			}

			return this.results;
		}

		/// <summary>
		/// Executes the specified SQL statement on the current database connection.  Statements can be
		/// anything other than a <em>Select</em> statement.
		/// </summary>
		/// <param name="query">The SQL statement to run.</param>
		/// <returns>The number of rows affected.  For <em>Update</em>, <em>Insert</em>, and <em>Delete</em>
		/// statements this value should be greater thean -1.  Other statemens, such as <em>Create Table</em>
		/// will return either -1 or 0 based on the specific database implementation.</returns>
		public int ExecuteNonSelectStatement(string query)
		{
			this.resetErrors();

			int numAffected = 0;
			try
			{
				this.command = new SqlCommand(query, this.myCon);
				this.command.CommandTimeout = 0;
				numAffected = this.command.ExecuteNonQuery();
			}
			catch (SqlException dbErr)
			{
				this.lastDBError = dbErr;
				this.setErrorStrings();
				numAffected = -1;
			}
			catch (System.Exception err)
			{
				this.lastError = err;
				numAffected = -1;
			}

			return numAffected;
		}

		/// <summary>
		/// Retrieves an IDataReader object for the current connection.  DataReaders
		/// are forward only, active connection objects.  Faster than DataSets, but they
		/// operate exclusively in a connected mode.  ALWAYS close a DataReader as quickly
		/// as possible.
		/// </summary>
		/// <param name="SQL">The SQL statement to run.</param>
		/// <returns>An IDataReader object.</returns>
		public IDataReader getDataReader(string SQL)
		{
			try
			{
				if (!this.reader.IsClosed)
				{
					this.reader.Close();
				}
			}
			catch (System.NullReferenceException nex)
			{
				Console.WriteLine(string.Format("{0}", nex.Message));
			}

			this.reader = null;
			if (this.isConnected)
			{
				try
				{
					this.command = new SqlCommand(SQL, this.myCon);
					this.reader = this.command.ExecuteReader();
				}
				catch (System.Exception ex)
				{
					this.lastError = ex;
				}
			}
			return this.reader;
		}

		/// <summary>
		/// Retrieves the error string for a particular piece of information in a database error.
		/// </summary>
		/// <remarks>
		/// <example>
		/// <code>
		/// string errorMessage = dbAccess.getDBErrorData( "source" );
		/// </code>
		/// </example>
		/// Supported error strings:
		/// <list type="bullet">
		///  <item>
		///  <description>message</description>
		///  </item>
		///  <item>
		///  <description>number</description>
		///  </item>
		///  <item>
		///  <description>source</description>
		///  </item>
		///  <item>
		///  <description>stacktrace</description>
		///  </item>
		///  <item>
		///  <description>state</description>
		///  </item>
		/// </list>
		/// </remarks>
		/// <param name="s">The name of the error information you wish to retrieve.</param>
		/// <returns>The specific error information requested, if available.</returns>
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

		/// <summary>
		/// Retrieves the value of the first column of the first row of an SQL statement.
		/// Scalar's provide better performance for aggregates and columnar functions.
		/// </summary>
		/// <param name="SQL">The SQL statement to execute.</param>
		/// <returns>An object representing the column return value. (Must be cast to appropriate result type)
		/// </returns>
		public object ExecuteScalar(string query)
		{
			this.resetErrors();

			object retValue = null;

			try
			{
				this.command = new SqlCommand(query, this.myCon);
				this.command.CommandTimeout = 0;
				retValue = this.command.ExecuteScalar();
			}
			catch (SqlException dbErr)
			{
				this.lastDBError = dbErr;
				this.setErrorStrings();
			}
			catch (System.Exception err)
			{
				this.lastError = err;
			}

			return retValue;
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

		/// <summary>
		/// The port of the connection.
		/// </summary>
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

		/// <summary>
		/// The database of the connection.
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
		/// The Separator Character for this database connection
		/// </summary>
		public string SeparatorCharacter
		{
			get
			{
				return "..";
			}
		}

		/// <summary>
		/// The user ID of the connection.
		/// </summary>
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

		/// <summary>
		/// The password of the connection. (Write-only)
		/// </summary>
		public string Password
		{
			set
			{
				this.password = value;
			}
		}

		/// <summary>
		/// The Security Type of the connection.
		/// </summary>
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
		/// The last non-Database specific Exception object. (Read-only)
		/// </summary>
		public Exception LastError
		{
			get
			{
				return this.lastError;
			}
		}

		/// <summary>
		/// An IDictionary listing of the Database specific error fields. (Read-only)
		/// </summary>
		/// <remarks>The HashTable of string keys/object values for error message details.
		/// The value object types are typically strings but may vary depending on their generating types.
		/// Exposed strings are documented in <see cref="getDBErrorData"/>.
		/// </remarks>
		/// <seealso cref="SWallTech.PostgreSQLManager.PostgreSQLDBAccess.getDBErrorData"></seealso>
		public IDictionary LastDBErrorInformation
		{
			get
			{
				return this.errorStrings;
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
		/// Creates a Command object from the current Connection.  Ideal for parameterized queries.
		/// </summary>
		/// <param name="query">The SQL statement. For parameterized queries, prefix the parameter location with the "@" symbol.</param>
		/// <returns>IDbCommand object, type specific to the current DB Connection.</returns>
		public IDbCommand CreateCommand(string query)
		{
			return new SqlCommand(query, this.myCon);
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

		/// <summary>
		/// Creates a Parameter object, used to add to the Command object Parameter collection.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.  Names are prefixed by the "@" symbol.</param>
		/// <param name="dataType">The dataType of the parameter.</param>
		/// <param name="columnName">The database column name of the parameter.</param>
		/// <param name="precision">Precision: for decimal and numeric fields.</param>
		/// <param name="scale">Scale: for decimal and numeric fields.</param>
		/// <returns>IDataParameter object, type specific to the current DB Connection.</returns>
		public IDataParameter CreateParameter(string parameterName, DatabaseConstants.DataTypes dataType, string columnName, byte precision, byte scale)
		{
			bool isPrecisionNull = (precision == Byte.MinValue);
			bool isScaleNull = (!isPrecisionNull && scale == Byte.MinValue);

			SqlParameter parm = new SqlParameter();
			parm.ParameterName = parameterName;
			parm.SourceColumn = columnName;
			switch (dataType)
			{
				case DatabaseConstants.DataTypes.BigInt:
					parm.SqlDbType = SqlDbType.BigInt;
					break;

				case DatabaseConstants.DataTypes.Binary:
				case DatabaseConstants.DataTypes.Blob:
					parm.SqlDbType = SqlDbType.Binary;
					break;

				case DatabaseConstants.DataTypes.Char:
					parm.SqlDbType = SqlDbType.Char;
					if (isPrecisionNull || precision == 0)
					{
						throw new FormatException("The parameter data type requires a length.");
					}
					else
					{
						parm.Size = precision;
					}
					break;

				case DatabaseConstants.DataTypes.Date:
				case DatabaseConstants.DataTypes.DateTime:
				case DatabaseConstants.DataTypes.Time:
					parm.SqlDbType = SqlDbType.DateTime;
					break;

				case DatabaseConstants.DataTypes.Decimal:
				case DatabaseConstants.DataTypes.Numeric:
					parm.SqlDbType = SqlDbType.Decimal;
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
					break;

				case DatabaseConstants.DataTypes.Double:
					parm.SqlDbType = SqlDbType.Float;
					break;

				case DatabaseConstants.DataTypes.Integer:
					parm.SqlDbType = SqlDbType.Int;
					break;

				case DatabaseConstants.DataTypes.Real:
					parm.SqlDbType = SqlDbType.Real;
					break;

				case DatabaseConstants.DataTypes.SmallInt:
					parm.SqlDbType = SqlDbType.SmallInt;
					break;

				case DatabaseConstants.DataTypes.TinyInt:
					parm.SqlDbType = SqlDbType.TinyInt;
					break;

				case DatabaseConstants.DataTypes.VarChar:
					parm.SqlDbType = SqlDbType.VarChar;
					if (isPrecisionNull || precision == 0)
					{
						throw new FormatException("The parameter data type requires a length.");
					}
					else
					{
						parm.Size = precision;
					}
					break;

				default:
					break;
			}

			return parm;
		}

		public IDataParameterCollection SetParameterValue(IDataParameterCollection coll, string parameterName, object value)
		{
			SqlParameterCollection parms = (SqlParameterCollection)coll;
			parms[parameterName].Value = value;
			return parms;
		}

		#endregion IDBAccess Members

		#region Implementation specific methods

		/// <summary>
		/// <b>Deprecated.</b> The last non-database specific error message. (Read-only)
		/// </summary>
		/// <remarks><b>Deprecated.</b> Use <see cref="getDBErrorData"/> instead.</remarks>
		/// <seealso cref="SWallTech.PostgreSQLManager.PostgreSQLDBAccess.getDBErrorData"></seealso>
		public string LastErrorMessage
		{
			get
			{
				string errMessage;
				if (this.lastError == null)
				{
					errMessage = null;
				}
				else
				{
					errMessage = this.lastError.Message;
				}
				return errMessage;
			}
		}

		/// <summary>
		/// <b>Deprecated.</b> The last error source. (Read-only)
		/// </summary>
		/// <remarks><b>Deprecated.</b> Use <see cref="getDBErrorData"/> instead.</remarks>
		/// <seealso cref="SWallTech.PostgreSQLManager.PostgreSQLDBAccess.getDBErrorData"></seealso>
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

		/// <summary>
		/// <b>Deprecated.</b> The last database specific error message. (Read-only)
		/// </summary>
		/// <remarks><b>Deprecated.</b> Use <see cref="getDBErrorData"/> instead.</remarks>
		/// <seealso cref="SWallTech.PostgreSQLManager.PostgreSQLDBAccess.getDBErrorData"></seealso>
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

		/// <summary>
		/// <b>Deprecated.</b> The last error number. (Read-only)
		/// </summary>
		/// <remarks><b>Deprecated.</b> Use <see cref="getDBErrorData"/> instead.</remarks>
		/// <seealso cref="SWallTech.PostgreSQLManager.PostgreSQLDBAccess.getDBErrorData"></seealso>
		public int LastDBErrorNumber
		{
			get
			{
				int message = -1;
				if (this.lastDBError != null)
				{
					message = this.lastDBError.Number;
				}
				return message;
			}
		}

		/// <summary>
		/// <b>Deprecated.</b> The last error state. (Read-only)
		/// </summary>
		/// <remarks><b>Deprecated.</b> Use <see cref="getDBErrorData"/> instead.</remarks>
		/// <seealso cref="SWallTech.PostgreSQLManager.PostgreSQLDBAccess.getDBErrorData"></seealso>
		public byte LastDBErrorState
		{
			get
			{
				byte message = 0;
				if (this.lastDBError != null)
				{
					message = this.lastDBError.State;
				}
				return message;
			}
		}

		/// <summary>
		/// <b>Deprecated.</b> The database specific error message stack trace. (Read-only)
		/// </summary>
		/// <remarks><b>Deprecated.</b> Use <see cref="getDBErrorData"/> instead.</remarks>
		/// <seealso cref="SWallTech.PostgreSQLManager.PostgreSQLDBAccess.getDBErrorData"></seealso>
		public string LastDBErrorStackTrace
		{
			get
			{
				string message = null;
				if (this.lastDBError != null)
				{
					message = this.lastDBError.StackTrace;
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
			this.errorStrings.Add("state", this.lastDBError.State.ToString());
			this.errorStrings.Add("number", this.lastDBError.Number.ToString());
		}

		#endregion private methods

		public void Dispose()
		{
			if (command != null)
			{
				command.Dispose();
			}

			if (da != null)
			{
				da.Dispose();
			}
			if (myCon != null)
			{
				myCon.Dispose();
			}
			if (results != null)
			{
				results.Dispose();
			}
		}
	}
}