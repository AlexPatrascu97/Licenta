using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBD.Domain.ExtensionMethods;
using LBD.Domain.Models;
using LBD.Domain.Request;
using LBD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licenta_Back_End.Controllers
{
	[Route("api/team")]
	[ApiController]
	public class TeamController : ControllerBase
	{
		private readonly ITeamServices _teamServices;
		private readonly IEmployeeServices _employeeServices;
		private readonly IProjectServices _projectServices;
		

		public TeamController(ITeamServices teamServices, IEmployeeServices employeeServices, IProjectServices projectServices)
		{
			_teamServices = teamServices;
			_employeeServices = employeeServices;
			_projectServices = projectServices;
		}

		[HttpGet("GetAllTeams")]
		public async Task<ObjectResult> GetAllTeamAsync()
		{
			List<Team> result = await _teamServices.TeamRepository.GetAllAsync();

			return Ok(result);
		}


		[HttpGet("GetTeam/{id}")]
		public async Task<ObjectResult> GetTeamAsync([FromRoute] int id)
		{
			Team result = await _teamServices.TeamRepository.GetByIdAsync(id);

			return Ok(result);
		}


		[HttpPost("CreateTeam")]
		public async Task<ObjectResult> CreateTeamAsync([FromBody] GeneralTeamRequest request)
		{
			Team result = await _teamServices.TeamRepository.CreateAsync(request.ToDTOTeam());
			await _teamServices.CommitChanges();

			return Ok(result);
		}

		[HttpPut("UpdateTeam/{id}")]
		public async Task<ObjectResult> UpdateTeamAsync([FromBody] GeneralTeamRequest request, [FromRoute] int id)
		{
			Team result = _teamServices.TeamRepository.Update(request.ToDTOTeam(id));
			await _teamServices.CommitChanges();

			return Ok(result);
		}

		[HttpDelete("DeleteTeam/{id}")]
		public async Task<ObjectResult> DeleteTeamAsync([FromRoute] int id)
		{
			Team team = await _teamServices.TeamRepository.GetByIdAsync(id);
			_teamServices.TeamRepository.Delete(team);
			await _teamServices.CommitChanges();

			return Ok(team);
		}

		//employee-teams join
		[HttpGet("EmployeeTeamsJoin")]
		public async Task<ObjectResult> EmployeeTeamsJoin()
		{
			List<LBD.Domain.Models.Team> Teams = await _teamServices.TeamRepository.GetAllAsync();
			List<LBD.Domain.Models.Employee> Employees = await _employeeServices.EmployeeRepository.GetAllAsync();

			var data = from x in Teams
					   from y in Employees
							 .Where(y => y.FirstName == x.FirstName && y.LastName == x.LastName)
					   select new
					   {
						   
						   FirstName = y.FirstName,
						   LastName = y.LastName,
						   JobTitle = y.JobTitle,
						   DepartamentName = y.DepartamentName,
						   Role = y.Role,
						   ProjectName = x.ProjectName,
						   TeamLeaderFirstName = x.TeamLeaderFirstName,
						   TeamLeaderLastName = x.TeamLeaderLastName,
						   Email = y.Email
					   };

			return Ok(data);
		}

		//projects-teams join
		[HttpGet("ProjectTeamsJoin")]
		public async Task<ObjectResult> ProjectTeamsJoin()
		{
			List<LBD.Domain.Models.Team> Teams = await _teamServices.TeamRepository.GetAllAsync();
			List<LBD.Domain.Models.Project> Projects = await _projectServices.ProjectRepository.GetAllAsync();

			var data = from x in Teams
					   from y in Projects
							 .Where(y => y.ProjectName.Equals(x.ProjectName))
					   select new
					   {

						   ProjectName = y.ProjectName,
						   StardDate = y.StartDate,
						   AllocatedMoney = y.AllocatedMoney,
						   ClientName = y.ClientName,
						   FirstName = x.FirstName,
						   LastName = x.LastName,
						   TeamLeaderFirstName = x.TeamLeaderFirstName,
						   TeamLeaderLastName = x.TeamLeaderLastName
					   };

			return Ok(data);
		}


	}
}
