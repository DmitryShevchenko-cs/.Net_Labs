using BankLibrary.Helpers;
using BankLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Services;

public class UserService : IUserService
{
    private readonly BankDBContext _context = new BankDBContext();
    public async Task CreateUser(User user)
    {
       var userDb = await _context.Users
            .Where(i=>i.PhoneNumber == user.PhoneNumber || i.Email == user.Email).FirstOrDefaultAsync();
        if(userDb != null)
            return;
        
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt());
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
    }
    
    public async Task AddBankCard(int userId, string pinCode)
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
                User = userDb
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

    public async Task<User?> GetByBankCardNumber(string cardNumber)
    {
        return await _context.Users.Include(i => i.BankCard)
            .Where(i => i.BankCard.CardNumber == cardNumber).FirstOrDefaultAsync();
    }

    public async Task<BankCard?> GetBankCardByUserId(int userId)
    {
        return await _context.BankCards.Include(i => i.User)
            .Where(i => i.User.Id == userId).FirstOrDefaultAsync();
    }

    public async Task<User?> SignIn(string phoneNumber, string password)
    {
        var userDb = await _context.Users.Include(i => i.BankCard)
            .Where(i => i.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        if(userDb is not null)
            if (BCrypt.Net.BCrypt.Verify(password, userDb!.Password))
                return userDb;
        return null;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.Include(i => i.BankCard)
            .Where(i => i.Id == id).FirstOrDefaultAsync();
    }
}