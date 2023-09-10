﻿namespace BankLibrary.Services.Interfaces;

public interface ITransactionHistoryService : IBaseService<TransactionHistory>
{
    public Task AddInHistoryAsync(TransactionHistory transactionHistory);
    public Task<List<TransactionHistory>> GetHistoryByUserAsync(int userId);
    
    public string ToString(List<TransactionHistory?>? transactionHistories);
}