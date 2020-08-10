using LBD.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta_Front_End.Models
{
	public class Project : BaseEntity
	{
		public string ProjectName { get; set; }
		public DateTime StartDate { get; set; }
		public int AllocatedMoney { get; set; }
		public string TeamLeader { get; set; }
		public string ClientName { get; set; }
		public string Detail { get; set; }
	}
}
