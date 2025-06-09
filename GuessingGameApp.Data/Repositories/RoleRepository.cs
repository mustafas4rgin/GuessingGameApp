using GuessingGameApp.Data.Contexts;
using GuessingGameApp.Domain.Contracts;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Data.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(
        GuessingGameDbContext context
    ) : base(context) {}
}