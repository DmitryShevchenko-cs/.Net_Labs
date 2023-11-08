namespace Lab5_MVC.Models.Entity;

public class Group : BaseEntity
{
    public string Number { get; set; }
    public int Amount { get; set; }
    public IEnumerable<Schedule> Schedules { get; set; }
    
    public override string ToString()
    {
        return $"Number: {Number}, Amount: {Amount}";
    }
    
}