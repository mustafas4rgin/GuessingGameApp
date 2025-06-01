using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Entities;

public class GuessGameResult : EntityBase
{
    public bool IsGuessedCorrect { get; set; }
    public string ResultMessage { get; set; } = string.Empty;
}