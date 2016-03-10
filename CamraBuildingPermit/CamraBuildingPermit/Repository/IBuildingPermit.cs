namespace CamraBuildingPermit
{
	public interface IBuildingPermit
	{
		string Address
		{
			get;
			set;
		}
		string ChangeDate
		{
			get;
			set;
		}
		string Completed
		{
			get;
			set;
		}
		string CompletedDate
		{
			get;
			set;
		}
		string CountyId
		{
			get;
			set;
		}
		string Description1
		{
			get;
			set;
		}
		string Description2
		{
			get;
			set;
		}
		int DwellingNo
		{
			get;
			set;
		}
		decimal EndBldgValue
		{
			get;
			set;
		}
		decimal EndLandValue
		{
			get;
			set;
		}
		decimal EstimatedCost
		{
			get;
			set;
		}
		string Explanation
		{
			get;
			set;
		}
		int HouseNo
		{
			get;
			set;
		}
		string IssueDate
		{
			get;
			set;
		}
		int Localid
		{
			get;
			set;
		}
		string MapNo
		{
			get;
			set;
		}
		string Owner
		{
			get;
			set;
		}
		string PermitNo
		{
			get;
			set;
		}
		int RecordNo
		{
			get;
			set;
		}
		decimal StartBldgValue
		{
			get;
			set;
		}
		decimal StartLandValue
		{
			get;
			set;
		}
		string UnitDirection
		{
			get;
			set;
		}
	}
}