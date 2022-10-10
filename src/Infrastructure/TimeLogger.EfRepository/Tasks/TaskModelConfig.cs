using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeLogger.Model.Projects;
using TimeLogger.Model.Tasks;

namespace TimeLogger.EfRepository.Tasks
{
    public class TaskModelConfig:IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Logs)
                .WithOne(e => e.Task).HasForeignKey(e=>e.TaskId);
            builder.Property(e => e.Name).IsRequired().HasColumnType("nvarchar");
            builder.Property(e => e.EstimatedTimeMinutes).IsRequired();
        }
    }
}


