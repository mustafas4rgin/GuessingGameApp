using GuessingGameApp.Domain.Contracts;
using GuessingGameApp.Domain.Entities;
using GuessingGameApp.Domain.Parameters;

namespace GuessingGameApp.Application.Interfaces;

public interface IRoleService : IGenericService<Role>
{
    Task<IServiceResultWithData<IEnumerable<Role>>> GetRolesWithIncludesAsync(QueryParameters param);
    Task<IServiceResultWithData<Role>> GetRoleByIdWithIncludesAsync(int id, IncludeParameters param);
}