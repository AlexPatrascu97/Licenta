using LBD.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta_Front_End.Models
{
	public class Sprint : BaseEntity
	{
		public int SprintNumber { get; set; }
		public string ProjectName { get; set; }
		public DateTime startdate { get; set; }
		public string status { get; set; }
	}
}
