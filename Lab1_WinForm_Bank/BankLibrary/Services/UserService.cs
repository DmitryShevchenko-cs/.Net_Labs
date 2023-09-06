using BankLibrary.Helpers;
using BankLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Services;

public class UserService : IUserService
{
    private readonly BankDBContext _context = new BankDBContext();
    public async Task CreateUser(User user)
    {
       var userDb = await _context.Users.AsQueryable()
            .Where(i=>i.PhoneNumber == user.PhoneNumber || i.Email == user.Email).FirstOrDefaultAsync();
        if(userDb != null)
            return;
        
        user.Password = "11";
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
    }

    public async Task AddBankCard(int userId, string pinCode)
    {
        var userDb = await _context.Users.AsQueryable()
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
                User = userDb
            };
            await _context.BankCards.AddAsync(bankCard);
            await _context.SaveChangesAsync();
            
            bankCard = await _context.BankCards.AsQueryable().Where(i => i.UserId == userId).FirstOrDefaultAsync();
            if (bankCard != null)
            {
                userDb.BankCard = bankCard;
                _context.Users.Update(userDb);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task<User?> GetByBankCardNumber(string cardNumber)
    {
        return await _context.Users.Include(i => i.BankCard).AsQueryable()
            .Where(i => i.BankCard.CardNumber == cardNumber).FirstOrDefaultAsync();
    }

    public async Task<BankCard?> GetBankCardByUserId(int userId)
    {
        return await _context.BankCards.Include(i => i.User).AsQueryable()
            .Where(i => i.User.Id == userId).FirstOrDefaultAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.Include(i => i.BankCard).AsQueryable()
            .Where(i => i.Id == id).FirstOrDefaultAsync();
    }
}