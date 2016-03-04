using System;
using System.Collections;
using System.Data;

namespace SWallTech
{
	/// <summary>
	/// A wrapper class for managing IDBAccess objects.  Use this manager class instead of the individual
	/// IDBAccess implementations to allow dynamic, run-time database type selection.
	/// </summary>
	public class DBAccessManager : IDBAccess, IDisposable
	{
		#region Variables

		private IDBAccess currentConnection;

		private int currentDBType;

		/// <summary>
		/// Enumerates the currently supported database types.
		/// </summary>
		public enum DatabaseTypes
		{
			// IBM UDB(DB2) for iSeries (V4R5 or later)

			iSeriesDB2,

			// MySql (4.1 or later)

			MySQL,

			// Microsoft Sql Server (2000 or later)

			SqlServer,

			// ODBC DSN (Data Source Name)

			OdbcDSN,

			// PostgreSQL (7.3 or later)

			PostgreSQL,

			// Oracle

			Oracle,

			// SQLite

			SQLite
		};

		#endregion Variables

		#region Constructors/Destructors

		public DBAccessManager(int dbtype, string datasource, string database,
			string userID, string password, string securityType)
		{
			switch (dbtype)
			{
				case (int)DatabaseTypes.iSeriesDB2:
					this.currentConnection = new iSeriesDBAccess(datasource, userID, password);
					break;

				//case (int)DatabaseTypes.MySQL:
				//	this.currentConnection = new MySqlDBAccess(datasource, database, userID, password);
				//	break;

				//case (int)DatabaseTypes.SqlServer:
				//	if (securityType == null || securityType == "")
				//	{
				//		this.currentConnection = new SqlServerDBAccess(datasource, database, userID, password, false);
				//	}
				//	else if (securityType.ToUpper() == DBAccessManager.SqlServerIntegratedSecurityString)
				//	{
				//		this.currentConnection = new SqlServerDBAccess(datasource, database, userID, password, DBAccessManager.SqlServerIntegratedSecurityString);
				//	}
				//	break;

				case (int)DatabaseTypes.Oracle:
				/*					if ( securityType == null || securityType == ""
										|| "true".Equals( securityType.ToLower() ) || "yes".Equals( securityType.ToLower() ) )
									{
										this.currentConnection = new OracleDBAccess( datasource );
									}
									else
									{
				*/

				//this.currentConnection = new OracleDBAccess(datasource, userID, password);
				////					}
				//break;

				//case (int)DatabaseTypes.OdbcDSN:
				//	this.currentConnection = new OdbcDBAccess(datasource);
				//	break;

				//case (int)DatabaseTypes.PostgreSQL:
				//	this.currentConnection = new PostgreSQLDBAccess(datasource, database, userID, password);
				//	break;

				default:
					break;
			}

			if (securityType != null)
			{
				this.currentConnection.SecurityType = securityType;
			}

			this.connect();
		}

		/// <summary>
		/// Creates a new DBAccessManager instance of the type specificied.
		/// </summary>
		/// <remarks>
		/// If any parameter is not required or supported by the desired database connection,
		/// send null (nothing in VB) or "".
		/// </remarks>
		/// <param name="dbtype">A <seealso cref="SWallTech.DBAccessManager.DatabaseTypes">DatabaseTypes</seealso> enumeration representing the desired database type.
		/// </param>
		/// <param name="datasource"><b>Always Required.</b>The desired DataSource, such as an IP address.  To specify a
		/// particular PORT on an IP address, append the IP address with <em>:1234</em> where "1234"
		/// indicates the specific PORT number.
		/// NOT SUPPORTED in Oracle or ODBC.</param>
		/// <param name="database">The default database name for this connection. NOT SUPPORTED in Oracle or ODBC.</param>
		/// <param name="userID">The user ID for this connection.</param>
		/// <param name="password">The user ID's password for this connection.</param>
		/// <param name="securityType">The security type for this connection.</param>
		public DBAccessManager(DatabaseTypes type, string datasource, string database,
			string userID, string password, string securityType)
			: this((int)type, datasource, database, userID, password, securityType)
		{
		}

