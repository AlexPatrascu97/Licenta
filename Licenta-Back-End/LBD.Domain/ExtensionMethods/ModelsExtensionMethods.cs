using LBD.Domain.Models;
using LBD.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.ExtensionMethods
{
	public static class ModelsExtensionMethods
	{
		public static Employee ToDTOEmployee(this GeneralEmployeeRequest request)
		{
			return new Employee
			{
				JobTitle = request.JobTitle,
				Salary = request.Salary,
				FirstName = request.FirstName,
				LastName = request.LastName,
				DepartamentName = request.DepartamentName,
				Password = request.Password,
				Role = request.Role,
				Email = request.Email
			};
		}

		public static Employee ToDTOEmployee(this GeneralEmployeeRequest request, int id)
		{
			return new Employee
			{
				Id = id,
				JobTitle = request.JobTitle,
				Salary = request.Salary,
				FirstName = request.FirstName,
				LastName = request.LastName,
				DepartamentName = request.DepartamentName,
				Password = request.Password,
				Role = request.Role,
				Email = request.Email
			};
		}

		public static Sprint ToDTOSprint(this GeneralSprintRequest request)
		{
			return new Sprint
			{
				ProjectName = request.ProjectName,
				SprintNumber = request.SprintNumber,
				startdate = request.startdate,
				status = request.status

			};
		}

		public static Sprint ToDTOSprint(this GeneralSprintRequest request,int id)
		{
			return new Sprint
			{
				Id = id,
				ProjectName = request.ProjectName,
				SprintNumber = request.SprintNumber,
				startdate = request.startdate,
				status = request.status

			};
		}

		public static Project ToDTOProject(this GeneralProjectRequest request, int id)
		{
			return new Project
			{
				Id = id,
				ProjectName = request.ProjectName,
				StartDate = request.StartDate,
				AllocatedMoney = request.AllocatedMoney,
				ClientName = request.ClientName,
				Detail = request.Detail

			};
		}

		public static Project ToDTOProject(this GeneralProjectRequest request)
		{
			return new Project
			{
				ProjectName = request.ProjectName,
				StartDate = request.StartDate,
				AllocatedMoney = request.AllocatedMoney,
				ClientName = request.ClientName,
				Detail = request.Detail

			};
		}

		public static Task ToDTOTask(this GeneralTaskRequest request, int id)
		{
			return new Task
			{
				Id = id,
				ProjectName = request.ProjectName,
				TaskOwnerID = request.TaskOwnerID,
				Details =request.Details,
				sprintNumber = request.sprintNumber,
				Status = request.Status,
				TaskName = request.TaskName,
				TaskOwnerFirstName = request.TaskOwnerFirstName, 
				TaskOwnerLastName = request.TaskOwnerLastName

			};
		}

		public static Task ToDTOTask(this GeneralTaskRequest request)
		{
			return new Task
			{
				ProjectName = request.ProjectName,
				TaskOwnerID = request.TaskOwnerID,
				Details = request.Details,
				sprintNumber = request.sprintNumber,
				Status = request.Status,
				TaskName = request.TaskName,
				TaskOwnerFirstName = request.TaskOwnerFirstName,
				TaskOwnerLastName = request.TaskOwnerLastName

			};
		}

		public static Team ToDTOTeam(this GeneralTeamRequest request, int id)
		{
			return new Team
			{
				Id = id,
				ProjectName = request.ProjectName,
				FirstName = request.FirstName,
				LastName = request.LastName,
				TeamLeaderFirstName = request.TeamLeaderFirstName,
				TeamLeaderLastName = request.TeamLeaderLastName

			};
		}

		public static Team ToDTOTeam(this GeneralTeamRequest request)
		{
			return new Team
			{
				ProjectName = request.ProjectName,
				FirstName = request.FirstName,
				LastName = request.LastName,
				TeamLeaderFirstName = request.TeamLeaderFirstName,
				TeamLeaderLastName = request.TeamLeaderLastName

			};
		}

		public static Inbox ToDTOInbox(this GeneralInboxRequest request)
		{
			return new Inbox
			{
				Recipient = request.Recipient,
				Sender = request.Sender,
				Message = request.Message,
				Status = request.Status,
				Title = request.Title
			};
		}

		public static Inbox ToDTOInbox(this GeneralInboxRequest request, int id)
		{
			return new Inbox
			{
				Id = id,
				Recipient = request.Recipient,
				Sender = request.Sender,
				Message = request.Message,
				Status = request.Status,
				Title = request.Title
			};
		}

		public static Meeting ToDTOMeeting(this GeneralMeetingRequest request)
		{
			return new Meeting
			{
				MeetingName = request.MeetingName,
				Details = request.Details,
				Date = request.Date,
				Link = request.Link,
				ProjectName = request.ProjectName
			};
		}

		public static Meeting ToDTOMeeting(this GeneralMeetingRequest request, int id)
		{
			return new Meeting
			{
				Id = id,
				MeetingName = request.MeetingName,
				Details = request.Details,
				Date = request.Date,
				Link = request.Link,
				ProjectName = request.ProjectName
			};
		}


	}

}
