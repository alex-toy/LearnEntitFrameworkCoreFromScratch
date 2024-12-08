using Domain;

namespace ConsoleApp.BOs;

public class PlayerTeamTrainer
{
    public string Name { get; set; }
    public string Team { get; set; }
    public string Trainer { get; set; }

    public void Display()
    {
        Console.WriteLine($"{Name} - {Team} - {Trainer}");
    }
}
