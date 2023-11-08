using Lab5_MVC.Models.Entity;
using Lab5_MVC.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Models.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly Lab5DbContext _lab5DbContext;

    public LessonRepository(Lab5DbContext lab5DbContext)
    {
        _lab5DbContext = lab5DbContext;
    }

    public IQueryable<Lesson> GetAll()
    {
        return _lab5DbContext.Lessons.Include(i => i.Schedules).AsQueryable();
    }

    public async Task<Lesson?> GetById(int id, CancellationToken cancellationToken = default)
    {
        return await _lab5DbContext.Lessons
            .Include(i => i.Schedules)
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }
}