namespace BankLibrary.Services;

public interface IBaseService<TModel> where TModel : class
{
    Task<TModel?> GetByIdAsync(int id);
}