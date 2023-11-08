using Lab5_MVC.Models;
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
        
        services.AddSignalR();
        
        // services.AddScoped<IScheduleService, ScheduleService>();
        // services.AddScoped<IScheduleRepository, ScheduleRepository>();
        //
        // services.AddScoped<IAudienceService, AudienceService>();
        // services.AddScoped<IAudienceRepository, AudienceRepository>();
        //
        // services.AddScoped<IGroupService, GroupService>();
        // services.AddScoped<IGroupRepository, GroupRepository>();
        //
        // services.AddScoped<ILessonService, LessonService>();
        // services.AddScoped<ILessonRepository, LessonRepository>();
        //
        // services.AddScoped<ITeacherService, TeacherService>();
        // services.AddScoped<ITeacherRepository, TeacherRepository>();
        
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