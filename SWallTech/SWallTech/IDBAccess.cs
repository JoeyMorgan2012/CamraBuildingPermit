using System;
using System.Collections;
using System.Data;

namespace SWallTech
{
	/// <summary>
	/// Repository of generic constant values for working with databases.
	/// </summary>
	public class DatabaseConstants
	{
		/// <summary>
		/// Generic list of Database types.
		/// </summary>
		public enum DataTypes
		{
			BigInt,
			Binary,
			Blob,
			Char,
			Date,
			DateTime,
			Decimal,
			Double,
			Integer,
			Numeric,
			Real,
			SmallInt,
			Time,
			Timestamp,
			TinyInt,
			VarChar
		}
	}

	/// <summary>
	/// An Interface that describes a database access class.
	/// </summary>
	public interface IDBAccess
	{
		// variables

		// methods
		/// <summary>
		/// Disposes of the current IDBAccess instance and connection.
		/// </summary>
		void Close();

		/// <summary>
		/// Attempt to connect to the database.
		/// </summary>
		/// <returns>TRUE if the connection was successful, FALSE if it was not.</returns>
		bool connect();

		/// <summary>
		/// Runs the specified SQL <em>Select</em> statement on the current database connection.
		/// </summary>
		/// <param name="s">The SQL <em>Select</em> statement to run.</param>
		/// <returns>A DataSet containing the results.</returns>
		DataSet RunSelectStatement(string s);

		/// <summary>
		/// Executes the specified SQL statement on the current database connection.  Statements can be
		/// anything other than a <em>Select</em> statement.
		/// </summary>
		/// <param name="s">The SQL statement to run.</param>
		/// <returns>The number of rows affected.  For <em>Update</em>, <em>Insert</em>, and <em>Delete</em>
		/// statements this value should be greater thean -1.  Other statemens, such as <em>Create Table</em>
		/// will return either -1 or 0 based on the specific database implementation.</returns>
		int ExecuteNonSelectStatement(string s);

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
		string getDBErrorData(string s);

		/// <summary>
		/// Retrieves an IDataReader object for the current connection.  DataReaders
		/// are forward only, active connection objects.  Faster than DataSets, but they
		/// operate exclusively in a connected mode.  ALWAYS close a DataReader as quickly
		/// as possible.
		/// </summary>
		/// <param name="SQL">The SQL statement to run.</param>
		/// <returns>An IDataReader object.</returns>
		IDataReader getDataReader(string SQL);

		/// <summary>
		/// Retrieves the value of the first column of the first row of an SQL statement.
		/// Scalar's provide better performance for aggregates and columnar functions.
		/// </summary>
		/// <param name="query">The SQL statement to execute.</param>
		/// <returns>An object representing the column return value. (Must be cast to appropriate result type)
		/// </returns>
		object ExecuteScalar(string query);

		// properties
		/// <summary>
		/// The connection state of the instance. (Read-only)
		/// </summary>
		bool IsConnected
		{
			get;
		}

		/// <summary>
		/// The datasource of the connection, such as an IP address or ODBC DSN name.
		/// </summary>
		string DataSource
		{
			get;
			set;
		}

		/// <summary>
		/// The port of the connection.
		/// </summary>
		int Port
		{
			get;
			set;
		}

		/// <summary>
		/// The database of the connection.
		/// </summary>
		string DataBase
		{
			get;
			set;
		}

		/// <summary>
		/// The table name of the connection.
		/// </summary>
		string SeparatorCharacter
		{
			get;
		}

		/// <summary>
		/// The user ID of the connection.
		/// </summary>
		string UserID
		{
			get;
			set;
		}

		/// <summary>
		/// The password of the connection. (Write-only)
		/// </summary>
		string Password
		{
			set;
		}

		/// <summary>
		/// The Security Type of the connection, such as "SSPI" for Windows integrated security.
		/// </summary>
		string SecurityType
		{
			get;
			set;
		}

		/// <summary>
		/// The last Database specific Exception object. (Read-only)
		/// </summary>
		Exception LastDBError
		{
			get;
		}

		/// <summary>
		/// The last non-Database specific Exception object. (Read-only)
		/// </summary>
		Exception LastError
		{
			get;
		}

		/// <summary>
		/// An IDictionary listing of the Database specific error fields. (Read-only)
		/// </summary>
		IDictionary LastDBErrorInformation
		{
			get;
		}

		/// <summary>
		/// Returns the database specific error message type. (Read-only)
		/// </summary>
		string LastDBErrorExceptionType
		{
			get;
		}

		/// <summary>
		/// Returns the current Connection object for direct usage. (Read only).
		/// </summary>
		IDbConnection Connection
		{
			get;
		}

		/// <summary>
		/// Creates a Command object from the current Connection.  Ideal for parameterized queries.
		/// </summary>
		/// <param name="query">The SQL statement. For parameterized queries, prefix the parameter location with the "@" symbol.</param>
		/// <returns>IDbCommand object, type specific to the current DB Connection.</returns>
		IDbCommand CreateCommand(string query);

		/// <summary>
		/// Creates a Parameter object, used to add to the Command object Parameter collection.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.  Names are prefixed by the "@" symbol.</param>
		/// <param name="dataType">The dataType of the parameter.</param>
		/// <param name="columnName">The database column name of the parameter.</param>
		/// <returns>IDataParameter object, type specific to the current DB Connection.</returns>
		IDataParameter CreateParameter(string parameterName, DatabaseConstants.DataTypes dataType, string columnName);

		/// <summary>
		/// Creates a Parameter object, used to add to the Command object Parameter collection.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.  Names are prefixed by the "@" symbol.</param>
		/// <param name="dataType">The dataType of the parameter.</param>
		/// <param name="columnName">The database column name of the parameter.</param>
		/// <param name="size">Length: for char data fields</param>
		/// <returns>IDataParameter object, type specific to the current DB Connection.</returns>
		IDataParameter CreateParameter(string parameterName, DatabaseConstants.DataTypes dataType, string columnName, byte size);

		/// <summary>
		/// Creates a Parameter object, used to add to the Command object Parameter collection.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.  Names are prefixed by the "@" symbol.</param>
		/// <param name="dataType">The dataType of the parameter.</param>
		/// <param name="columnName">The database column name of the parameter.</param>
		/// <param name="precision">Precision: for decimal and numeric fields.</param>
		/// <param name="scale">Scale: for decimal and numeric fields.</param>
		/// <returns>IDataParameter object, type specific to the current DB Connection.</returns>
		IDataParameter CreateParameter(string parameterName, DatabaseConstants.DataTypes dataType, string columnName, byte precision, byte scale);

		/// <summary>
		/// Set a parameter value in the given IDataParameterCollection.  Needed to override the generic funcitonality of IDataParameter.
		/// </summary>
		/// <param name="coll">The IDataParameterCollection object.</param>
		/// <param name="parameterName">The parameter name for the value.</param>
		/// <param name="value">The value for the given parameter name.</param>
		/// <returns></returns>
		IDataParameterCollection SetParameterValue(IDataParameterCollection coll, string parameterName, object value);
	}
}