using Lab5_MVC.Models.Entity;
using Lab5_MVC.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Models.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly Lab5DbContext _lab5DbContext;

    public TeacherRepository(Lab5DbContext lab5DbContext)
    {
        _lab5DbContext = lab5DbContext;
    }

    public IQueryable<Teacher> GetAll()
    {
        return _lab5DbContext.Teachers.Include(i => i.Schedules).AsNoTracking().AsQueryable();
    }

    public async Task<Teacher?> GetById(int id, CancellationToken cancellationToken = default)
    {
        return await _lab5DbContext.Teachers.Include(i => i.Schedules).AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }
}