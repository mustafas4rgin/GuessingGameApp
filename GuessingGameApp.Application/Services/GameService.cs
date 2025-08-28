using FluentValidation;
using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Contracts;
using GuessingGameApp.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace GuessingGameApp.Application.Services;

public class GameService : GenericService<Game>, IGameService
{
    public GameService(
        IGameRepository gameRepository,
        IValidator<Game> validator,
        ILogger<GameService> logger
    ) : base(gameRepository, validator, logger)
    {
    }
}