		/// <summary>
		/// Creates a new DBAccessManager instance of the type specificied.
		/// </summary>
		/// <remarks>
		/// If any parameter is not required or supported by the desired database connection,
		/// send null (nothing in VB) or "".
		/// </remarks>
		/// <param name="dbtype">A <seealso cref="SWallTech.DBAccessManager.DatabaseTypes">DatabaseTypes</seealso> enumeration representing the desired database type.
		/// </param>
		/// <param name="datasource"><b>Always Required.</b>The desired DataSource, such as an IP address.  To specify a
		/// particular PORT on an IP address, append the IP address with <em>:1234</em> where "1234"
		/// indicates the specific PORT number.
		/// NOT SUPPORTED in Oracle or ODBC.</param>
		/// <param name="database">The default database name for this connection. NOT SUPPORTED in Oracle or ODBC.</param>
		/// <param name="userID">The user ID for this connection.</param>
		/// <param name="password">The user ID's password for this connection.</param>
		public DBAccessManager(DatabaseTypes type, string datasource, string database,
			string userID, string password)
			: this((int)type, datasource, database, userID, password, null)
		{
		}

		/// <summary>
		/// Creates a new DBAccessManager instance of the type specificied.
		/// </summary>
		/// <remarks>
		/// If any parameter is not required or supported by the desired database connection,
		/// send null (nothing in VB) or "".
		/// </remarks>
		/// <param name="dbtype">A string representing the desired database type.  It is highly
		/// recommended to use the supplied <seealso cref="SWallTech.DBAccessManager.DatabaseTypes">DatabaseTypes</seealso>
		///  enumeration to get the proper string, but the following variations are supported (not case-sensitive):
		/// <list type="bullet">
		/// <item>For IBM i*:<list type="bullet">
		/// <item>iSeriesDB2</item>
		/// <item>iSeries</item>
		/// <item>AS/400</item>
		/// <item>AS400</item>
		/// <item>DB2400</item>
		/// <item>i5</item>
		/// </list>
		/// </item>
		/// <item>For SqlServer:<list type="bullet">
		/// <item>SqlServer</item>
		/// <item>Sql</item>
		/// </list>
		/// </item>
		/// <item>For MySql:<list type="bullet">
		/// <item>MySql</item>
		/// </list>
		/// </item>
		/// <item>For Oracle:<list type="bullet">
		/// <item>Oracle</item>
		/// </list>
		/// </item>
		/// <item>For PostgreSQL:<list type="bullet">
		/// <item>PostgreSQL</item>
		/// <item>Postgre</item>
		/// </list>
		/// </item>
		/// <item>For ODBC:<list type="bullet">
		/// <item>OdbcDSN</item>
		/// <item>Odbc</item>
		/// </list>
		/// </item>
		/// <item>For SQLite:<list type="bullet">
		/// <item>SQLite</item>
		/// </list>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="datasource"><b>Always Required.</b>The desired DataSource, such as an IP address.  To specify a
		/// particular PORT on an IP address, append the IP address with <em>:1234</em> where "1234"
		/// indicates the specific PORT number.
		/// NOT SUPPORTED in Oracle, ODBC, or SQLite.</param>
		/// <param name="database">The default database name for this connection. NOT SUPPORTED in Oracle, ODBC, or SQLite</param>
		/// <param name="userID">The user ID for this connection.</param>
		/// <param name="password">The user ID's password for this connection.</param>
		/// <param name="securityType">The security type for this connection.</param>
		public DBAccessManager(string type, string datasource, string database,
			string userID, string password, string securityType)
			: this((int)DBAccessManager.GetDatabaseTypeFromString(type), datasource, database, userID, password, securityType)
		{
		}

		private DBAccessManager()
		{
		}

		#endregion Constructors/Destructors

		#region Properties

