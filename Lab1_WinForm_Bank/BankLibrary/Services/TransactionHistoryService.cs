using BankLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Services;

public class TransactionHistoryService: ITransactionHistoryService
{
    private readonly BankDBContext _context = new BankDBContext();
    
    public async Task<TransactionHistory?> GetByIdAsync(int id)
    {
        return await _context.TransactionHistory.Include(i => i.BankCard)
            .Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddInHistoryAsync(TransactionHistory transactionHistory)
    {
        await _context.TransactionHistory.AddAsync(transactionHistory);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TransactionHistory>> GetHistoryByUserAsync(int userId)
    {
        return await _context.TransactionHistory.Include(i => i.BankCard).ThenInclude(i => i!.User)
            .Where(i => i.BankCard.UserId == userId).ToListAsync();
    }
}