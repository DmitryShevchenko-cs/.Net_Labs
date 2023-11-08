using Lab5_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab5_MVC.Models.Configuration;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.Property(l => l.StatAt)
            .HasConversion(
                v => v.ToTimeSpan(),   // Convert TimeOnly to TimeSpan for storage
                v => TimeOnly.FromTimeSpan(v) // Convert TimeSpan back to TimeOnly when retrieving
            );
        builder.Property(l => l.FinishAt)
            .HasConversion(
                v => v.ToTimeSpan(),   // Convert TimeOnly to TimeSpan for storage
                v => TimeOnly.FromTimeSpan(v) // Convert TimeSpan back to TimeOnly when retrieving
            );
    }
}