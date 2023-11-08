using Lab5_MVC.Models;
using Lab5_MVC.Models.Repositories;
using Lab5_MVC.Models.Repositories.Interfaces;
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
        
        //services.AddScoped<IScheduleService, ScheduleService>();
        services.AddTransient<IScheduleRepository, ScheduleRepository>();
        
        //services.AddScoped<IAudienceService, AudienceService>();
        services.AddTransient<IAudienceRepository, AudienceRepository>();
        
        //services.AddScoped<IGroupService, GroupService>();
        services.AddTransient<IGroupRepository, GroupRepository>();
        
        //services.AddScoped<ILessonService, LessonService>();
        services.AddTransient<ILessonRepository, LessonRepository>();
        
        //services.AddScoped<ITeacherService, TeacherService>();
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