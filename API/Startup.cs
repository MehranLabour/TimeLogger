using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeLogger.AppService.Contract.Projects;
using TimeLogger.AppService.Contract.Tasks;
using TimeLogger.AppService.Projects;
using TimeLogger.AppService.Tasks;
using TimeLogger.DomainService.Projects;
using TimeLogger.DomainService.Tasks;
using TimeLogger.EfRepository;
using TimeLogger.EfRepository.Projects;
using TimeLogger.EfRepository.Tasks;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TimeLoggerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TimeLoggerDB"));
            });
            services.AddControllers();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IProjectDomain,ProjectDomain>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskDomain,TaskDomain>();
            services.AddTransient<ITaskRepository, TaskRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
