﻿using LBD.Domain.EF.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Services.Interfaces
{
	public interface IProjectServices : IBaseServices
	{
		IProjectRepository ProjectRepository { get; }
	}
}
