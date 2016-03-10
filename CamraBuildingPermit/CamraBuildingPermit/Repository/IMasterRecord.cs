using System.Collections.Generic;

namespace CamraBuildingPermit
{
	public interface IMasterRecord
	{
		List<BuildingPermit> BuildingPermits
		{
			get;
			set;
		}
		int DwellingNumber
		{
			get;
			set;
		}
		string JobAddress
		{
			get;
			set;
		}
		string LastName
		{
			get;
			set;
		}
		string MapNumber
		{
			get;
			set;
		}
		int RecordNumber
		{
			get;
			set;
		}
	}
}