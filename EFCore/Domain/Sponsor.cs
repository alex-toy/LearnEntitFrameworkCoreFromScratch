namespace Domain;

public class Sponsor
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Team> Teams { get; set; }
}
