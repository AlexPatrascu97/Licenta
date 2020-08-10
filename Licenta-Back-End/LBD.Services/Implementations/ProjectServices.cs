using LBD.Domain.EF;
using LBD.Domain.EF.IRepository;
using LBD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Services.Implementations
{
	public class ProjectServices : BaseServices, IProjectServices
	{
		public IProjectRepository ProjectRepository { get; }

		public ProjectServices(ManagerDbContext context, IProjectRepository projectRepository) : base(context)
		{
			ProjectRepository = projectRepository;
		}

	}
}
