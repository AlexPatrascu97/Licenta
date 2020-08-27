using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FrontTest.HTTPHelpers;
using Licenta_Front_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Licenta_Front_End.Controllers
{
	public class TeamController : Controller
	{

		ProductApi _api = new ProductApi();

		public async Task<IActionResult> Index(String searching)
		{
			List<Team> teams = new List<Team>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/team/getallteams");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				teams = JsonConvert.DeserializeObject<List<Team>>(result);
			}

			if (!String.IsNullOrEmpty(searching))
			{
				teams = teams.Where(s => s.ProjectName.ToLower().Contains(searching.ToLower())
											  || s.TeamLeaderFirstName.ToLower().Contains(searching.ToLower())
											  || s.TeamLeaderLastName.ToLower().Contains(searching.ToLower())
											  || s.FirstName.ToLower().Contains(searching.ToLower())
											  || s.LastName.ToLower().Equals(searching.ToLower())
											  ).ToList();
			}
			return View(teams);

		}


		public async Task<IActionResult> Details(int Id)
		{
			var team = new Team();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/team/getteam/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				team = JsonConvert.DeserializeObject<Team>(result);
			}
			return View(team);

		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Team team)
		{
			HttpClient client = _api.Initial();

			var postTask = client.PostAsJsonAsync<Team>("api/team/createteam", team);
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
			var team = new Team();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.DeleteAsync($"api/team/Deleteteam/{Id}");

			return RedirectToAction("Index");

		}

		public async Task<IActionResult> Edit(int Id)
		{
			var team = new Team();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/team/Getteam/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				team = JsonConvert.DeserializeObject<Team>(result);
			}


			return View(team);

		}


		[HttpPost]
		public async Task<IActionResult> Edit(Team team)
		{
			HttpClient client = _api.Initial();

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/team/Updateteam/{team.Id}", team);
			response.EnsureSuccessStatusCode();

			team = await response.Content.ReadAsAsync<Team>();


			return RedirectToAction("Index");
		}


		//get the projects of the employee
		public async Task<IActionResult> IndexEmpProjects(String searching)
		{
			List<Team> teams = new List<Team>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/team/getallteams");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				teams = JsonConvert.DeserializeObject<List<Team>>(result);
			}

			String FirstName = HttpContext.Session.GetString("FirstName");
			String LastName = HttpContext.Session.GetString("LastName");

			teams = teams.Where(s => s.FirstName.Contains(FirstName)
											  && s.LastName.Contains(LastName)
											  ).ToList();

			return View(teams);

		}


		//get the projects members
		public async Task<IActionResult> Members(String searching)
		{
			List<Member> teams = new List<Member>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/team/EmployeeTeamsJoin");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				teams = JsonConvert.DeserializeObject<List<Member>>(result);
			}


			teams = teams.Where(s => s.ProjectName.Contains(searching)).ToList();

			return View(teams);

		}

		public async Task<IActionResult> IndexLeader(String searching)
		{
			List<Team> teams = new List<Team>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/team/getallteams");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				teams = JsonConvert.DeserializeObject<List<Team>>(result);
			}

			String FirstName = HttpContext.Session.GetString("FirstName");
			String LastName = HttpContext.Session.GetString("LastName");

			teams = teams.Where(s => s.TeamLeaderFirstName.Equals(FirstName)
											  && s.TeamLeaderLastName.Equals(LastName)
											  ).GroupBy(s => s.ProjectName)
											   .Select(grp => grp.First()).ToList();

			 

			if (!String.IsNullOrEmpty(searching))
			{
				teams = teams.Where(s => s.ProjectName.Contains(searching)
											  || s.FirstName.Contains(searching)
											  || s.LastName.Equals(searching)
											  ).ToList();
			}
			return View(teams);

		}


		

		//get team members
		public async Task<IActionResult> TeamMembers(String searching)
		{
			List<Member> teams = new List<Member>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/team/EmployeeTeamsJoin");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				teams = JsonConvert.DeserializeObject<List<Member>>(result);


			}


			teams = teams.Where(s => s.ProjectName.Equals(searching)).ToList();

			return View(teams);

		}

		//add members
		public ActionResult AddMember(String leaderfn, String leaderln, String projn)
		{
			var Team = new Team();
			Team.ProjectName = projn;
			Team.TeamLeaderFirstName = leaderfn;
			Team.TeamLeaderLastName = leaderln;

			

			return View(Team);
		}

		[HttpPost]
		public IActionResult AddMember(Team team)
		{
			HttpClient client = _api.Initial();

			var postTask = client.PostAsJsonAsync<Team>("api/team/createteam", team);
			postTask.Wait();


			var result = postTask.Result;
			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("IndexLeader");
			}

			return View();
		}

		public async Task<IActionResult> DetailsProjectForLeader(String prjn)
		{
			List<Project> Projects = new List<Project>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/project/getallprojects");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				Projects = JsonConvert.DeserializeObject<List<Project>>(result);
			}
			Projects = Projects.Where(s => s.ProjectName.Equals(prjn)).ToList();

			var project = new Project();
			project = Projects[0];
			return View(project);

		}

	}
}