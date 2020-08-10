using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LBD.Domain.Models;
using LBD.Domain.Request;
using LBD.Domain.ExtensionMethods;

namespace Licenta_Back_End.Controllers
{
	[Route("api/task")]
	[ApiController] 
	public class TaskController : ControllerBase
	{
		private readonly ITaskServices _taskServices;
		private readonly IEmployeeServices _employeeServices;

		public TaskController(ITaskServices taskServices, IEmployeeServices employeeServices)
		{
			_taskServices = taskServices;
			_employeeServices = employeeServices;
		}

		[HttpGet("GetAllTasks")]
		public async Task<ObjectResult> GetAllTasksAsync()
		{
			List<LBD.Domain.Models.Task> result = await _taskServices.TaskRepository.GetAllAsync();

			return Ok(result);
		}

		[HttpGet("GetTaskForEmployeeID/{id}")]
		public async Task<ObjectResult> GetTaskForEmployeeAsync([FromRoute] int id)
		{
			List<LBD.Domain.Models.Task> Tasks = await _taskServices.TaskRepository.GetAllAsync();
			List<LBD.Domain.Models.Employee> Employees = await _employeeServices.EmployeeRepository.GetAllAsync();

			var data =
			   from emp in Employees
			   join tsk in Tasks on emp.Id equals tsk.TaskOwnerID
			   where emp.Id == id
			   select new
			   {
				   Id = tsk.Id,
				   FirstName = emp.FirstName,
				   LastName = emp.LastName,
				   ProjectName = tsk.ProjectName,
				   Details = tsk.Details,
				   SprintNumber = tsk.sprintNumber,
				   Status = tsk.Status,
				   TaskName = tsk.TaskName,
				   TaskOwnerFirstName = tsk.TaskOwnerFirstName,
				   TaskOwnerLastName = tsk.TaskOwnerLastName
			   };

			return Ok(data);
		}


		[HttpGet("GetTask/{id}")]
		public async Task<ObjectResult> GetTaskAsync([FromRoute] int id)
		{
			LBD.Domain.Models.Task result = await _taskServices.TaskRepository.GetByIdAsync(id);

			return Ok(result);
		}


		[HttpPost("CreateTask")]
		public async Task<ObjectResult> CreateSprintAsync([FromBody] GeneralTaskRequest request)
		{
			LBD.Domain.Models.Task result = await _taskServices.TaskRepository.CreateAsync(request.ToDTOTask());
			await _taskServices.CommitChanges();

			return Ok(result);
		}

		[HttpPut("UpdateTask/{id}")]
		public async Task<ObjectResult> UpdateSprintAsync([FromBody] GeneralTaskRequest request, [FromRoute] int id)
		{
			LBD.Domain.Models.Task result = _taskServices.TaskRepository.Update(request.ToDTOTask(id));
			await _taskServices.CommitChanges();

			return Ok(result);
		}

		[HttpDelete("DeleteTask/{id}")]
		public async Task<ObjectResult> DeleteSprintAsync([FromRoute] int id)
		{
			LBD.Domain.Models.Task task = await _taskServices.TaskRepository.GetByIdAsync(id);
			_taskServices.TaskRepository.Delete(task);
			await _taskServices.CommitChanges();

			return Ok(task);
		}


		//redeem tasks
		[HttpGet("RedeemTasks")]
		public async Task<ObjectResult> RedeemTasks()
		{
			List<LBD.Domain.Models.Task> Tasks = await _taskServices.TaskRepository.GetAllAsync();
			List<LBD.Domain.Models.Employee> Employees = await _employeeServices.EmployeeRepository.GetAllAsync();

			var data = from x in Tasks
					   from y in Employees
							 .Where(y => y.Id == x.TaskOwnerID)
					   select new
					   {

						   FirstName = y.FirstName,
						   LastName = y.LastName,
						   JobTitle = y.JobTitle,
						   DepartamentName = y.DepartamentName,
						   Role = y.Role,
						   ProjectName = x.ProjectName,
						   sprintNumber = x.sprintNumber,
						   Details = x.Details,
						   Status = x.Status

					   };

			return Ok(data);
		}
		

	}
}