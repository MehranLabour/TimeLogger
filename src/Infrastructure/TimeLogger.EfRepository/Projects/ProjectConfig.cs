using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeLogger.Model.Projects;

namespace TimeLogger.EfRepository.Projects
{
    public class ProjectConfig:IEntityTypeConfiguration<ProjectModel>
    {
        public void Configure(EntityTypeBuilder<ProjectModel> builder)
        {
            builder.ToTable("projectModel");
            builder.HasMany(e => e.Tasks).WithOne(e=>e.ProjectModel).HasForeignKey(e=>e.ProjectId);
            builder.Property(e => e.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(e => e.PricePerHour).IsRequired(false).HasColumnType("decimal").HasPrecision(18, 2);
        }
    }
}
