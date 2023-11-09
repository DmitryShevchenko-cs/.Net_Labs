using Lab5_MVC.Models;
using Lab5_MVC.Models.Repositories;
using Lab5_MVC.Models.Repositories.Interfaces;
using Lab5_MVC.Models.Services;
using Lab5_MVC.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab5_MVC;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING") ?? Configuration.GetConnectionString("ConnectionString");
        
        services.AddControllersWithViews();
        services.AddControllers();

        services.AddDbContext<Lab5DbContext>(options =>
            options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
        
        services.AddTransient<IScheduleService, ScheduleService>();
        services.AddTransient<IScheduleRepository, ScheduleRepository>();
        
        services.AddTransient<IAudienceService, AudienceService>();
        services.AddTransient<IAudienceRepository, AudienceRepository>();
        
        services.AddTransient<IGroupService, GroupService>();
        services.AddTransient<IGroupRepository, GroupRepository>();
        
        services.AddTransient<ILessonService, LessonService>();
        services.AddTransient<ILessonRepository, LessonRepository>();
        
        services.AddTransient<ITeacherService, TeacherService>();
        services.AddTransient<ITeacherRepository, TeacherRepository>();
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStaticFiles();
        app.UseRouting(); 
         
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Schedule}/{action=Index}");
        });
    }
}