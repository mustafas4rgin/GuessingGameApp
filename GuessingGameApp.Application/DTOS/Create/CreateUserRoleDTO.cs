namespace GuessingGameApp.Application.DTOs.Create;

public class CreateUserRoleDTO
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime GivenDate { get; set; } = DateTime.UtcNow;
}