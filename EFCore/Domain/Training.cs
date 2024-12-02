namespace Domain;

public class Training
{
    public int Id { get; set; }

    public int TrainerId { get; set; }
    public Trainer Trainer { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; }

    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }
}
