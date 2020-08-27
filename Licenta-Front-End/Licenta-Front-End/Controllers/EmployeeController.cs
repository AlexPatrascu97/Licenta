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
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Licenta_Front_End.Controllers
{
	public class EmployeeController : Controller
	{

		ProductApi _api = new ProductApi();
		int inboxstatus = 0;

		public async Task<IActionResult> Index(string searching)
		{
			List<Employee> employees = new List<Employee>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/employee/getallemployees");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				employees = JsonConvert.DeserializeObject<List<Employee>>(result);
			}

			if (!String.IsNullOrEmpty(searching))
			{
				employees = employees.Where(s => s.FirstName.ToLower().Contains(searching.ToLower())
											  || s.LastName.ToLower().Contains(searching.ToLower())
											  || s.Role.ToLower().Contains(searching.ToLower())).ToList();
			}



			return View(employees);

		}

		public async Task<IActionResult> Details(int Id)
		{
			var employee = new Employee();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/employee/GetEmployee/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				employee = JsonConvert.DeserializeObject<Employee>(result);
			}
			return View(employee);

		}

		public ActionResult Create()
		{
			return View();
		}

		StringBuilder builder;
		[HttpPost]
		public IActionResult Create(Employee employee)
		{
			HttpClient client = _api.Initial();
			/*String pass = employee.Password;
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// ComputeHash - returns byte array  
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));

				// Convert byte array to a string   
			     builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				
			}

			employee.Password = builder.ToString();*/

			employee.Password = Encrypt(employee.Password);
			var postTask = client.PostAsJsonAsync<Employee>("api/employee/createemployee", employee);
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
			var employee = new Employee();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.DeleteAsync($"api/employee/DeleteEmployee/{Id}");

			return RedirectToAction("Index");

		}

		public async Task<IActionResult> Edit(int Id)
		{
			var employee = new Employee();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync($"api/employee/GetEmployee/{Id}");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				employee = JsonConvert.DeserializeObject<Employee>(result);
			}
			return View(employee);

		}


		[HttpPost]
		public async Task<IActionResult> Edit(Employee employee)
		{
			HttpClient client = _api.Initial();

			employee.Password = Encrypt(employee.Password);
			HttpResponseMessage response = await client.PutAsJsonAsync(
				$"api/employee/UpdateEmployee/{employee.Id}", employee);
			response.EnsureSuccessStatusCode();

			employee = await response.Content.ReadAsAsync<Employee>();


			return RedirectToAction("Index");
		}


		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(Employee model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}


			List<Employee> users = new List<Employee>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/employee/getallemployees");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				users = JsonConvert.DeserializeObject<List<Employee>>(result);
			}

			List<Inbox> inboxes = new List<Inbox>();
			HttpResponseMessage res2 = await client.GetAsync("api/inbox/getallinboxes");
			if (res.IsSuccessStatusCode)
			{
				var result = res2.Content.ReadAsStringAsync().Result;
				inboxes = JsonConvert.DeserializeObject<List<Inbox>>(result);
			}

			foreach (var user in users)
			{
				if ((user.FirstName == model.FirstName) && ((user.Password == model.Password) || ((user.Password == Encrypt(model.Password)))) && (user.LastName == model.LastName))
				{
					HttpContext.Session.SetString("FirstName", user.FirstName);
					HttpContext.Session.SetString("LastName", user.LastName);
					HttpContext.Session.SetString("Role", user.Role);
					HttpContext.Session.SetString("Email", user.Email);
					HttpContext.Session.SetString("Id", user.Id.ToString());

					foreach (var inbox in inboxes)
					{
						if ((inbox.Recipient == user.Email) && (inbox.Status == "Unread"))
						{
							inboxstatus++;
						}
					}

					HttpContext.Session.SetString("InboxStatus", inboxstatus.ToString());
					inboxstatus = 0;

					return View("~/Views/Home/Index.cshtml");

				}



			}

			return View(model);
		}

		public async Task<ActionResult> LogOut()
		{

			HttpContext.Session.Remove("FirstName");
			HttpContext.Session.Remove("LastName");
			HttpContext.Session.Remove("Role");
			HttpContext.Session.Remove("Id");
			HttpContext.Session.Remove("InboxStatus");
			return View("~/Views/Employee/Login.cshtml");


		}


		//get all employees for leaders
		public async Task<IActionResult> IndexEmployeeeForLeader(string searching)
		{
			List<Employee> employees = new List<Employee>();
			List<Employee> employeeswithnoproject = new List<Employee>();
			List<Team> teams = new List<Team>();
			HttpClient client = _api.Initial();
			HttpResponseMessage res = await client.GetAsync("api/employee/getallemployees");
			if (res.IsSuccessStatusCode)
			{
				var result = res.Content.ReadAsStringAsync().Result;
				employees = JsonConvert.DeserializeObject<List<Employee>>(result);


				HttpResponseMessage res2 = await client.GetAsync("api/team/getallteams");
				var result2 = res2.Content.ReadAsStringAsync().Result;
				teams = JsonConvert.DeserializeObject<List<Team>>(result2);

				foreach (var emp in employees)
				{
					foreach (var team in teams)
					{
						if ((emp.FirstName == team.FirstName) && (emp.LastName == team.LastName))
						{

						}
						else
						{
							employeeswithnoproject.Add(emp);
						}
					}
				}

			}

			if (!String.IsNullOrEmpty(searching))
			{
				employeeswithnoproject = employeeswithnoproject.Where(s => s.FirstName.Contains(searching)
											  || s.LastName.Contains(searching)
											  || s.Role.Contains(searching)).ToList();
			}



			return View(employeeswithnoproject);

		}



		public static class Global
		{
			// set password
			public const string strPassword = "LetMeIn99$";

			// set permutations
			public const String strPermutation = "ouiveyxaqtd";
			public const Int32 bytePermutation1 = 0x19;
			public const Int32 bytePermutation2 = 0x59;
			public const Int32 bytePermutation3 = 0x17;
			public const Int32 bytePermutation4 = 0x41;
		}

		// encoding
		public static string Encrypt(string strData)
		{
			return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
		}


		// decoding
		public static string Decrypt(string strData)
		{
			return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));

		}

		// encrypt
		public static byte[] Encrypt(byte[] strData)
		{
			PasswordDeriveBytes passbytes =
			new PasswordDeriveBytes(Global.strPermutation,
			new byte[] { Global.bytePermutation1,
						 Global.bytePermutation2,
						 Global.bytePermutation3,
						 Global.bytePermutation4
			});

			MemoryStream memstream = new MemoryStream();
			Aes aes = new AesManaged();
			aes.Key = passbytes.GetBytes(aes.KeySize / 8);
			aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

			CryptoStream cryptostream = new CryptoStream(memstream,
			aes.CreateEncryptor(), CryptoStreamMode.Write);
			cryptostream.Write(strData, 0, strData.Length);
			cryptostream.Close();
			return memstream.ToArray();
		}

		// decrypt
		public static byte[] Decrypt(byte[] strData)
		{
			PasswordDeriveBytes passbytes =
			new PasswordDeriveBytes(Global.strPermutation,
			new byte[] { Global.bytePermutation1,
						 Global.bytePermutation2,
						 Global.bytePermutation3,
						 Global.bytePermutation4
			});

			MemoryStream memstream = new MemoryStream();
			Aes aes = new AesManaged();
			aes.Key = passbytes.GetBytes(aes.KeySize / 8);
			aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

			CryptoStream cryptostream = new CryptoStream(memstream,
			aes.CreateDecryptor(), CryptoStreamMode.Write);
			cryptostream.Write(strData, 0, strData.Length);
			cryptostream.Close();
			return memstream.ToArray();
		}
		
	}

}
