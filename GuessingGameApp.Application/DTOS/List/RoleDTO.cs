namespace GuessingGameApp.Application.DTOs.List;

public class RoleDTO
{
    public string Name { get; set; } = string.Empty;
    public List<string> Users { get; set; } = null!;
}