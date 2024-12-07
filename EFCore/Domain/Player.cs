namespace Domain;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Enrollment> Enrollments { get; set; }

    public void Display()
    {
        Console.WriteLine($"{Id} - {Name}");

        foreach (var enrollment in Enrollments)
        {
            Console.WriteLine($"{enrollment.Id} - {enrollment.Team.Id} - {enrollment.Team.Name} - {enrollment.StartedAt} - {enrollment.EndedAt}");
        }
    }
}
