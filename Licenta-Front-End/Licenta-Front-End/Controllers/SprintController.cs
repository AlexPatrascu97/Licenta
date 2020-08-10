using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FrontTest.HTTPHelpers;
using Licenta_Front_End.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Licenta_Front_End.Controllers
{
    public class SprintController : Controller
    {

		ProductApi _api = new ProductApi();

		public async Task<IActionResult> Index(String searching)
		{
			List<Sprint> sprints = new List<Sprint>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/sprint/getallsprints");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				sprints = JsonConvert.DeserializeObject<List<Sprint>>(result);
			}
			
			if (!String.IsNullOrEmpty(searching))
			{
				sprints = sprints.Where(s => s.SprintNumber.Equals(searching)
											  || s.ProjectName.Contains(searching)  
											  || s.startdate.Year.Equals(searching)
											  || s.startdate.Day.Equals(searching)
											  || s.startdate.Month.Equals(searching)
											  || s.status.Contains(searching)
											  ).ToList();
			}
			return View(sprints);

		}


		public async Task<IActionResult> Details(int Id)
		{
			var sprint = new Sprint();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/sprint/getsprint/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				sprint = JsonConvert.DeserializeObject<Sprint>(result);
			}
			return View(sprint);

		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Sprint sprint)
		{
			HttpClient client = _api.Initial();

			var postTask = client.PostAsJsonAsync<Sprint>("api/sprint/createsprint", sprint);
			postTask.Wait();

			var result = postTask.Result;
			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int Id)
		{
			var sprint = new Sprint();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.DeleteAsync($"api/sprint/DeleteSprint/{Id}");

			return RedirectToAction("Index");

		}

		public async Task<IActionResult> Edit(int Id)
		{
			var sprint = new Sprint();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/sprint/GetSprint/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				sprint = JsonConvert.DeserializeObject<Sprint>(result);
			}


			return View(sprint);

		}


		[HttpPost]
		public async Task<IActionResult> Edit(Sprint sprint)
		{
			HttpClient client = _api.Initial();

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/sprint/UpdateSprint/{sprint.Id}", sprint);
			response.EnsureSuccessStatusCode();

			sprint = await response.Content.ReadAsAsync<Sprint>();


			return RedirectToAction("Index");
		}

		//Employees Get Sprints
		public async Task<IActionResult> GetSprints(String searching)
		{
			List<Sprint> sprints = new List<Sprint>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/sprint/getallsprints");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				sprints = JsonConvert.DeserializeObject<List<Sprint>>(result);
			}

			if (!String.IsNullOrEmpty(searching))
			{
				sprints = sprints.Where(s => s.SprintNumber.Equals(searching)
											  || s.ProjectName.Contains(searching)
											  || s.startdate.Year.Equals(searching)
											  || s.startdate.Day.Equals(searching)
											  || s.startdate.Month.Equals(searching)
											  || s.status.Contains(searching)
											  ).ToList();
			}
			return View(sprints);

		}

	}
}
