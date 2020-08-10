using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.Request
{
	public class GeneralTeamRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ProjectName { get; set; }
		public string TeamLeaderFirstName { get; set; }
		public string TeamLeaderLastName { get; set; }
	}
}
