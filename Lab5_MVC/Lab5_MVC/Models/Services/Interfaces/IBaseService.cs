namespace Lab5_MVC.Models.Services.Interfaces;

public interface IBaseService <TModel> where TModel : class
{
    Task<TModel?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<TModel>?> GetAllAsync(CancellationToken cancellationToken = default);
}