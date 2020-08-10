using LBD.Domain.EF.IRepository;
using LBD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.EF.Repository
{
	public class ProjectRepository : BaseRepository<Project>, IProjectRepository
	{
		private readonly ManagerDbContext _context;

		public ProjectRepository(ManagerDbContext context) : base(context)
		{
		}


	}
}
