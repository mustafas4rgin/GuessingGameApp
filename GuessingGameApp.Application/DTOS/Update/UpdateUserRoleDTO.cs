namespace GuessingGameApp.Application.DTOs.Update;

public class UpdateUserRoleDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime GivenDate { get; set; }
}