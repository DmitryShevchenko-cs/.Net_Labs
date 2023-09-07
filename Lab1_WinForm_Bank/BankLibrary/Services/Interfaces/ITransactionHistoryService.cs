namespace BankLibrary.Services.Interfaces;

public interface ITransactionHistoryService : IBaseService<TransactionHistory>
{
    public Task AddInHistory(TransactionHistory transactionHistory);
    public Task<List<TransactionHistory>> GetHistoryByUser(int userId);
}