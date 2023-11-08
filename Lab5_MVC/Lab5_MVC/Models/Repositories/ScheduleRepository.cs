using Lab5_MVC.Models.Entity;
using Lab5_MVC.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Models.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly Lab5DbContext _lab5DbContext;

    public ScheduleRepository(Lab5DbContext lab5DbContext)
    {
        _lab5DbContext = lab5DbContext;
    }

    public IQueryable<Schedule> GetAll()
    {
        return _lab5DbContext.Schedules
            .Include(i => i.Audience)
            .Include(i => i.Group)
            .Include(i => i.Lesson)
            .Include(i => i.Teacher)
            .AsNoTracking()
            .AsQueryable();
    }

    public Task<Schedule?> GetById(int id, CancellationToken cancellationToken = default)
    {
        return _lab5DbContext.Schedules
            .Include(i => i.Audience)
            .Include(i => i.Group)
            .Include(i => i.Lesson)
            .Include(i => i.Teacher)
            .AsNoTracking()
            .SingleOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public async Task AddToSchedule(Schedule schedule, CancellationToken cancellationToken = default)
    {
        await _lab5DbContext.Schedules.AddAsync(schedule, cancellationToken);
        await _lab5DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveFromSchedule(Schedule schedule, CancellationToken cancellationToken = default)
    {
        _lab5DbContext.Schedules.Remove(schedule);
        await _lab5DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task EditLessonInSchedule(Schedule schedule, CancellationToken cancellationToken = default)
    {
        
        _lab5DbContext.Schedules.Update(schedule);
        await _lab5DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UnAttach(Schedule schedule, CancellationToken cancellationToken = default)
    {
        _lab5DbContext.Entry(schedule).State = EntityState.Detached;
        await _lab5DbContext.SaveChangesAsync(cancellationToken);
    }
}