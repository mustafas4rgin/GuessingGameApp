namespace GuessingGameApp.Application.DTOs.List;

public class GuessGameDTO
{
    public string Answer { get; set; } = string.Empty;
    public bool IsPlayed { get; set; } = false;
    public int GuessCount { get; set; } = 0;
    public string Day { get; set; } = null!;
    public string GuessGameResult { get; set; } = null!;
    public List<string> Users { get; set; } = null!;
}