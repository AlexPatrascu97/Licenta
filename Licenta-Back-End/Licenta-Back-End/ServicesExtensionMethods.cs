using LBD.Domain.EF;
using LBD.Domain.EF.IRepository;
using LBD.Domain.EF.Repository;
using LBD.Services.Implementations;
using LBD.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta_Back_End
{
	public static class ServicesExtensionMethods
	{
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
		{
			string connectionString = config["ConnectionStrings:DefaultString"];
			services.AddDbContext<ManagerDbContext>(c => c.UseSqlServer(connectionString, b => b.MigrationsAssembly("Licenta-Back-End")));
		}

		public static void InjectRepositories(this IServiceCollection services)
		{
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<ISprintRepository, SprintRepository>();
			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<ITaskRepository, TaskRepository>();
			services.AddScoped<ITeamRepository, TeamRepository>();
			services.AddScoped<IInboxRepository, InboxRepository>();
			services.AddScoped<IMeetingRepository, MeetingRepository>();
		}

		public static void InjectServices(this IServiceCollection services)
		{
			services.AddScoped<IEmployeeServices, EmployeeServices>();
			services.AddScoped<ISprintServices, SprintServices>();
			services.AddScoped<IProjectServices, ProjectServices>();
			services.AddScoped<ITaskServices, TaskServices>();
			services.AddScoped<ITeamServices, TeamServices>();
			services.AddScoped<IInboxServices, InboxServices>();
			services.AddScoped<IMeetingServices, MeetingServices>();
		}
	}
}
