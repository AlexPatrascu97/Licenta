using LBD.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta_Front_End.Models
{
	public class Inbox : BaseEntity
	{
		
		public String Recipient { get; set; }
		public String Sender { get; set; }
		public String Message { get; set; }
		public String Status { get; set; }
		public String Title { get; set; }

	}
}
