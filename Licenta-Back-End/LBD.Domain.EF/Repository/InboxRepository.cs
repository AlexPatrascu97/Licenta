using LBD.Domain.EF.IRepository;
using LBD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.EF.Repository
{
	public class InboxRepository : BaseRepository<Inbox>, IInboxRepository
	{
		private readonly ManagerDbContext _context;

		public InboxRepository(ManagerDbContext context) : base(context)
		{
		}


	}
}
