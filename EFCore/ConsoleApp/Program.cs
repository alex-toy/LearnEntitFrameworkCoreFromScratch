using Data;
using Domain;

namespace ConsoleApp;

internal class Program
{
    private static readonly LeagueDbContext _db = new LeagueDbContext();

    static async Task Main(string[] args)
    {
        await _db.Leagues.AddAsync(new League() { Name = "english premiere league" });
        await _db.SaveChangesAsync();
    }
}
