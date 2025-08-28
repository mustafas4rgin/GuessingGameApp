using GuessingGameApp.Data.Contexts;
using GuessingGameApp.Domain.Contracts;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Data.Repositories;

public class GameRepository : GenericRepository<Game>, IGameRepository
{
    public GameRepository(
        GuessingGameDbContext guessingGameDbContext
    ) : base(guessingGameDbContext)
    {
        
    }
}