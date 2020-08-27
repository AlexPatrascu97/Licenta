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
    public class TaskController : Controller
    {
		ProductApi _api = new ProductApi();

		public async Task<IActionResult> Index(String searching)
		{
			List<Models.Task> tasks = new List<Models.Task>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/task/getalltasks");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				tasks = JsonConvert.DeserializeObject<List<Models.Task>>(result);
			}

			if (!String.IsNullOrEmpty(searching))
			{
				tasks = tasks.Where(s => s.TaskName.ToLower().Contains(searching.ToLower()) || s.ProjectName.ToLower().Contains(searching.ToLower()) || s.Status.ToLower().Contains(searching.ToLower())).ToList();
			}

			return View(tasks);

		}

		//get employees personal tasks
		public async Task<IActionResult> TasksForEmployee(String searching)
		{
			List<Models.Task> tasks = new List<Models.Task>();
			HttpClient client = _api.Initial();
			String Id = HttpContext.Session.GetString("Id");
			HttpResponseMessage res = await client.GetAsync("api/task/GetTaskForEmployeeID/" + Id);
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				tasks = JsonConvert.DeserializeObject<List<Models.Task>>(result);
			}


			if (!String.IsNullOrEmpty(searching))
			{
				tasks = tasks.Where(s => s.sprintNumber.Equals(searching)
											  || s.ProjectName.Contains(searching)
											  || s.TaskOwnerID.Equals(searching)
											  || s.Details.Contains(searching)
											  ).ToList();
			}
			return View(tasks);

		}



		public async Task<IActionResult> Details(int Id)
		{
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/task/gettask/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				task = JsonConvert.DeserializeObject<Models.Task>(result);
			}
			return View(task);

		}
		public async Task<IActionResult> DetailsForRedeem(int Id)
		{
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/task/gettask/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				task = JsonConvert.DeserializeObject<Models.Task>(result);
			}
			return View(task);

		}

		//details for leader
		public async Task<IActionResult> DetailsLeader(int Id)
		{
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/task/gettask/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				task = JsonConvert.DeserializeObject<Models.Task>(result);
			}
			return View(task);

		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Models.Task task)
		{
			HttpClient client = _api.Initial();

			var postTask = client.PostAsJsonAsync<Models.Task> ("api/task/createtask", task);
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
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.DeleteAsync($"api/task/Deletetask/{Id}");

			return RedirectToAction("Index");

		}

		[HttpGet]
		public async Task<IActionResult> DeleteLeader(int Id)
		{
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.DeleteAsync($"api/task/Deletetask/{Id}");

			return RedirectToAction("IndexForLeader");

		}
		public async Task<IActionResult> Edit(int Id)
		{
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/task/gettask/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				task = JsonConvert.DeserializeObject<Models.Task>(result);
			}


			return View(task);

		}
		

		[HttpPost]
		public async Task<IActionResult> Edit(Models.Task task)
		{
			HttpClient client = _api.Initial();
			

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/task/Updatetask/{task.Id}", task);
			response.EnsureSuccessStatusCode();

			task = await response.Content.ReadAsAsync<Models.Task>();

			String Role = HttpContext.Session.GetString("Role");

			if (Role == "Leader")
			{

				return RedirectToAction("IndexForLeader");
			}
			else
			{
				return RedirectToAction("Index");
			}
		}

		//edit for leader
		public async Task<IActionResult> EditLeader(int Id)
		{
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/task/gettask/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				task = JsonConvert.DeserializeObject<Models.Task>(result);
			}


			return View(task);

		}


		[HttpPost]
		public async Task<IActionResult> EditLeader(Models.Task task)
		{
			HttpClient client = _api.Initial();

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/task/Updatetask/{task.Id}", task);
			response.EnsureSuccessStatusCode();

			task = await response.Content.ReadAsAsync<Models.Task>();


			return RedirectToAction("Index");
		}


		//employees can complete tasks
		public async Task<IActionResult> TaskStatus(int Id)
		{
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/task/gettask/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				task = JsonConvert.DeserializeObject<Models.Task>(result);
			}
			task.Status = "Finished";

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/task/Updatetask/{Id}", task);
			response.EnsureSuccessStatusCode();

			task = await response.Content.ReadAsAsync<Models.Task>();

			return RedirectToAction("TasksForEmployee");

		}

		//employees can edit some properties of the task
		//in case the task was not completed properly
		public async Task<IActionResult> EditTasks(int Id)
		{
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/task/gettask/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				task = JsonConvert.DeserializeObject<Models.Task>(result);
			}


			return View(task);

		}


		[HttpPost]
		public async Task<IActionResult> EditTasks(Models.Task task)
		{
			HttpClient client = _api.Initial();

			String FirstName = HttpContext.Session.GetString("FirstName");
			String LastName = HttpContext.Session.GetString("LastName");
			task.TaskOwnerFirstName = FirstName;
			task.TaskOwnerLastName = LastName;

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/task/Updatetask/{task.Id}", task);
			response.EnsureSuccessStatusCode();

			task = await response.Content.ReadAsAsync<Models.Task>();


			return RedirectToAction("TasksForEmployee");
		}

		public async Task<IActionResult> RedeemTasks()
		{
			//get list of tasks
			List<Models.Task> tasks = new List<Models.Task>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/task/getalltasks");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				tasks = JsonConvert.DeserializeObject<List<Models.Task>>(result);
			}

			//get employee list of projects
			List<Team> teams = new List<Team>();
			HttpResponseMessage res2 = await client.GetAsync("api/team/getallteams");
			if (res.IsSuccessStatusCode)
			{
				var result = res2.Content.ReadAsStringAsync().Result;
				teams = JsonConvert.DeserializeObject<List<Team>>(result);
			}

			String FirstName = HttpContext.Session.GetString("FirstName");
			String LastName = HttpContext.Session.GetString("LastName");

			teams = teams.Where(s => s.FirstName.Contains(FirstName)
											  && s.LastName.Contains(LastName)
											  ).ToList();

			//initialize list with tasks from employees active projects
			List<Models.Task> redeemtasks = new List<Models.Task>();

			foreach (var tsk in tasks)
			{
				foreach (var prj in teams)
				{

					if (tsk.ProjectName.Equals(prj.ProjectName)) {
						redeemtasks.Add(tsk);
					}
				}
			}
			
			return View(redeemtasks);

		}

		//redeem task button
		public async Task<IActionResult> Redeem(int Id)
		{
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/task/gettask/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				task = JsonConvert.DeserializeObject<Models.Task>(result);
			}
			String id = HttpContext.Session.GetString("Id");
			String FirstName = HttpContext.Session.GetString("FirstName");
			String LastName = HttpContext.Session.GetString("LastName");

			task.TaskOwnerID = Convert.ToInt32(id);
			task.TaskOwnerFirstName = FirstName;
			task.TaskOwnerLastName = LastName;

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/task/Updatetask/{Id}", task);
			response.EnsureSuccessStatusCode();

			task = await response.Content.ReadAsAsync<Models.Task>();

			return RedirectToAction("RedeemTasks");

		}


		//remove task button
		public async Task<IActionResult> Remove(int Id)
		{
			var task = new Models.Task();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/task/gettask/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				task = JsonConvert.DeserializeObject<Models.Task>(result);
			}
			
			task.TaskOwnerID = null;
			task.TaskOwnerFirstName = null;
			task.TaskOwnerLastName = null;

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/task/Updatetask/{Id}", task);
			response.EnsureSuccessStatusCode();

			task = await response.Content.ReadAsAsync<Models.Task>();

			return RedirectToAction("TasksForEmployee");

		}

		//index for leaders
		public async Task<IActionResult> IndexForLeader(String searching)
		{
			List<Models.Task> tasks = new List<Models.Task>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/task/getalltasks");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				tasks = JsonConvert.DeserializeObject<List<Models.Task>>(result);
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

			teams = teams.Where(s => s.TeamLeaderFirstName.Equals(FirstName)
											  && s.TeamLeaderLastName.Equals(LastName)
											  ).GroupBy(s => s.ProjectName)
											   .Select(grp => grp.First()).ToList();

			List<Models.Task> tasksforleader = new List<Models.Task>();

			foreach (var task in tasks)
			{
				foreach (var pro in teams)
				{
					if (task.ProjectName.Equals(pro.ProjectName)) 
					{
						tasksforleader.Add(task);
					}
				}

			}


			if (!String.IsNullOrEmpty(searching))
			{
				tasksforleader = tasksforleader.Where(s => s.TaskName.Contains(searching)
											  || s.ProjectName.ToLower().Contains(searching.ToLower())
											  || s.Details.ToLower().Contains(searching.ToLower())
											  || s.Status.ToLower().Contains(searching.ToLower())
											  ).ToList();
			}
			return View(tasksforleader);

		}


		//create for leader

		public ActionResult CreateLeader()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateLeader(Models.Task task)
		{
			HttpClient client = _api.Initial();
			task.Status = "Ongoing";
			var postTask = client.PostAsJsonAsync<Models.Task>("api/task/createtask", task);
			postTask.Wait();

			var result = postTask.Result;
			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("IndexForLeader");
			}

			return View();
		}
	}
}