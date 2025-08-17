namespace GuessingGameApp.Application.DTOs.Create;

public class CreateGuessGameResultDTO
{
    public bool IsGuessedCorrect { get; set; }
    public string ResultMessage { get; set; } = string.Empty;
}