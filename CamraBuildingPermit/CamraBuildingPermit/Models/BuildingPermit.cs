using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamraBuildingPermit
{
	public class BuildingPermit : IBuildingPermit
	{
		string issueDate = string.Empty;
		int localid = 0;
		string permitNo = string.Empty;
		string mapNo = string.Empty;
		string countyId = string.Empty;
		string owner = string.Empty;
		int houseNo = 0;
		string unitDirection = string.Empty;
		string address = string.Empty;
		decimal estimatedCost = 0M;
		string description1 = string.Empty;
		string completedDate = string.Empty;
		string explanation = string.Empty;
		string changeDate = string.Empty;
		string completed = string.Empty;
		int dwellingNo = 0;
		string description2 = string.Empty;
		int recordNo = 0;
		decimal startLandValue = 0M;
		decimal startBldgValue = 0M;
		decimal endLandValue = 0M;
		decimal endBldgValue = 0M;
		

		public string IssueDate
		{
			get
			{
				return issueDate;
			}

			set
			{
				issueDate = value;
			}
		}

		public int Localid
		{
			get
			{
				return localid;
			}

			set
			{
				localid = value;
			}
		}

		public string PermitNo
		{
			get
			{
				return permitNo;
			}

			set
			{
				permitNo = value;
			}
		}

		public string MapNo
		{
			get
			{
				return mapNo;
			}

			set
			{
				mapNo = value;
			}
		}

		public string CountyId
		{
			get
			{
				return countyId;
			}

			set
			{
				countyId = value;
			}
		}

		public string Owner
		{
			get
			{
				return owner;
			}

			set
			{
				owner = value;
			}
		}

		public int HouseNo
		{
			get
			{
				return houseNo;
			}

			set
			{
				houseNo = value;
			}
		}

		public string UnitDirection
		{
			get
			{
				return unitDirection;
			}

			set
			{
				unitDirection = value;
			}
		}

		public string Address
		{
			get
			{
				return address;
			}

			set
			{
				address = value;
			}
		}

		public decimal EstimatedCost
		{
			get
			{
				return estimatedCost;
			}

			set
			{
				estimatedCost = value;
			}
		}

		public string Description1
		{
			get
			{
				return description1;
			}

			set
			{
				description1 = value;
			}
		}

		public string CompletedDate
		{
			get
			{
				return completedDate;
			}

			set
			{
				completedDate = value;
			}
		}

		public string Explanation
		{
			get
			{
				return explanation;
			}

			set
			{
				explanation = value;
			}
		}

		public string ChangeDate
		{
			get
			{
				return changeDate;
			}

			set
			{
				changeDate = value;
			}
		}

		public string Completed
		{
			get
			{
				return completed;
			}

			set
			{
				completed = value;
			}
		}

		public int DwellingNo
		{
			get
			{
				return dwellingNo;
			}

			set
			{
				dwellingNo = value;
			}
		}

		public string Description2
		{
			get
			{
				return description2;
			}

			set
			{
				description2 = value;
			}
		}

		public int RecordNo
		{
			get
			{
				return recordNo;
			}

			set
			{
				recordNo = value;
			}
		}

		public decimal StartLandValue
		{
			get
			{
				return startLandValue;
			}

			set
			{
				startLandValue = value;
			}
		}

		public decimal StartBldgValue
		{
			get
			{
				return startBldgValue;
			}

			set
			{
				startBldgValue = value;
			}
		}

		public decimal EndLandValue
		{
			get
			{
				return endLandValue;
			}

			set
			{
				endLandValue = value;
			}
		}

		public decimal EndBldgValue
		{
			get
			{
				return endBldgValue;
			}

			set
			{
				endBldgValue = value;
			}
		}
	}
}
