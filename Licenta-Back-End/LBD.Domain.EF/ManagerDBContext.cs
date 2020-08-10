using LBD.Domain.EF.ModelConfigurations;
using LBD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.EF
{
	public class ManagerDbContext : DbContext
	{
		public ManagerDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
			modelBuilder.ApplyConfiguration(new SprintEntityConfiguration());
			modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
			modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
			modelBuilder.ApplyConfiguration(new TeamEntityConfiguration());
			modelBuilder.ApplyConfiguration(new InboxEntityConfiguration());
			modelBuilder.ApplyConfiguration(new MeetingEntityConfiguration());
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Sprint> Sprints { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Inbox> Inboxs { get; set; }
		public DbSet<Meeting> Meetings { get; set; }
		
	}
}
