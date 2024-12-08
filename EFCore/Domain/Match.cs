namespace Domain;

public class Match
{
    public int Id { get; set; }
    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; }

    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; }

    public string Score { get; set; }
    public DateTime PlayedAt { get; set; }
}
