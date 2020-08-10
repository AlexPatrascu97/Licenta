using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FrontTest.HTTPHelpers;
using Licenta_Front_End.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Licenta_Front_End.Controllers
{
	public class MeetingController : Controller
	{
		ProductApi _api = new ProductApi();

		public async Task<IActionResult> Index(String searching)
		{
			List<Meeting> meetings = new List<Meeting>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/Meeting/getallmeetings");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				meetings = JsonConvert.DeserializeObject<List<Meeting>>(result);
			}

			if (!String.IsNullOrEmpty(searching))
			{
				meetings = meetings.Where(s => s.ProjectName.Contains(searching)
											  || s.Link.Contains(searching)
											  || s.Details.Contains(searching)
											  ).ToList();
			}
			return View(meetings);

		}


		public async Task<IActionResult> Details(int Id)
		{
			var meeting = new Meeting();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/meeting/getmeeting/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				meeting = JsonConvert.DeserializeObject<Meeting>(result);
			}
			return View(meeting);

		}
		
		public async Task<IActionResult> DetailsForLeader(int Id)
		{
			var meeting = new Meeting();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/meeting/getmeeting/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				meeting = JsonConvert.DeserializeObject<Meeting>(result);
			}
			return View(meeting);

		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Meeting meeting)
		{
			HttpClient client = _api.Initial();

			var postTask = client.PostAsJsonAsync<Meeting>("api/meeting/createmeeting", meeting);
			postTask.Wait();

			String Role = HttpContext.Session.GetString("Role");

			var result = postTask.Result;
			if (result.IsSuccessStatusCode)
			{
				if ((Role == "Leader") || (Role == "Developer"))
				{
					return RedirectToAction("IndexForDevAndLead");
				}
				else
				{
					return RedirectToAction("Index");
				}
				
			}

			return View();
		}


		public ActionResult CreateForLeader()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateForLeader(Meeting meeting)
		{
			HttpClient client = _api.Initial();

			var postTask = client.PostAsJsonAsync<Meeting>("api/meeting/createmeeting", meeting);
			postTask.Wait();

			var result = postTask.Result;
			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("IndexForDevAndLead");
			}

			String Role = HttpContext.Session.GetString("Role");

			if ((Role == "Leader") || (Role == "Developer"))
			{
				return RedirectToAction("IndexForDevAndLead");
			}
			else
			{
				return View();
			}
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int Id)
		{
			var meeting = new Meeting();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.DeleteAsync($"api/meeting/Deletemeeting/{Id}");


			String Role = HttpContext.Session.GetString("Role");

			if ((Role == "Leader") || (Role == "Developer"))
			{
				return RedirectToAction("IndexForDevAndLead");
			}
			else {
				return RedirectToAction("Index");
			}

		}

		public async Task<IActionResult> Edit(int Id)
		{
			var meeting = new Meeting();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/meeting/Getmeeting/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				meeting = JsonConvert.DeserializeObject<Meeting>(result);
			}


			return View(meeting);

		}
		/*
		public async Task<IActionResult> EditForLeader(int Id)
		{
			var meeting = new Meeting();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/meeting/Getmeeting/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				meeting = JsonConvert.DeserializeObject<Meeting>(result);
			}


			return View(meeting);

		}
		[HttpPost]
		public async Task<IActionResult> EditForLeader(Meeting meeting)
		{
			HttpClient client = _api.Initial();

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/meeting/Updatemeeting/{meeting.Id}", meeting);
			response.EnsureSuccessStatusCode();

			meeting = await response.Content.ReadAsAsync<Meeting>();


			return RedirectToAction("IndexForDevAndLead");
		}*/



		[HttpPost]
		public async Task<IActionResult> Edit(Meeting meeting)
		{
			HttpClient client = _api.Initial();

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/meeting/Updatemeeting/{meeting.Id}", meeting);
			response.EnsureSuccessStatusCode();

			meeting = await response.Content.ReadAsAsync<Meeting>();


			String Role = HttpContext.Session.GetString("Role");
			if (Role == "Leader")
			{
				return RedirectToAction("IndexForDevAndLead");
			}
			else {
				return RedirectToAction("Index");
			}
		}


		public async Task<IActionResult> IndexForDevAndLead(String searching)
		{
			List<Meeting> meetings = new List<Meeting>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/Meeting/getallmeetings");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				meetings = JsonConvert.DeserializeObject<List<Meeting>>(result);
			}

			List<Models.Team> teams = new List<Models.Team>();
			HttpResponseMessage res2 = await client.GetAsync("api/team/getallteams");
			if (res2.IsSuccessStatusCode)
			{
				var result2 = res2.Content.ReadAsStringAsync().Result;
				teams = JsonConvert.DeserializeObject<List<Models.Team>>(result2);
			}

			String FirstName = HttpContext.Session.GetString("FirstName");
			String LastName = HttpContext.Session.GetString("LastName");

			List<Models.Meeting> DevAndLead = new List<Models.Meeting>();


			foreach (var meet in meetings)
			{
				foreach (var team in teams)
				{
					if ((meet.ProjectName.Equals(team.ProjectName)) && (team.FirstName == FirstName) && (team.LastName == LastName))
					{
						DevAndLead.Add(meet);
					}
				}

			}

			if (!String.IsNullOrEmpty(searching))
			{
				DevAndLead = DevAndLead.Where(s => s.ProjectName.Contains(searching)
											  || s.Link.Contains(searching)
											  || s.Details.Contains(searching)
											  ).ToList();
				
			}

			return View(DevAndLead);

		}


	}
}
