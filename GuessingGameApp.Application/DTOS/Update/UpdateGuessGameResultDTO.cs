namespace GuessingGameApp.Application.DTOs.Update;

public class UpdateGuessGameResultDTO
{
    public bool IsGuessedCorrect { get; set; }
    public string ResultMessage { get; set; } = string.Empty;
}