using System.Reflection.PortableExecutable;

namespace Domain;

public class Enrollment
{
    public int Id { get; set; }

    public int PlayerId { get; set; }
    public Player Player { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; }

    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }
}
