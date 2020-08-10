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
	[Route("api/sprint")]
	[ApiController]
	public class SprintController : ControllerBase
	{
		private readonly ISprintServices _sprintServices;

		public SprintController ( ISprintServices sprintServices)
		{
			_sprintServices = sprintServices;
		}

		[HttpGet("GetAllSprints")]
		public async Task<ObjectResult> GetAllSprintsAsync()
		{
			List<Sprint> result = await _sprintServices.SprintRepository.GetAllAsync();

			return Ok(result);
		}


		[HttpGet("GetSprint/{id}")]
		public async Task<ObjectResult> GetSprintAsync([FromRoute] int id)
		{
			Sprint result = await _sprintServices.SprintRepository.GetByIdAsync(id);

			return Ok(result);
		}


		[HttpPost("CreateSprint")]
		public async Task<ObjectResult> CreateSprintAsync([FromBody] GeneralSprintRequest request)
		{
			Sprint result = await _sprintServices.SprintRepository.CreateAsync(request.ToDTOSprint());
			await _sprintServices.CommitChanges();

			return Ok(result);
		}

		[HttpPut("UpdateSprint/{id}")]
		public async Task<ObjectResult> UpdateSprintAsync([FromBody] GeneralSprintRequest request, [FromRoute] int id)
		{
			Sprint result = _sprintServices.SprintRepository.Update(request.ToDTOSprint(id));
			await _sprintServices.CommitChanges();

			return Ok(result);
		}

		[HttpDelete("DeleteSprint/{id}")]
		public async Task<ObjectResult> DeleteSprintAsync([FromRoute] int id)
		{
			Sprint sprint = await _sprintServices.SprintRepository.GetByIdAsync(id);
			_sprintServices.SprintRepository.Delete(sprint);
			await _sprintServices.CommitChanges();

			return Ok(sprint);
		}

	}
}