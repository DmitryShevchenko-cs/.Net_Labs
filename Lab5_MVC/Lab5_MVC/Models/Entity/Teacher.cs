namespace Lab5_MVC.Models.Entity;

public class Teacher : BaseEntity
{
    public string Department { get; set; }
    public string Position { get; set; }
    public string ScientificDegree { get; set; }
    public IEnumerable<Schedule> Schedules { get; set; }
    
    public override string ToString()
    {
        return $"Department: {Department}, Position: {Position}, ScientificDegree: {ScientificDegree}";
    }
}