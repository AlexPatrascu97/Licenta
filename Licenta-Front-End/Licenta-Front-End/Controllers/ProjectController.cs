using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontTest.HTTPHelpers;
using Microsoft.AspNetCore.Mvc;
using Licenta_Front_End.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Licenta_Front_End.Controllers
{
    public class ProjectController : Controller
    {

		ProductApi _api = new ProductApi();

		public async Task<IActionResult> Index(String searching)
		{
			List<Project> projects = new List<Project>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/project/getallprojects");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				projects = JsonConvert.DeserializeObject<List<Project>>(result);
			}

			if (!String.IsNullOrEmpty(searching))
			{
				projects = projects.Where(s => s.ProjectName.Contains(searching)
											  || s.TeamLeader.Contains(searching)
											  || s.ClientName.Contains(searching)
											  || s.AllocatedMoney.Equals(searching)
											  || s.StartDate.Year.Equals(searching)
											  || s.StartDate.Day.Equals(searching)
											  || s.StartDate.Month.Equals(searching)
											  ).ToList();
			}
			return View(projects);

		}
  
		
  
		public async Task<IActionResult> IndexForLeader(String searching)
		{
			List<Project> projects = new List<Project>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/project/getallprojects");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				projects = JsonConvert.DeserializeObject<List<Project>>(result);
			}

			


			if (!String.IsNullOrEmpty(searching))
			{
				projects = projects.Where(s => s.ProjectName.Contains(searching)
											  || s.TeamLeader.Contains(searching)
											  || s.ClientName.Contains(searching)
											  || s.AllocatedMoney.Equals(searching)
											  || s.StartDate.Year.Equals(searching)
											  || s.StartDate.Day.Equals(searching)
											  || s.StartDate.Month.Equals(searching)
											  ).ToList();
			}
			return View(projects);

		}


		public async Task<IActionResult> Details(int Id)
		{
			var project = new Project();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/project/getproject/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				project = JsonConvert.DeserializeObject<Project>(result);
			}
			return View(project);

		}


		public async Task<IActionResult> DetailsLeader(int Id)
		{
			var project = new Project();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/project/getproject/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				project = JsonConvert.DeserializeObject<Project>(result);
			}
			return View(project);

		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Project project)
		{
			HttpClient client = _api.Initial();

			var postTask = client.PostAsJsonAsync<Project>("api/project/createproject", project);
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
			var project = new Project();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.DeleteAsync($"api/project/DeleteProject/{Id}");

			return RedirectToAction("Index");

		}



		public async Task<IActionResult> Edit(int Id)
		{
			var project = new Project();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/project/GetProject/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				project = JsonConvert.DeserializeObject<Project>(result);
			}


			return View(project);

		}


		[HttpPost]
		public async Task<IActionResult> Edit(Project project)
		{
			HttpClient client = _api.Initial();

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/project/UpdateProject/{project.Id}", project);
			response.EnsureSuccessStatusCode();

			project = await response.Content.ReadAsAsync<Project>();


			return RedirectToAction("Index");
		}


		//edit for leader
		public async Task<IActionResult> EditLeader(int Id)
		{
			var project = new Project();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/project/GetProject/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				project = JsonConvert.DeserializeObject<Project>(result);
			}


			return View(project);

		}


		[HttpPost]
		public async Task<IActionResult> EditLeader(Project project)
		{
			HttpClient client = _api.Initial();

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/project/UpdateProject/{project.Id}", project);
			response.EnsureSuccessStatusCode();

			project = await response.Content.ReadAsAsync<Project>();


			return RedirectToAction("IndexForLeader");
		}


		//leader create projects
		public ActionResult CreateProjectLeader()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateProjectLeader(Project project)
		{
			HttpClient client = _api.Initial();

			var postTask = client.PostAsJsonAsync<Project>("api/project/createproject", project);
			postTask.Wait();

			var result = postTask.Result;
			if (result.IsSuccessStatusCode)
			{


				Team team = new Team();

				String FirstName = HttpContext.Session.GetString("FirstName");
				String LastName = HttpContext.Session.GetString("LastName");

				team.ProjectName = project.ProjectName;
				team.FirstName = FirstName;
				team.LastName = LastName;
				team.TeamLeaderFirstName = FirstName;
				team.TeamLeaderLastName = LastName;

				var postTask2 = client.PostAsJsonAsync<Team>("api/team/createteam", team);
				postTask2.Wait();

				var result2 = postTask.Result;
				if (result2.IsSuccessStatusCode)
				{
					return RedirectToAction("IndexForLeader");
				}

			}

			return View();
		}

	}
}