using LBD.Domain.EF.IRepository;
using LBD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBD.Domain.EF.Repository
{
	public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
	{
		private readonly ManagerDbContext _context;

		public EmployeeRepository(ManagerDbContext context) : base(context)
		{
		}
	
	
	}
}
