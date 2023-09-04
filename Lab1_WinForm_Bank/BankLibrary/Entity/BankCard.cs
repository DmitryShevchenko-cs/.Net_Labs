namespace BankLibrary;

public class BankCard
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string CVV { get; set; }
    public decimal Balance { get; set; }
    public string PinCode { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
}