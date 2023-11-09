using Lab5_MVC.Models.Entity;
using Lab5_MVC.Models.Repositories.Interfaces;
using Lab5_MVC.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Models.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public Task<Teacher?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _teacherRepository.GetById(id, cancellationToken);
    }

    public async Task<List<Teacher>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _teacherRepository.GetAll().ToListAsync(cancellationToken);
    }
}