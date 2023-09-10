using BankLibrary.Helpers;
using BankLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Services;

public class UserService : IUserService
{
    private readonly BankDBContext _context = new BankDBContext();
    public async Task CreateUserAsync(User user)
    {
       var userDb = await _context.Users
            .Where(i => i.Email == user.Email).FirstOrDefaultAsync();
       if (userDb != null)
           return;
        
       await _context.Users.AddAsync(user);
       await _context.SaveChangesAsync();
    }
    
    public async Task AddBankCardAsync(int userId, string pinCode)
    {
        var userDb = await _context.Users
            .Where(i => i.Id == userId).FirstOrDefaultAsync();
        if (userDb != null)
        {
            var bankCard = new BankCard
            {
                CardNumber = RandNumberHelper.GenerateRandomCardNumber(),
                ExpiryDate = DateTime.Now.AddYears(6),
                CVV = RandNumberHelper.GenerateRandomCvv(),
                Balance = 0,
                PinCode = pinCode,
                UserId = userDb.Id,
                User = userDb,
                TransactionHistory = new List<TransactionHistory>()
            };
            await _context.BankCards.AddAsync(bankCard);
            await _context.SaveChangesAsync();
            
            bankCard = await _context.BankCards.Where(i => i.UserId == userId).FirstOrDefaultAsync();
            if (bankCard != null)
            {
                userDb.BankCard = bankCard;
                _context.Users.Update(userDb);
                await _context.SaveChangesAsync();
            }
        }
    }
    public async Task<User?> GetByBankCardNumberAsync(string cardNumber)
    {
        return await _context.Users.Include(i => i.BankCard)
            .Where(i => i.BankCard.CardNumber == cardNumber).FirstOrDefaultAsync();
    }

    public async Task<BankCard?> GetBankCardByUserIdAsync(int userId)
    {
        return await _context.BankCards.Include(i => i.User)
            .Where(i => i.User.Id == userId).FirstOrDefaultAsync();
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users.Include(i => i.BankCard).ThenInclude(b => b.TransactionHistory)
            .Where(i => i.Email == email).FirstOrDefaultAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.Include(i => i.BankCard)
            .Where(i => i.Id == id).FirstOrDefaultAsync();
    }
}