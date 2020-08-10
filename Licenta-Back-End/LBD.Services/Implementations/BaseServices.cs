using LBD.Domain.EF;
using LBD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LBD.Services.Implementations
{
	public class BaseServices : IBaseServices
	{
		private readonly ManagerDbContext _context;

		public BaseServices(ManagerDbContext context)
		{
			_context = context;
		}

		public async Task CommitChanges()
		{
			await _context.SaveChangesAsync(true);
		}
	}
}
