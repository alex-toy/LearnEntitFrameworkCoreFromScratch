namespace Domain;

public class Transfer
{
    public int Id { get; set; }
    public DateTime TransferedAt { get; set; }
    public double Amount { get; set; }

    public int PlayerId { get; set; }
    public Player Player { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; }
}
