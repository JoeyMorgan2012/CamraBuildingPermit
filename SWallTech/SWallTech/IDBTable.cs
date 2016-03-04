using System;

namespace SWallTech
{
	/// <summary>
	/// Summary description for IDBTable.
	/// </summary>
	public interface IDBTable
	{
		/// <summary>
		/// Gets or sets IDBAccess Connection Object.
		/// </summary>
		IDBAccess DBAccessObject
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the DataBase name.
		/// </summary>
		string DataBase
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Database Table name.
		/// </summary>
		string FileName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the fully qualified Database Table name.
		/// </summary>
		string FullFileName
		{
			get;
		}

		/// <summary>
		/// Gets or sets the Database and Filename separator.
		/// </summary>
		string Separator
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the Database Exception object from the
		/// most recent Database operation.
		/// </summary>
		Exception LastException
		{
			get;
		}

		/// <summary>
		/// Populates the instance properties with data from the database table based on the
		/// current key settings.
		/// </summary>
		bool populate();

		/// <summary>
		/// Updates the database table with the current property values using the
		/// current key settings.
		/// </summary>
		///<returns>The number of rows updated.</returns>
		int update();

		/// <summary>
		/// Inserts a record into the database table using all current property values.
		/// </summary>
		///<returns>The number of rows inserted.</returns>
		int insert();

		/// <summary>
		/// Deletes from the database table all records /// with the current key settings.
		/// </summary>
		///<returns>The number of rows deleted.</returns>
		int delete();
	}
}