using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Entities;

public class User : EntityBase
{
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    //navigation properties
    public ICollection<UserRole> Roles { get; set; } = null!;
    public ICollection<UserGameRel> Games { get; set; } = null!;
}