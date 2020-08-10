using LBD.Domain.EF;
using LBD.Domain.EF.IRepository;
using LBD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Services.Implementations
{
	public class EmployeeServices : BaseServices, IEmployeeServices
	{
		public IEmployeeRepository EmployeeRepository { get; }

		public EmployeeServices(ManagerDbContext context, IEmployeeRepository employeeRepository) : base(context)
		{
			EmployeeRepository = employeeRepository;
		}

	}
}
