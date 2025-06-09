using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Entities;

public class ErrorLog : EntityBase
{
    public string Title { get; set; } = null!;
    public string Message { get; set; } = null!;
    public int StatusCode { get; set; }

    public string? Path { get; set; }
    public string? Method { get; set; }
    public string? UserAgent { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
