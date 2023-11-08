using Lab5_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Models;

public class Lab5DbContext : DbContext
{
    public Lab5DbContext(DbContextOptions<Lab5DbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Audience> Audiences { get; set; }   
    public DbSet<Group> Groups { get; set; }   
    public DbSet<Lesson> Lessons { get; set; }   
    public DbSet<Schedule> Schedules { get; set; }   
    public DbSet<Teacher> Teachers { get; set; }   
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Lab5DbContext).Assembly);
    }
    
}