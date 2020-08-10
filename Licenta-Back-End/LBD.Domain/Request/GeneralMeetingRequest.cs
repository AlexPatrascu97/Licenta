using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.Request
{
	public class GeneralMeetingRequest
	{
		public String MeetingName { get; set; }
		public String Link { get; set; }
		public DateTime Date { get; set; }
		public String Details { get; set; }
		public String ProjectName { get; set; }
	}
}
