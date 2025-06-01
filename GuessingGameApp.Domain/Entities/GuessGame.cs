using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Entities;

public class GuessGame : EntityBase
{
    public string Answer { get; set; } = string.Empty;
    public bool IsPlayed { get; set; } = false;
    public int GuessCount { get; set; } = 0;
    public int DayId { get; set; }
    public int GuessGameResultId { get; set; }
    //navigation properties
    public Day Day { get; set; } = null!;
    public GuessGameResult GuessGameResult { get; set; } = null!;
}