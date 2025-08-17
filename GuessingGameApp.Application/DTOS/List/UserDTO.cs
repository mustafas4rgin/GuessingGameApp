namespace GuessingGameApp.Application.DTOs.List;

public class UserDTO
{
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = null!;
    public List<string> Games { get; set; } = null!;
}