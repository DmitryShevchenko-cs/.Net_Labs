using BankLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Services;

public class BankService : IBankService
{
    private readonly BankDBContext _context = new BankDBContext();

    public Task Authorize()
    {
        throw new NotImplementedException();
    }

    public Task<decimal> CheckBalance(int userId)
    {
        return _context.BankCards.Include(i => i.User).Where(i => i.User.Id == userId)
            .Select(i => i.Balance).FirstOrDefaultAsync();
    }
    
    public async Task<List<TransactionHistory>?> CheckHistory(int userId)
    {
        return await _context.BankCards.Include(i => i.TransactionHistory)
            .Where(i => i.UserId == userId)
            .Select(i => i.TransactionHistory).FirstOrDefaultAsync();
    }

    public async Task GetMoney(int userId, decimal money)
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

    public async Task SetMoney(int userId, decimal money)
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

    public async Task SendMoney(int userId, int receiverId, decimal money)
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

    public Task CheckBoxes()
    {
        throw new NotImplementedException();
    }
}