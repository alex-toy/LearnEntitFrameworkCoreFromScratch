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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>()
            .HasOne(e => e.Team1)
            .WithMany(s => s.Matches)
            .HasForeignKey(e => e.Team1Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
            .HasOne(e => e.Team2)
            .WithMany()
            .HasForeignKey(e => e.Team2Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
