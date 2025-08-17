namespace GuessingGameApp.Application.DTOs.Update;

public class UpdateGuessGameDTO
{
    public string Answer { get; set; } = string.Empty;
    public bool IsPlayed { get; set; } = false;
    public int GuessCount { get; set; } = 0;
    public int DayId { get; set; }
    public int GuessGameResultId { get; set; }
}