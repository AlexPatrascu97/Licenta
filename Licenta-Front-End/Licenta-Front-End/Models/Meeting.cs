using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBD.Domain.Models.BaseModels;

namespace Licenta_Front_End.Models
{
	public class Meeting : BaseEntity
	{
		public String MeetingName { get; set; }
		public String Link { get; set; }
		public DateTime Date { get; set; }
		public String Details { get; set; }
		public String ProjectName { get; set; }
	}
}
