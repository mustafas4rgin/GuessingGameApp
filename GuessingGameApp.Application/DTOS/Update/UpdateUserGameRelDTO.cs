namespace GuessingGameApp.Application.DTOs.Update;

public class UpdateUserGameRelDTO
{
    public int UserId { get; set; }
    public int GuessGameId { get; set; }
    public int GuessesCount { get; set; }
}