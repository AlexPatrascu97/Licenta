using LBD.Domain.EF;
using LBD.Domain.EF.IRepository;
using LBD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Services.Implementations
{

	public class MeetingServices : BaseServices, IMeetingServices
	{
		public IMeetingRepository MeetingRepository { get; }

		public MeetingServices(ManagerDbContext context, IMeetingRepository meetingRepository) : base(context)
		{
			MeetingRepository = meetingRepository;
		}

	}
}
