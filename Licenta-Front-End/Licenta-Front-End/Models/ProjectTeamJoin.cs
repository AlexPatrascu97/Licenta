using LBD.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta_Front_End.Models
{
	public class ProjectTeamJoin : BaseEntity
	{
		public string ProjectName { get; set; }
		public DateTime StartDate { get; set; }
		public int AllocatedMoney { get; set; }
		public string TeamLeader { get; set; }
		public string ClientName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string TeamLeaderFirstName { get; set; }
		public string TeamLeaderLastName { get; set; }
	}
}
