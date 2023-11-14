using Lab5_MVC.Models.Entity;
using Lab5_MVC.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Models.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly Lab5DbContext _lab5DbContext;

    public GroupRepository(Lab5DbContext lab5DbContext)
    {
        _lab5DbContext = lab5DbContext;
    }

    public IQueryable<Group> GetAll()
    {
        return _lab5DbContext.Groups.Include(i => i.Schedules).AsQueryable();
    }

    public async Task<Group?> GetById(int id, CancellationToken cancellationToken = default)
    {
        return await _lab5DbContext.Groups
            .Include(i => i.Schedules)
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }
}