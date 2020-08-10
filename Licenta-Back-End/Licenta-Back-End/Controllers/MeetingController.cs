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
	[Route("api/meeting")]
	[ApiController]
	public class MeetingsController : ControllerBase
	{
		private readonly IMeetingServices _meetingServices;

		public MeetingsController(IMeetingServices meetingServices)
		{
			_meetingServices = meetingServices;
		}

		[HttpGet("GetAllMeetings")]
		public async Task<ObjectResult> GetAllMeetingsAsync()
		{
			List<Meeting> result = await _meetingServices.MeetingRepository.GetAllAsync();

			return Ok(result);
		}







		[HttpGet("GetMeeting/{id}")]
		public async Task<ObjectResult> GetMeetingAsync([FromRoute] int id)
		{
			Meeting result = await _meetingServices.MeetingRepository.GetByIdAsync(id);

			return Ok(result);
		}


		[HttpPost("CreateMeeting")]
		public async Task<ObjectResult> CreateMeetingAsync([FromBody] GeneralMeetingRequest request)
		{
			Meeting result = await _meetingServices.MeetingRepository.CreateAsync(request.ToDTOMeeting());
			await _meetingServices.CommitChanges();

			return Ok(result);
		}

		[HttpPut("UpdateMeeting/{id}")]
		public async Task<ObjectResult> UpdateMeetingAsync([FromBody] GeneralMeetingRequest request, [FromRoute] int id)
		{
			Meeting result = _meetingServices.MeetingRepository.Update(request.ToDTOMeeting(id));
			await _meetingServices.CommitChanges();

			return Ok(result);
		}

		[HttpDelete("DeleteMeeting/{id}")]
		public async Task<ObjectResult> DeleteMeetingAsync([FromRoute] int id)
		{
			Meeting meeting = await _meetingServices.MeetingRepository.GetByIdAsync(id);
			_meetingServices.MeetingRepository.Delete(meeting);
			await _meetingServices.CommitChanges();

			return Ok(meeting);
		}

	}
}