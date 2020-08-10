using LBD.Domain.EF;
using LBD.Domain.EF.IRepository;
using LBD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Services.Implementations
{
	public class InboxServices : BaseServices, IInboxServices
	{
		public IInboxRepository InboxRepository { get; }

		public InboxServices(ManagerDbContext context, IInboxRepository inboxRepository) : base(context)
		{
			InboxRepository = inboxRepository;
		}

	}
}
