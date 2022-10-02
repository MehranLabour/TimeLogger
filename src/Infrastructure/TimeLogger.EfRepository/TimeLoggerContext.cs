using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TimeLogger.EfRepository.Logs;
using TimeLogger.EfRepository.Projects;
using TimeLogger.EfRepository.Tasks;
using TimeLogger.Model.Logs;
using TimeLogger.Model.Projects;
using TimeLogger.Model.Tasks;

namespace TimeLogger.EfRepository
{
    public class TimeLoggerContext:DbContext
    {

        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<LogModel> Logs { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TaskModelConfig().Configure(modelBuilder.Entity<TaskModel>());
            new LogModelConfig().Configure(modelBuilder.Entity<LogModel>());
            new ProjectConfig().Configure(modelBuilder.Entity<ProjectModel>());
        }
        public TimeLoggerContext(DbContextOptions options) : base(options)
        {
        }
    }
}
