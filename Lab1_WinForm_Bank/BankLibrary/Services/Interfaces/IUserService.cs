namespace BankLibrary.Services.Interfaces;

public interface IUserService : IBaseService<User>
{
    public Task CreateUserAsync(User user);
    public Task AddBankCardAsync(int userId, string pinCode);
    public Task<User?> GetByBankCardNumberAsync(string cardNumber);
    public Task<BankCard?> GetBankCardByUserIdAsync(int userId);
    
    public Task<User?> GetByEmail(string email);

}