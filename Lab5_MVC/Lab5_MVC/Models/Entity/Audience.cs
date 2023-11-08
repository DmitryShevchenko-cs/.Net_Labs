namespace Lab5_MVC.Models.Entity;

public class Audience : BaseEntity
{
    public string Corps { get; set; }
    public string Number { get; set; }
    public IEnumerable<Schedule> Schedules { get; set; }
    
    public override string ToString()
    {
        return $"Corps: {Corps}, Number: {Number}";
    }
}