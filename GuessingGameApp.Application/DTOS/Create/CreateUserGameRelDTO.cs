namespace GuessingGameApp.Application.DTOs.Create;

public class CreateUserGameRelDTO
{
    public int UserId { get; set; }
    public int GuessGameId { get; set; }
    public int GuessesCount { get; set; }
}