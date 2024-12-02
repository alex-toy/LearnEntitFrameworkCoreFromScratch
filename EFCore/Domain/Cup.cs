namespace Domain;

public class Cup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }

    public int WinnerTeamId { get; set; }
    public Team WinnerTeam { get; set; }
}
