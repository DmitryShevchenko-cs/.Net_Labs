namespace Lab5_MVC.Models.Entity;

public class Schedule : BaseEntity
{
    public string Name { get; set; }
    public int Week { get; set; }
    public string Day { get; set; }
    public Lesson Lesson { get; set; }
    public Group Group { get; set; }
    public Teacher Teacher { get; set; }
    public Audience Audience { get; set; }
    
    public override string ToString()
    {
        return $"Name: {Name}, Week: {Week}, Day: {Day}, Lesson: {Lesson}, Lesson: {Group}, Teacher: {Teacher}, Audience: {Audience}, ";
    }
    
}