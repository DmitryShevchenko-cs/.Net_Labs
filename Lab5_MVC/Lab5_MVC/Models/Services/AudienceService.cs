using Lab5_MVC.Models.Entity;
using Lab5_MVC.Models.Repositories.Interfaces;
using Lab5_MVC.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Models.Services;

public class AudienceService : IAudienceService
{
    private readonly IAudienceRepository _audienceRepository;

    public AudienceService(IAudienceRepository audienceRepository)
    {
        _audienceRepository = audienceRepository;
    }

    public Task<Audience?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _audienceRepository.GetById(id, cancellationToken);
    }

    public async Task<List<Audience>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _audienceRepository.GetAll().ToListAsync(cancellationToken);
    }
}
