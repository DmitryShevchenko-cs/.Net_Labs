using Lab5_MVC.Models.Entity;

namespace Lab5_MVC.Models.Services.Interfaces;

public interface IScheduleService : IBaseService<Schedule>
{
    public Task AddToSchedule(Schedule schedule, CancellationToken cancellationToken = default);
    public Task<List<Schedule>> GetByDayAndWeek(string day, int week, CancellationToken cancellationToken = default);

    public Task DeleteById(int id, CancellationToken cancellationToken = default);

    public Task EditSchedule(Schedule schedule, CancellationToken cancellationToken = default);
}