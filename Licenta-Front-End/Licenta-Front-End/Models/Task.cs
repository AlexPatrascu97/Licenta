using LBD.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta_Front_End.Models
{
	public class Task : BaseEntity
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
