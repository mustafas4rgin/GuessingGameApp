using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Entities;

public class Role : EntityBase
{
    public string Name { get; set; } = string.Empty;
    //navigation properties
    public ICollection<UserRole> Users { get; set; } = null!;
}