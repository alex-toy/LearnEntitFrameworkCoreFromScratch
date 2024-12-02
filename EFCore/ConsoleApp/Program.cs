using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp;

internal class Program
{
    private static readonly LeagueDbContext _db = new LeagueDbContext();

    static async Task Main(string[] args)
    {
        //await AddLeague();
        //await AddTeams();
        DisplayTeams();
        //await AddMatch();
        //await AddEnrollment();
    }

    private static async Task AddLeague()
    {
        await _db.Leagues.AddAsync(new League() { Name = "english premiere league" });
        await _db.Leagues.AddAsync(new League() { Name = "spanish premiere league" });
        await _db.SaveChangesAsync();
    }

    private static async Task AddTeams()
    {
        List<Team> leagues = new()
        {
            new Team() { Name = "team 1", LeagueId = 11 },
            new Team() { Name = "team 2", LeagueId = 12 },
            new Team() { Name = "team 3", League = new League() { Name = "french permiere league" } },
        };

        await _db.Teams.AddRangeAsync(leagues);
        await _db.SaveChangesAsync();
    }

    private static void DisplayTeams()
    {
        IQueryable<Team> teams = _db.Teams.AsQueryable()
                                        .Include(t => t.League)
                                        .Include(t => t.Matches).ThenInclude(m => m.Team2)
                                        .Include(t => t.Enrollments).ThenInclude(m => m.Player);

        foreach (var team in teams) team.Display();
    }

    private static async Task AddMatch()
    {
        //await _db.Matches.AddAsync(new Match() { Team1Id = 6, Team2Id = 7, Score = "2-1" });
        //await _db.Matches.AddAsync(new Match() { Team1Id = 7, Team2Id = 8, Score = "3-2" });
        //await _db.Matches.AddAsync(new Match() { Team1Id = 6, Team2Id = 7, Score = "6-2" });

        //Team? team1 = await _db.Teams.AsQueryable().FirstOrDefaultAsync(t => t.Id == 6);
        //Team? team2 = await _db.Teams.AsQueryable().FirstOrDefaultAsync(t => t.Id == 7);

        await _db.Matches.AddAsync(new Match()
        {
            Team1 = new Team() { Name = "Ol", League = new League() { Name = "D1" } },
            Team2 = new Team() { Name = "PSG", League = new League() { Name = "D3" } },
            Score = "10-2"
        });

        await _db.SaveChangesAsync();
    }

    private static async Task AddEnrollment()
    {
        Team? team = await _db.Teams.AsQueryable().FirstOrDefaultAsync(t => t.Id == 7);

        await _db.Enrollments.AddAsync(new Enrollment()
        {
            Player = new () { Name = "ronaldo" },
            Team = team!,
            StartedAt = DateTime.Now
        });

        await _db.SaveChangesAsync();
    }
}
