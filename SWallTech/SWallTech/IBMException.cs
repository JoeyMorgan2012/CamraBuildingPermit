using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using IBM.Data.DB2.iSeries;

namespace SWallTech
{
	[Serializable]
	public class IBMException : Exception
	{
		private Exception sWallTechDbException;

		public IBMException(iDB2Error ibmError)
		{
			GetIbmExceptionInfo(ibmError);
		}

		public IBMException(iDB2SQLErrorException ibmError)
		{
			GetIbmExceptionInfo(ibmError);
		}

		public Exception SWallTechDbException
		{
			get
			{
				return sWallTechDbException;
			}

			set
			{
				sWallTechDbException = value;
			}
		}

		public new void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		private void GetIbmExceptionInfo(iDB2SQLErrorException ibmError)
		{
			Exception ex = new Exception();
			ex.Data.Add("IBMDetails", ibmError.MessageDetails);
			ex.Data.Add("IBMErrorMessage", ibmError.Message);
			ex.Data.Add("IBMErrorCode", ibmError.MessageCode);
			Console.WriteLine(string.Format("Error occurred in {0}, in procedure {1}: \n Error: {2}", MethodBase.GetCurrentMethod().Module, MethodBase.GetCurrentMethod().Name, ex.Message));
			sWallTechDbException = ex;
		}

		private void GetIbmExceptionInfo(iDB2Error ibmError)
		{
			Exception ex = new Exception();
			ex.Data.Add("IBMDetails", ibmError.MessageDetails);
			ex.Data.Add("IBMErrorMessage", ibmError.Message);
			ex.Data.Add("IBMErrorCode", ibmError.MessageCode);
			Console.WriteLine(string.Format("Error occurred in {0}, in procedure {1}: \n Error: {2}", MethodBase.GetCurrentMethod().Module, MethodBase.GetCurrentMethod().Name, ex.Message));
			sWallTechDbException = ex;
		}
	}
}