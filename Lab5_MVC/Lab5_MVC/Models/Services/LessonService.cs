using Lab5_MVC.Models.Entity;
using Lab5_MVC.Models.Repositories.Interfaces;
using Lab5_MVC.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Models.Services;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _lessonRepository;

    public LessonService(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public Task<Lesson?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _lessonRepository.GetById(id, cancellationToken);
    }

    public async Task<List<Lesson>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _lessonRepository.GetAll().ToListAsync(cancellationToken);
    }
}