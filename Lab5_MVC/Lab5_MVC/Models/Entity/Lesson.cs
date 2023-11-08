namespace Lab5_MVC.Models.Entity;

public class Lesson : BaseEntity
{
    public string Number { get; set; }
    public TimeOnly StatAt { get; set; }
    public TimeOnly FinishAt { get; set; }
    public IEnumerable<Schedule> Schedules { get; set; }
    
    public override string ToString()
    {
        return $"Number: {Number}, StatAt: {StatAt.ToString()}, StatAt: {FinishAt.ToString()}";
    }
}