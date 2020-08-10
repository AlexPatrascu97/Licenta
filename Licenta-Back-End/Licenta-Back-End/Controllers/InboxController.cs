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
	[Route("api/inbox")]
	[ApiController]
	public class InboxController : ControllerBase
	{
		private readonly IInboxServices _inboxServices;

		public InboxController(IInboxServices inboxServices)
		{
			_inboxServices = inboxServices;
		}

		[HttpGet("GetAllInboxes")]
		public async Task<ObjectResult> GetAllInboxesAsync()
		{
			List<Inbox> result = await _inboxServices.InboxRepository.GetAllAsync();

			return Ok(result);
		}



		[HttpGet("GetInbox/{id}")]
		public async Task<ObjectResult> GetInboxeAsync([FromRoute] int id)
		{
			Inbox result = await _inboxServices.InboxRepository.GetByIdAsync(id);

			return Ok(result);
		}


		[HttpPost("CreateInbox")]
		public async Task<ObjectResult> CreateInboxAsync([FromBody] GeneralInboxRequest request)
		{
			Inbox result = await _inboxServices.InboxRepository.CreateAsync(request.ToDTOInbox());
			await _inboxServices.CommitChanges();

			return Ok(result);
		}

		[HttpPut("UpdateInbox/{id}")]
		public async Task<ObjectResult> UpdateInboxAsync([FromBody] GeneralInboxRequest request, [FromRoute] int id)
		{
			Inbox result = _inboxServices.InboxRepository.Update(request.ToDTOInbox(id));
			await _inboxServices.CommitChanges();

			return Ok(result);
		}

		[HttpDelete("DeleteInbox/{id}")]
		public async Task<ObjectResult> DeleteInboxAsync([FromRoute] int id)
		{
			Inbox inbox = await _inboxServices.InboxRepository.GetByIdAsync(id);
			_inboxServices.InboxRepository.Delete(inbox);
			await _inboxServices.CommitChanges();

			return Ok(inbox);
		}

	}
}