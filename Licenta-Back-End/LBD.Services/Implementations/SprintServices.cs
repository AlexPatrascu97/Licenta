using LBD.Domain.EF;
using LBD.Domain.EF.IRepository;
using LBD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Services.Implementations
{
	public class SprintServices : BaseServices, ISprintServices
	{
		public ISprintRepository SprintRepository { get; }

		public SprintServices(ManagerDbContext context, ISprintRepository sprintRepository) : base(context)
		{
			SprintRepository = sprintRepository;
		}

	}
}
