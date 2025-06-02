using GuessingGameApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuessingGameApp.Data.Contexts;

public class GuessingGameDbContext : DbContext
{
    public GuessingGameDbContext(DbContextOptions<GuessingGameDbContext> options) : base(options) { }

    public DbSet<Day> Days { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GuessGame> GuessGames { get; set; }
    public DbSet<GuessGameResult> Results { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGameRel> UserGameRels { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GuessingGameDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}