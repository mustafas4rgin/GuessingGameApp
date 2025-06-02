using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Entities;

public class UserGameRel : EntityBase
{
    public int UserId { get; set; }
    public int GuessGameId { get; set; }
    public int GuessesCount { get; set; }
    //navigation properties
    public User User { get; set; } = null!;
    public GuessGame GuessGame { get; set; } = null!;
}