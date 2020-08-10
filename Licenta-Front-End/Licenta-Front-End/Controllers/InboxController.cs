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
	public class InboxController : Controller
	{

		ProductApi _api = new ProductApi();

		public async Task<IActionResult> Index(String searching)
		{
			List<Inbox> inboxes = new List<Inbox>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/inbox/getallinboxes");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				inboxes = JsonConvert.DeserializeObject<List<Inbox>>(result);
			}

			if (!String.IsNullOrEmpty(searching))
			{
				inboxes = inboxes.Where(s => s.Sender.Contains(searching)
											  || s.Recipient.Contains(searching)
											  || s.Message.Contains(searching)).ToList();
			}

			return View(inboxes);

		}


		public async Task<IActionResult> EmployeeMails(String searching)
		{
			List<Inbox> inboxes = new List<Inbox>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/inbox/getallinboxes");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				inboxes = JsonConvert.DeserializeObject<List<Inbox>>(result);
			}

			inboxes = inboxes.Where(s => s.Recipient.Equals(HttpContext.Session.GetString("Email"))).ToList();

			if (!String.IsNullOrEmpty(searching))
			{
				inboxes = inboxes.Where(s => s.Sender.Contains(searching)
											  || s.Recipient.Contains(searching)
											  || s.Message.Contains(searching)
											  || s.Title.Contains(searching)).ToList();
			}

			return View(inboxes);

		}


		public async Task<IActionResult> Details(int Id)
		{
			var inbox = new Inbox();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/inbox/getinbox/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				inbox = JsonConvert.DeserializeObject<Inbox>(result);
			}
			return View(inbox);

		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Inbox inbox)
		{
			HttpClient client = _api.Initial();

			var postTask = client.PostAsJsonAsync<Inbox>("api/inbox/createinbox", inbox);
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
			var inbox = new Inbox();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.DeleteAsync($"api/inbox/Deleteinbox/{Id}");

			return RedirectToAction("Index");

		}

		public async Task<IActionResult> Edit(int Id)
		{
			var inbox = new Inbox();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/inbox/Getinbox/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				inbox = JsonConvert.DeserializeObject<Inbox>(result);
			}


			return View(inbox);

		}


		[HttpPost]
		public async Task<IActionResult> Edit(Inbox inbox)
		{
			HttpClient client = _api.Initial();

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/inbox/Updateinbox/{inbox.Id}", inbox);
			response.EnsureSuccessStatusCode();

			inbox = await response.Content.ReadAsAsync<Inbox>();


			return RedirectToAction("Index");
		}

		//read message method
		public async Task<IActionResult> Read(int Id)
		{
			var inbox = new Inbox();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/inbox/getinbox/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				inbox = JsonConvert.DeserializeObject<Inbox>(result);
			}

			if (inbox.Status == "Read")
			{

			}
			else if (inbox.Status == "Unread")
			{
				inbox.Status = "Read";
				int status = Convert.ToInt32(HttpContext.Session.GetString("InboxStatus"));
				status--;
				HttpContext.Session.SetString("InboxStatus",  status.ToString());
			}
			
			

			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/inbox/Updateinbox/{Id}", inbox);
			response.EnsureSuccessStatusCode();

			inbox = await response.Content.ReadAsAsync<Models.Inbox>();


			return View(inbox);

		}

		//reply to email
		public ActionResult Reply(String sender)
		{
			var inbox = new Inbox();
			inbox.Sender = sender;
			inbox.Recipient = HttpContext.Session.GetString("Email");
			
			return View(inbox);
		}

		[HttpPost]
		public IActionResult Reply(Inbox inbox)
		{
			HttpClient client = _api.Initial();
			inbox.Status ="Unread";
			var postTask = client.PostAsJsonAsync<Inbox>("api/inbox/createinbox", inbox);
			postTask.Wait();

			var result = postTask.Result;
			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("EmployeeMails");
			}

			return RedirectToAction("EmployeeMails");
		}

		//send email
		public ActionResult Send(String sender)
		{
			var inbox = new Inbox();
			inbox.Sender = sender;
			inbox.Recipient = HttpContext.Session.GetString("Email");

			return View(inbox);
		}

		[HttpPost]
		public IActionResult Send(Inbox inbox)
		{
			HttpClient client = _api.Initial();
			inbox.Status = "Unread";
			var postTask = client.PostAsJsonAsync<Inbox>("api/inbox/createinbox", inbox);
			postTask.Wait();

			var result = postTask.Result;
			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("EmployeeMails");
			}

			return RedirectToAction("EmployeeMails");
		}
	}
}