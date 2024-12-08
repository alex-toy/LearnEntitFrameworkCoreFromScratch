using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class LeagueDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=leagueDb;Trusted_Connection=True;TrustServerCertificate=True";
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Cup> Cups { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Transfer> Transfers { get; set; }
    public DbSet<Sponsor> Sponsors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>()
            .HasOne(e => e.HomeTeam)
            .WithMany(s => s.Matches)
            .HasForeignKey(e => e.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
            .HasOne(e => e.AwayTeam)
            .WithMany()
            .HasForeignKey(e => e.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Sponsor>()
            .HasMany(e => e.Teams)
            .WithOne(s => s.Sponsor)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
