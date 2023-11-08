using Lab5_MVC.Models.Entity;

namespace Lab5_MVC.Models.Repositories.Interfaces;

public interface IScheduleRepository : IBaseRepository<Schedule>
{
    public Task AddToSchedule(Schedule schedule, CancellationToken cancellationToken = default);
    public Task RemoveFromSchedule(Schedule schedule, CancellationToken cancellationToken = default);
    public Task EditLessonInSchedule(Schedule schedule, CancellationToken cancellationToken = default);

    public Task UnAttach(Schedule schedule, CancellationToken cancellationToken = default);
}