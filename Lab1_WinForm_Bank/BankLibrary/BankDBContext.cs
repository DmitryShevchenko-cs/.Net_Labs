using Microsoft.EntityFrameworkCore;

namespace BankLibrary;

public class BankDBContext : DbContext
{
        
    public DbSet<BankCard> BankCards { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<TransactionHistory> TransactionHistory { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BankDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.BankCard)
            .WithOne(bc => bc.User)
            .HasForeignKey<BankCard>(bc => bc.UserId);

        modelBuilder.Entity<User>()
            .HasMany(t => t.TransactionHistory)
            .WithOne(u => u.User);
        
        modelBuilder.Entity<BankCard>()
            .Property(b => b.Balance)
            .HasColumnType("decimal(18, 2)");
        
        base.OnModelCreating(modelBuilder);
    }

}