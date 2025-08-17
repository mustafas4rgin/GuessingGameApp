namespace GuessingGameApp.Application.DTOs.List;

public class UserRoleDTO
{
    public DateTime GivenDate { get; set; }
    public string Role { get; set; } = null!;
    public string User { get; set; } = null!;
}