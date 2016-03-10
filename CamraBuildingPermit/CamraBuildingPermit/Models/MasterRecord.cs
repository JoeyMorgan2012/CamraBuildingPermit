using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamraBuildingPermit
{
	public class MasterRecord : IMasterRecord
	{
		public List<BuildingPermit> BuildingPermits
		{
			get
			{
				if (buildingPermits == null)
				{
					buildingPermits = new List<BuildingPermit>();
				}
				return buildingPermits;
			}

			set
			{
				buildingPermits = value;
			}
		}

		public int DwellingNumber
		{
			get
			{
				return dwellingNumber;
			}

			set
			{
				dwellingNumber = value;
			}
		}

		public string JobAddress
		{
			get
			{
				return jobAddress;
			}

			set
			{
				jobAddress = value;
			}
		}

		public string LastName
		{
			get
			{
				return lastName;
			}

			set
			{
				lastName = value;
			}
		}

		public string MapNumber
		{
			get
			{
				return mapNumber;
			}

			set
			{
				mapNumber = value;
			}
		}

		public int RecordNumber
		{
			get
			{
				return recordNumber;
			}

			set
			{
				recordNumber = value;
			}
		}

		List<BuildingPermit> buildingPermits;
		int dwellingNumber;
		string jobAddress;
		string lastName;
		string mapNumber;
		int recordNumber;
	}
}
