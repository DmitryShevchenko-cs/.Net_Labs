using BankLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Services;

public class TransactionHistoryService: ITransactionHistoryService
{
    private readonly BankDBContext _context = new BankDBContext();
    private readonly AtmService _atmService = new AtmService();
    
    public async Task<TransactionHistory?> GetByIdAsync(int id)
    {
        return await _context.TransactionHistory.Include(i => i.BankCard)
            .Where(i => i.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task<List<TransactionHistory>> GetHistoryByUserAsync(int userId)
    {
        return await _context.TransactionHistory.Include(i => i.BankCard).ThenInclude(i => i!.User)
            .Where(i => i.BankCard.UserId == userId).ToListAsync();
    }

    public string ToString(List<TransactionHistory>? transactionHistories)
    {
        string transactionHistoriesString = "";
        foreach (var transactionHistory in transactionHistories!)
        {
            transactionHistoriesString += $"{_atmService.ToString(new List<ATM>{transactionHistory.Atm})}" +
                                          $"\t---{transactionHistory!.Action}, {transactionHistory!.DateTime.Date} {transactionHistory!.DateTime.TimeOfDay}\n";
        }
        return transactionHistoriesString;
    }
}