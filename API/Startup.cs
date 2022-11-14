using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimeLogger.AppService.Contract;
using TimeLogger.AppService.Contract.Logs;
using TimeLogger.AppService.Contract.Middlewares;
using TimeLogger.AppService.Contract.Projects;
using TimeLogger.AppService.Contract.Tasks;
using TimeLogger.AppService.Logs;
using TimeLogger.AppService.Projects;
using TimeLogger.AppService.Tasks;
using TimeLogger.DomainService.Logs;
using TimeLogger.DomainService.Projects;
using TimeLogger.DomainService.Tasks;
using TimeLogger.EfRepository;
using TimeLogger.EfRepository.Logs;
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
            services.AddTransient<IProjectDomain, ProjectDomain>();
            services.AddTransient<IProjectRepository, ProjectRepository>();

            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskDomain, TaskDomain>();
            services.AddTransient<ITaskRepository, TaskRepository>();

            services.AddTransient<ILogService, LogService>();
            services.AddTransient<ILogDomain, LogDomain>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddScoped<IJwtService, JwtService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.CustomExceptionHandler();
           // app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            if (env.IsDevelopment())
            {
               // app.UseDeveloperExceptionPage();
            }else
            {
               // app.UseExceptionHandler();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}