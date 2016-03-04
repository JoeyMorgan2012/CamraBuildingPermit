using System;
using System.Text;

namespace SWallTech
{
	public class IBMConnectionStringBuilder
	{
		public string HostName, Library, UserName, Password, DBConnectionString;

		public static string GetConnectionString
		(string host, string library, string username, string password)
		{
			string _sqlConnectionString = string.Format
			("Provider=IBMDA400.DataSource.1;Data Source={0};Persist Security Info=True;Password ={3};UserID = { 2 };Catalog Library List ={1}", host, library, username, password);

			return _sqlConnectionString;
		}
	}
}