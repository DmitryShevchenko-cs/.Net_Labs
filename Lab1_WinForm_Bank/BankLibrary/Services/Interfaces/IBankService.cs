namespace BankLibrary.Services.Interfaces;

public interface IBankService
{
    public Task<User?> AuthorizeAsync(string cardNumber, string cvv, DateTime expiryDate, string pinCode);
    public Task<decimal> CheckBalanceAsync(int userId);
    public Task<List<TransactionHistory>?> CheckHistoryAsync(int userId, HistorySize historySize);
    public Task GetMoneyAsync(int userId, decimal money);
    public Task SetMoneyAsync(int userId, decimal money);
    public Task SendMoneyAsync(int userId, int receiverId, decimal money);
    public Task CheckBoxesAsync();
}