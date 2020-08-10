using LBD.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.Models
{
	public class Task: BaseEntity
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
