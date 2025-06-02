using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Entities;

public class Day
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
}