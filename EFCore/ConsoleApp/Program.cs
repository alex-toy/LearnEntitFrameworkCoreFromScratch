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
        //await UpdateMatch(); 
        //await AddEnrollment();
        //await AddCups();
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
                                        .Include(t => t.Cups)
                                        .Include(t => t.Matches).ThenInclude(m => m.Team2)
                                        .Include(t => t.Enrollments).ThenInclude(m => m.Player);

        foreach (var team in teams) team.Display();
    }

    private static async Task AddMatch()
    {
        //await _db.Matches.AddAsync(new Match() { Team1Id = 6, Team2Id = 7, Score = "2-1" });
        //await _db.Matches.AddAsync(new Match() { Team1Id = 7, Team2Id = 8, Score = "3-2" });
        //await _db.Matches.AddAsync(new Match() { Team1Id = 6, Team2Id = 7, Score = "6-2" });

        Team? team1 = await _db.Teams.AsQueryable().FirstOrDefaultAsync(t => t.Id == 6);
        team1!.Name = "OM";
        Team? team2 = await _db.Teams.AsQueryable().FirstOrDefaultAsync(t => t.Id == 9);
        team2!.Name = "OL";

        //await _db.Matches.AddAsync(new Match()
        //{
        //    Team1 = new Team() { Name = "Ol", League = new League() { Name = "D1" } },
        //    Team2 = new Team() { Name = "PSG", League = new League() { Name = "D3" } },
        //    Score = "10-2"
        //});

        await _db.Matches.AddAsync(new Match()
        {
            Team1 = team1!,
            Team2 = team2!,
            Score = "10-2"
        });

        await _db.SaveChangesAsync();
    }

    private static async Task UpdateMatch()
    {
        Match? match = await _db.Matches.AsQueryable().FirstOrDefaultAsync(t => t.Id == 5);
        match!.PlayedAt = DateTime.UtcNow;
        Team? team2 = await _db.Teams.AsQueryable().FirstOrDefaultAsync(t => t.Id == 8);
        team2!.Name = "Inter";
        match.Team2 = team2;

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

    private static async Task AddCups()
    {
        Team? team1 = await _db.Teams.AsQueryable().FirstOrDefaultAsync(t => t.Id == 6);
        team1!.Name = "Olympique de Marseille";

        await _db.Cups.AddAsync(new Cup()
        {
            Name = "Coupe d'Europe",
            WinnerTeam = team1!,
            Year = 2024
        });

        await _db.Cups.AddAsync(new Cup()
        {
            Name = "Coupe d'Italie",
            WinnerTeam = new Team() { Name = "AS Rome", LeagueId = 15 },
            Year = 2022
        });

        await _db.SaveChangesAsync();
    }
}
