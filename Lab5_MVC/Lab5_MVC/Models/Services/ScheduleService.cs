using Lab5_MVC.Models.Entity;
using Lab5_MVC.Models.Repositories.Interfaces;
using Lab5_MVC.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Models.Services;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;

    public ScheduleService(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public Task<Schedule?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _scheduleRepository.GetById(id, cancellationToken);
    }

    public async Task<List<Schedule>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _scheduleRepository.GetAll().ToListAsync(cancellationToken);
    }

    public async Task AddToSchedule(Schedule schedule, CancellationToken cancellationToken = default)
    {
        await _scheduleRepository.AddToSchedule(schedule, cancellationToken);
    }

    public async Task<List<Schedule>> GetByDayAndWeek(string day, int week, CancellationToken cancellationToken = default)
    {
        if(week is > 0 and < 3)
            return await _scheduleRepository.GetAll().Where(i => i.Day == day && i.Week == week).ToListAsync(cancellationToken);
        throw new Exception("wrong input");
    }

    public async Task DeleteById(int id, CancellationToken cancellationToken = default)
    {
        var sc = await _scheduleRepository.GetById(id, cancellationToken);
        if(sc is not null)
            await _scheduleRepository.RemoveFromSchedule(sc, cancellationToken);
    }

    public async Task EditSchedule(Schedule schedule, CancellationToken cancellationToken = default)
    {
        await _scheduleRepository.EditLessonInSchedule(schedule, cancellationToken);
    }
}