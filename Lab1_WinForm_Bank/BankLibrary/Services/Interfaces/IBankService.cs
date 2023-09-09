namespace BankLibrary.Services.Interfaces;

public interface IBankService
{
    public Task<User?> Authorize(string cardNumber, string cvv, DateTime expiryDate, string pinCode);
    public Task<decimal> CheckBalance(int userId);
    public Task<List<TransactionHistory>?> CheckHistory(int userId);
    public Task GetMoney(int userId, decimal money);
    public Task SetMoney(int userId, decimal money);
    public Task SendMoney(int userId, int receiverId, decimal money);
    public Task CheckBoxes();
}