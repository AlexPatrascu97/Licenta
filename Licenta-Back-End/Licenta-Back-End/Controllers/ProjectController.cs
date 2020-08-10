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
	[Route("api/project")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly IProjectServices _projectServices;
		private readonly IEmployeeServices _employeeServices;
		private readonly ITaskServices _taskServices;
		private readonly ITeamServices _teamServices;

		public ProjectController(IProjectServices projectServices, IEmployeeServices employeeServices, ITaskServices taskServices, ITeamServices teamServices)
		{
			_projectServices = projectServices;
			_employeeServices = employeeServices;
			_taskServices = taskServices;
			_teamServices = teamServices;
		}

		[HttpGet("GetAllProjects")]
		public async Task<ObjectResult> GetAllProjectsAsync()
		{
			List<Project> result = await _projectServices.ProjectRepository.GetAllAsync();

			return Ok(result);
		}

		

		

		[HttpDelete("DeleteProject/{id}")]
		public async Task<ObjectResult> DeletePRojectAsync([FromRoute] int id)
		{
			Project project = await _projectServices.ProjectRepository.GetByIdAsync(id);
			_projectServices.ProjectRepository.Delete(project);
			await _projectServices.CommitChanges();

			return Ok(project);
		}

		[HttpGet("GetAllProjectTasks/{id}")]
		public async Task<ObjectResult> GetAllProjectTasksAsync([FromRoute] string id)
		{
			List<Project> Projects = await _projectServices.ProjectRepository.GetAllAsync();
			List<LBD.Domain.Models.Task> Tasks = await _taskServices.TaskRepository.GetAllAsync();

			var data =
			   from tsk in Tasks
			   join prj in Projects on tsk.ProjectName equals prj.ProjectName
			   where prj.ProjectName == id
			   select new
			   {
				   TaskOwnerID = tsk.TaskOwnerID,
				   Task = tsk.Details


			   };

			return Ok(data);
		}

		[HttpGet("GetProject/{id}")]
		public async Task<ObjectResult> GetProjectAsync([FromRoute] int id)
		{
			Project result = await _projectServices.ProjectRepository.GetByIdAsync(id);

			return Ok(result);
		}

		

		[HttpPost("CreateProject")]
		public async Task<ObjectResult> CreateProjectAsync([FromBody] GeneralProjectRequest request)
		{
			Project result = await _projectServices.ProjectRepository.CreateAsync(request.ToDTOProject());
			await _projectServices.CommitChanges();

			return Ok(result);
		}

		[HttpPut("UpdateProject/{id}")]
		public async Task<ObjectResult> UpdateProjectAsync([FromBody] GeneralProjectRequest request, [FromRoute] int id)
		{
			Project result = _projectServices.ProjectRepository.Update(request.ToDTOProject(id));
			await _projectServices.CommitChanges();

			return Ok(result);
		}

		[HttpDelete("DeleteSprint/{id}")]
		public async Task<ObjectResult> DeleteSprintAsync([FromRoute] int id)
		{
			Project sprint = await _projectServices.ProjectRepository.GetByIdAsync(id);
			_projectServices.ProjectRepository.Delete(sprint);
			await _projectServices.CommitChanges();

			return Ok(sprint);
		}

		
	}
}