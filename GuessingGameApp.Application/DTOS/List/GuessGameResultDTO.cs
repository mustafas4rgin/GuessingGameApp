namespace GuessingGameApp.Application.DTOs.List;

public class GuessGameResultDTO
{
    public bool IsGuessedCorrect { get; set; }
    public string ResultMessage { get; set; } = string.Empty;
}