		/// <summary>
		/// An int representing the current database type of this connection.
		/// </summary>
		public int DatabaseType
		{
			get
			{
				return this.currentDBType;
			}

			set
			{
				this.currentDBType = value;
			}
		}

		#endregion Properties

		#region IDBAccess Members

		/// <summary>
		/// Returns the current Connection object for direct usage. (Read only).
		/// </summary>
		public IDbConnection Connection
		{
			get
			{
				return this.currentConnection.Connection;
			}
		}

		/// <summary>
		/// The database of the connection.
		/// </summary>
		public string DataBase
		{
			get
			{
				return this.currentConnection.DataBase;
			}

			set
			{
				this.currentConnection.DataBase = value;
			}
		}

		/// <summary>
		/// The datasource of the connection, such as an IP address or ODBC DSN name.
		/// </summary>
		public string DataSource
		{
			get
			{
				return this.currentConnection.DataSource;
			}

			set
			{
				this.currentConnection.DataSource = value;
			}
		}

		/// <summary>
		/// The connection state of the instance. (Read-only)
		/// </summary>
		public bool IsConnected
		{
			get
			{
				return this.currentConnection.IsConnected;
			}
		}

		/// <summary>
		/// The last Database specific Exception object. (Read-only)
		/// </summary>
		public Exception LastDBError
		{
			get
			{
				return this.currentConnection.LastDBError;
			}
		}

		/// <summary>
		/// Returns the database specific error message type. (Read-only)
		/// </summary>
		public string LastDBErrorExceptionType
		{
			get
			{
				return this.currentConnection.LastDBErrorExceptionType;
			}
		}

		/// <summary>
		/// An IDictionary listing of the Database specific error fields. (Read-only)
		/// </summary>
		public IDictionary LastDBErrorInformation
		{
			get
			{
				return this.currentConnection.LastDBErrorInformation;
			}
		}

		/// <summary>
		/// The last non-Database specific Exception object. (Read-only)
		/// </summary>
		public Exception LastError
		{
			get
			{
				return this.currentConnection.LastError;
			}
		}

		/// <summary>
		/// The password of the connection. (Write-only)
		/// </summary>
		public string Password
		{
			set
			{
				this.currentConnection.Password = value;
			}
		}

		/// <summary>
		/// The port of the connection.
		/// </summary>
		public int Port
		{
			get
			{
				return this.currentConnection.Port;
			}

			set
			{
				this.currentConnection.Port = value;
			}
		}

		/// <summary>
		/// The Security Type of the connection, such as "SSPI" for Windows integrated security.
		/// </summary>
		public string SecurityType
		{
			get
			{
				return this.currentConnection.SecurityType;
			}

			set
			{
				this.currentConnection.SecurityType = value;
			}
		}

		/// <summary>
		/// The Separator Character for this database connection
		/// </summary>
		public string SeparatorCharacter
		{
			get
			{
				return this.currentConnection.SeparatorCharacter;
			}
		}

		/// <summary>
		/// The user ID of the connection.
		/// </summary>
		public string UserID
		{
			get
			{
				return this.currentConnection.UserID;
			}

			set
			{
				this.currentConnection.UserID = value;
			}
		}

		/// <summary>
		/// Closes the current IDBAccess instance and connection.
		/// </summary>
		public void Close()
		{
			this.currentConnection.Close();
		}

		/// <summary>
		/// Attempt to connect to the database.
		/// </summary>
		/// <returns>TRUE if the connection was successful, FALSE if it was not.</returns>
		public bool connect()
		{
			return this.currentConnection.connect();
		}

		/// <summary>
		/// Creates a Command object from the current Connection.  Ideal for parameterized queries.
		/// </summary>
		/// <param name="query">The SQL statement. For parameterized queries, prefix the parameter location with the "@" symbol.</param>
		/// <returns>IDbCommand object, type specific to the current DB Connection.</returns>
		public IDbCommand CreateCommand(string query)
		{
			return this.currentConnection.CreateCommand(query);
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
			return this.currentConnection.CreateParameter(parameterName, dataType, columnName);
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
			return this.currentConnection.CreateParameter(parameterName, dataType, columnName, size);
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
			return this.currentConnection.CreateParameter(parameterName, dataType, columnName, precision, scale);
		}

