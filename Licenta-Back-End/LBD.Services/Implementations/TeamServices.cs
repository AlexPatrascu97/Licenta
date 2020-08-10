using LBD.Domain.EF;
using LBD.Domain.EF.IRepository;
using LBD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Services.Implementations
{
	public class TeamServices : BaseServices, ITeamServices
	{
		public ITeamRepository TeamRepository { get; }

		public TeamServices(ManagerDbContext context, ITeamRepository teamRepository) : base(context)
		{
			TeamRepository = teamRepository;
		}

	}
}
