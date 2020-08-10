using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.Request
{
	public class GeneralProjectRequest
	{
		public string ProjectName { get; set; }
		public DateTime StartDate { get; set; }
		public int AllocatedMoney { get; set; }
		public string ClientName { get; set; }
		public string Detail { get; set; }
	}
}
