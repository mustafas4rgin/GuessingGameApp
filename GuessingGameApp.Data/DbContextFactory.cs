using GuessingGameApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GuessingGameApp.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GuessingGameDbContext>
    {
        public GuessingGameDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<GuessingGameDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=s4rgin;Password=admin123;Database=GuessTheGame");

            return new GuessingGameDbContext(optionsBuilder.Options);
        }
    }