using LBD.Domain.EF.IRepository;
using LBD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.EF.Repository
{
	public class MeetingRepository : BaseRepository<Meeting>, IMeetingRepository
	{
		public MeetingRepository(ManagerDbContext context) : base(context)
		{
		}
	}
}
