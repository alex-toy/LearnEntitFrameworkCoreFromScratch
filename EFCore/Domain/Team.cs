namespace Domain;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LeagueId { get; set; }
    public virtual League League{ get; set;}
    public virtual ICollection<Match> Matches{ get; set; }
}
