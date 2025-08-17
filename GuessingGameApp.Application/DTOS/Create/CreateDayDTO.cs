namespace GuessingGameApp.Application.DTOs.Create;

public class CreateDayDTO
{
    public DateTime Date { get; set; } = DateTime.UtcNow;
}