using LBD.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.Models
{
	public class Inbox : BaseEntity
	{
		public String Recipient { get; set; }
		public String Sender { get; set; }
		public String Title { get; set; }
		public String Message { get; set; }
		public String Status { get; set; }
	}
}
