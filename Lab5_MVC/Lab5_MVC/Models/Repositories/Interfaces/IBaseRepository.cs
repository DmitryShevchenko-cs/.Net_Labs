namespace Lab5_MVC.Models.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    public Task<TEntity?> GetById(int id, CancellationToken cancellationToken = default);
}