		/// <summary>
		/// Executes the specified SQL statement on the current database connection.  Statements can be
		/// anything other than a <em>Select</em> statement.
		/// </summary>
		/// <param name="s">The SQL statement to run.</param>
		/// <returns>The number of rows affected.  For <em>Update</em>, <em>Insert</em>, and <em>Delete</em>
		/// statements this value should be greater thean -1.  Other statemens, such as <em>Create Table</em>
		/// will return either -1 or 0 based on the specific database implementation.</returns>
		public int ExecuteNonSelectStatement(string s)
		{
			return this.currentConnection.ExecuteNonSelectStatement(s);
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
			return this.currentConnection.ExecuteScalar(query);
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
			return this.currentConnection.getDataReader(SQL);
		}

		public Exception GetDB2Error(IBM.Data.DB2.iSeries.iDB2Error db2Error)
		{
			IBMException ex = new IBMException(db2Error);
			return ex;
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
		/// The string must be supported by the particular implementation.
		/// </remarks>
		/// <param name="s">The name of the error information you wish to retrieve.</param>
		/// <returns>The specific error information requested, if available.</returns>
		public string getDBErrorData(string s)
		{
			return this.currentConnection.getDBErrorData(s);
		}

		/// <summary>
		/// Runs the specified SQL <em>Select</em> statement on the current database connection.
		/// </summary>
		/// <param name="s">The SQL <em>Select</em> statement to run.</param>
		/// <returns>A DataSet containing the results.</returns>
		public DataSet RunSelectStatement(string s)
		{
			try
			{
				return this.currentConnection.RunSelectStatement(s);
			}
			catch (Exception)
			{
				return new DataSet();
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="coll"></param>
		/// <param name="parameterName"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public IDataParameterCollection SetParameterValue(IDataParameterCollection coll, string parameterName, object value)
		{
			coll = this.currentConnection.SetParameterValue(coll, parameterName, value);
			return coll;
		}

		#endregion IDBAccess Members

		#region Public Static Members

		/// <summary>
		/// The correct string to use for Windows Integrated Security on SqlServer.
		/// </summary>
		public static readonly string SqlServerIntegratedSecurityString = "SSPI";

		/// <summary>
		/// Retrieves the <seealso cref="SWallTech.DBAccessManager.DatabaseTypes">DatabaseTypes</seealso> enumeration value
		/// of the passed string. Throws an ArgumentException if the string is not recognized.
		/// </summary>
		/// <param name="typeName">The string representation of the DatabaseType.</param>
		/// <returns>The <seealso cref="SWallTech.DBAccessManager.DatabaseTypes">DatabaseTypes</seealso> enumeration value associated with the passed string.</returns>
		public static DatabaseTypes GetDatabaseTypeFromString(string typeName)
		{
			DatabaseTypes type;

			switch (typeName.ToLower())
			{
				case "iseriesdb2":
				case "iseries":
				case "as400":
				case "as/400":
				case "db2400":
				case "i5":
					type = DatabaseTypes.iSeriesDB2;
					break;

				case "sqlserver":
				case "sql":
					type = DatabaseTypes.SqlServer;
					break;

				case "oracle":
					type = DatabaseTypes.Oracle;
					break;

				case "mysql":
					type = DatabaseTypes.MySQL;
					break;

				case "postgresql":
				case "postgre":
					type = DatabaseTypes.PostgreSQL;
					break;

				case "odbcdsn":
				case "odbc":
					type = DatabaseTypes.OdbcDSN;
					break;

				case "sqlite":
					type = DatabaseTypes.SQLite;
					break;

				default:
					throw new ArgumentException("Database Type \"" + typeName + "\" not found in DBAccessManager.DatabaseTypes Enumerations.");
			}

			return type;
		}

		#endregion Public Static Members

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}