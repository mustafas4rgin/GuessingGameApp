namespace GuessingGameApp.Application.DTOs.List;

public class UserGameRelDTO
{
    public int GuessesCount { get; set; }
    public string User { get; set; } = null!;
    public string GuessGame { get; set; } = null!;
}