namespace GuessingGameApp.Application.DTOs.Create;

public class CreateGuessGameDTO
{
    public string Answer { get; set; } = string.Empty;
    public bool IsPlayed { get; set; } = false;
    public int GuessCount { get; set; } = 0;
    public int DayId { get; set; }
    public int GuessGameResultId { get; set; }
}