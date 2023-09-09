using BankLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Services;

public class BankService : IBankService
{
    private readonly BankDBContext _context = new BankDBContext();

    public async Task<User?> AuthorizeAsync(string cardNumber, string cvv, DateTime expiryDate, string pinCode)
    {
        var userDb = await _context.Users.Include(i => i.BankCard).ThenInclude(b => b.TransactionHistory)
            .Where(i => i.BankCard.CardNumber == cardNumber 
                        && i.BankCard.CVV == cvv 
                        && i.BankCard.ExpiryDate.Month == expiryDate.Month
                        && i.BankCard.ExpiryDate.Year == expiryDate.Year)
            .FirstOrDefaultAsync();
        if (userDb is null) return null;
        return userDb;
    }

    public Task<decimal> CheckBalanceAsync(int userId)
    {
        return _context.BankCards.Include(i => i.User).Where(i => i.User.Id == userId)
            .Select(i => i.Balance).FirstOrDefaultAsync();
    }
    
    public async Task<List<TransactionHistory>?> CheckHistoryAsync(int userId)
    {
        return await _context.BankCards.Include(i => i.TransactionHistory)
            .Where(i => i.UserId == userId)
            .Select(i => i.TransactionHistory).FirstOrDefaultAsync();
    }

    public async Task GetMoneyAsync(int userId, decimal money)
    {
       var user = await _context.Users.Include(i => i.BankCard)
            .Where(i => i.Id == userId)
            .FirstOrDefaultAsync();
       if (user is not null)
       {
           if(money > user.BankCard.Balance)
               return;
           user.BankCard.Balance -= money;
           _context.Users.Update(user);
           await _context.SaveChangesAsync();
       }
    }

    public async Task SetMoneyAsync(int userId, decimal money)
    {
        var user = await _context.Users.Include(i => i.BankCard)
            .Where(i => i.Id == userId)
            .FirstOrDefaultAsync();
        if (user is not null)
        {
            user.BankCard.Balance += money;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SendMoneyAsync(int userId, int receiverId, decimal money)
    {
        var user = await _context.Users.Include(i => i.BankCard)
            .Where(i => i.Id == userId)
            .FirstOrDefaultAsync();
        var receiver = await _context.Users.Include(i => i.BankCard)
            .Where(i => i.Id == receiverId)
            .FirstOrDefaultAsync();
        if (user is not null && receiver is not null)
        {
            if(money > user.BankCard.Balance)
                return;
            user.BankCard.Balance -= money;
            _context.Users.Update(user);
            
            receiver.BankCard.Balance += money;
            _context.Users.Update(receiver);
            await _context.SaveChangesAsync();
        }
    }

    public Task CheckBoxesAsync()
    {
        throw new NotImplementedException();
    }
}