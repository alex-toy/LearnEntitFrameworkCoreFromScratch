namespace Domain;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LeagueId { get; set; }
    public virtual League League{ get; set;}
    public virtual ICollection<Match> Matches{ get; set; }
    public virtual ICollection<Enrollment> Enrollments{ get; set; }
    public virtual ICollection<Cup> Cups{ get; set; }
    public virtual ICollection<Training> Trainings { get; set; } = new List<Training>();

    public void Display()
    {
        Console.WriteLine($"{Id} - {Name} - League : {League.Name}");

        foreach (var match in Matches)
        {
            Console.WriteLine($"{match.Team2.Name} - {match.Score}");
        }

        foreach (var enrollment in Enrollments)
        {
            Console.WriteLine($"{enrollment.Player.Name} - {enrollment.StartedAt} - {enrollment.EndedAt}");
        }

        foreach (var cup in Cups)
        {
            Console.WriteLine($"{cup.Name} - {cup.Year}");
        }

        foreach (var trainings in Trainings)
        {
            Console.WriteLine($"{trainings.Trainer.Name} - {trainings.StartedAt}");
        }
    }
}
