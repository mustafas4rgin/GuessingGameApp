using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Entities;

public class UserRole
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime GivenDate { get; set; }
    //navigation properties
    public Role Role { get; set; } = null!;
    public User User { get; set; } = null!;
}