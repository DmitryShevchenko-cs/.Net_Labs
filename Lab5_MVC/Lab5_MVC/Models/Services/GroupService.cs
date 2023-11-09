using Lab5_MVC.Models.Entity;
using Lab5_MVC.Models.Repositories.Interfaces;
using Lab5_MVC.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Models.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Task<Group?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _groupRepository.GetById(id, cancellationToken);
    }

    public async Task<List<Group>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _groupRepository.GetAll().ToListAsync(cancellationToken);
    }
}