using LBD.Domain.EF;
using LBD.Domain.EF.IRepository;
using LBD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Services.Implementations
{
	public class TaskServices : BaseServices, ITaskServices
	{
		public ITaskRepository TaskRepository { get; }

		public TaskServices(ManagerDbContext context, ITaskRepository taskRepository) : base(context)
		{
			TaskRepository = taskRepository;
		}

	}
}
