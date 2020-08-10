using LBD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Domain.EF.ModelConfigurations
{
	public class MeetingEntityConfiguration : IEntityTypeConfiguration<Meeting>
	{
		public void Configure(EntityTypeBuilder<Meeting> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasIndex(c => c.Id);
		}
	}
}
