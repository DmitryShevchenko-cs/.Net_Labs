using BankLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Services;

public class BankService : IBankService
{
    private readonly BankDBContext _context = new BankDBContext();
    private readonly TransactionHistoryService _transactionHistoryService = new TransactionHistoryService();
    public async Task<User?> AuthorizeAsync(string cardNumber, string cvv, DateTime expiryDate, string pinCode)
    {
        var userDb = await _context.Users.Include(i => i.BankCard).ThenInclude(b => b.TransactionHistory)
            .Where(i => i.BankCard.CardNumber == cardNumber 
                        && i.BankCard.CVV == cvv 
                        && i.BankCard.ExpiryDate.Month == expiryDate.Month
                        && i.BankCard.ExpiryDate.Year == expiryDate.Year
                        && i.BankCard.PinCode == pinCode)
            .FirstOrDefaultAsync();
        if (userDb is null) return null;
        return userDb;
    }

    public Task<decimal> CheckBalanceAsync(int userId)
    {
        return _context.BankCards.Include(i => i.User).Where(i => i.User.Id == userId)
            .Select(i => i.Balance).FirstOrDefaultAsync();
    }
    
    public async Task<List<TransactionHistory>?> CheckHistoryAsync(int userId, HistorySize historySize)
    {
        var query = _context.BankCards.Include(i => i.TransactionHistory).ThenInclude(i => i.Atm)
            .Where(i => i.UserId == userId).AsQueryable();
        switch (historySize)
        {
            case HistorySize.DAY:
                return await query
                    .Select(i => i.TransactionHistory.Where(j => j.DateTime.Day == DateTime.Now.Day).ToList())
                    .FirstOrDefaultAsync();
            case HistorySize.WEEK:
                return await query
                    .Select(i => i.TransactionHistory.Where(j=>j.DateTime.Month == DateTime.Now.Month).ToList())
                    .FirstOrDefaultAsync();
            case HistorySize.MONTH:
                return await query
                    .Select(i => i.TransactionHistory.Where(j=>j.DateTime.Month == DateTime.Now.Month).ToList())
                    .FirstOrDefaultAsync();
            case HistorySize.YEAR:
                return await query
                    .Select(i => i.TransactionHistory.Where(j=>j.DateTime.Month == DateTime.Now.Month).ToList())
                    .FirstOrDefaultAsync();
        }
        return null;
    }

    public async Task GetMoneyAsync(int userId, decimal money, int atmId)
    {
       var user = await _context.Users.Include(i => i.BankCard)
            .Where(i => i.Id == userId)
            .FirstOrDefaultAsync();
       var atmDb = await _context.ATMs.Where(i => i.Id == atmId).FirstOrDefaultAsync();
       if (user is not null)
       {
           if(money > user.BankCard.Balance)
               return;
           user.BankCard.Balance -= money;
           user.BankCard.TransactionHistory.Add(new TransactionHistory
           {
               BankCardId = user.BankCard.Id,
               BankCard = user.BankCard,
               Action = $"Cash was withdrawn in the amount of {money}",
               DateTime = DateTime.Now,
               Atm = atmDb,
           });
           _context.Users.Update(user);
           await _context.SaveChangesAsync();
       }
    }

    public async Task SetMoneyAsync(int userId, decimal money, int atmId)
    {
        var user = await _context.Users.Include(i => i.BankCard)
            .Where(i => i.Id == userId)
            .FirstOrDefaultAsync();
        var atmDb = await _context.ATMs.Where(i => i.Id == atmId).FirstOrDefaultAsync();
        if (user is not null)
        {
            user.BankCard.Balance += money;
            user.BankCard.TransactionHistory.Add(new TransactionHistory
            {
                BankCardId = user.BankCard.Id,
                BankCard = user.BankCard,
                Action = $"Cash was credited to the card in the amount of {money}",
                DateTime = DateTime.Now.Date,
                Atm = atmDb,
            });
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SendMoneyAsync(int userId, string receiverCardNumber, decimal money, int atmId)
    {
        var user = await _context.Users.Include(i => i.BankCard)
            .Where(i => i.Id == userId)
            .FirstOrDefaultAsync();
        var receiver = await _context.Users.Include(i => i.BankCard).ThenInclude(i=>i.TransactionHistory)
            .Where(i => i.BankCard.CardNumber == receiverCardNumber)
            .FirstOrDefaultAsync();
        var atmDb = await _context.ATMs.Where(i => i.Id == atmId).FirstOrDefaultAsync();
        if (user is not null && receiver is not null)
        {
            if(money > user.BankCard.Balance)
                return;
            user.BankCard.Balance -= money;
            user.BankCard.TransactionHistory.Add(new TransactionHistory
            {
                BankCardId = user.BankCard.Id,
                BankCard = user.BankCard,
                Action = $"Money was sent to the {receiver.Name} {receiver.Surname} in the amount of {money}",
                DateTime = DateTime.Now.Date,
                Atm = atmDb,
            });
            _context.Users.Update(user);
            receiver.BankCard.Balance += money;
            receiver.BankCard.TransactionHistory.Add(new TransactionHistory
            {
                BankCardId = receiver.BankCard.Id,
                BankCard = receiver.BankCard,
                Action = $"Cash was sent to the card by {user.Name} {user.Surname} in the amount of {money}",
                DateTime = DateTime.Now.Date
            });
            _context.Users.Update(receiver);
            await _context.SaveChangesAsync();
            
        }
    }

    public Task CheckBoxesAsync()
    {
        throw new NotImplementedException();
    }
}