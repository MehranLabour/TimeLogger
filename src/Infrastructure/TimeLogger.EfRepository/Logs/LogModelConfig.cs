using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeLogger.Model.Logs;
using TimeLogger.Model.Tasks;

namespace TimeLogger.EfRepository.Logs
{
    public class LogModelConfig:IEntityTypeConfiguration<LogModel>
    {
        public void Configure(EntityTypeBuilder<LogModel> builder)
        {
            builder.ToTable("Log");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Task)
                .WithMany(b => b.Logs)
                .HasForeignKey(e => e.TaskId).IsRequired();
            builder.Property(e => e.Description).IsRequired(false).HasColumnType("text").HasMaxLength(800);
            builder.Property(e => e.EstimatedTimeMinutes).IsRequired().HasColumnType("int");
        }
    }
}
