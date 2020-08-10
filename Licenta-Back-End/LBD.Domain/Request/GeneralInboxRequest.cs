using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.Request
{
	public class GeneralInboxRequest
	{
		public String Recipient { get; set; }
		public String Sender { get; set; }
		public String Title { get; set; }
		public String Message { get; set; }
		public String Status { get; set; }
	}
}
