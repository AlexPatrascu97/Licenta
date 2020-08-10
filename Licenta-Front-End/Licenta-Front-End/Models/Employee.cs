using LBD.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta_Front_End.Models
{
	public class Employee : BaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Salary { get; set; }
		public string DepartamentName { get; set; }
		public string JobTitle { get; set; }
		public string ProjectName { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public string Email { get; set; }


	}
}
