using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Entities;

public class Day
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public int GuessGameId { get; set; }
    //navigation properties
    public GuessGame GuessGame { get; set; } = null!;
}