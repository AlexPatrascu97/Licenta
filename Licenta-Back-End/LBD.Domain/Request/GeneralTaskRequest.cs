using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.Request
{
	public class GeneralTaskRequest
	{
		public string TaskName { get; set; }
		public string ProjectName { get; set; }
		public int sprintNumber { get; set; }
		public int? TaskOwnerID { get; set; }
		public string Details { get; set; }
		public string Status { get; set; }
		public string TaskOwnerFirstName { get; set; }
		public string TaskOwnerLastName { get; set; }
	}
}
