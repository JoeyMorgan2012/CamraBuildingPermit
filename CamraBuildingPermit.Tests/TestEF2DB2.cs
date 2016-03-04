using System;
using FluentData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CamraBuildingPermit.Tests
{
	[TestClass]
	public class TestEF2DB2
	{
		[TestMethod]
		public void GetConnectionTest()
		{
			IDbContext dc = Db2Context();
			Assert.IsNotNull(dc);

		}
		public IDbContext Db2Context()
		{
			//Server=myAddress:myPortNumber;Database=myDataBase;UID=myUsername;PWD=myPassword;
			return new DbContext().ConnectionString("Server=192.168.176.240;Database=S109037B;UID=CAMRA2;PWD=CAMRA2", new DB2Provider());

		}
	}
}
