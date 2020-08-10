using LBD.Domain.EF.IRepository;
using LBD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.EF.Repository
{
	public class TeamRepository : BaseRepository<Team>, ITeamRepository
	{
		public TeamRepository(ManagerDbContext context) : base(context)
		{
		}
	}
}
