using Lab5_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab5_MVC.Models.Configuration;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    { 
        builder.HasKey(i => i.Id);
        
        builder.HasOne(i => i.Lesson)
            .WithMany( i => i.Schedules);
        
        builder.HasOne(i => i.Group)
            .WithMany( i => i.Schedules);
        
        builder.HasOne(i => i.Teacher)
            .WithMany( i => i.Schedules);
        
        builder.HasOne(i => i.Audience)
            .WithMany( i => i.Schedules);
    }
}