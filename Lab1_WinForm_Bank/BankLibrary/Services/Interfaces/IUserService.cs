namespace BankLibrary.Services.Interfaces;

public interface IUserService : IBaseService<User>
{
    public Task CreateUser(User user);
    public Task AddBankCard(int userId, string pinCode);
    public Task<User?> GetByBankCardNumber(string cardNumber);

    public Task<BankCard?> GetBankCardByUserId(int userId);
}