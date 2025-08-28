using FluentValidation;
using GuessingGameApp.Application.Helpers;
using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Contracts;
using GuessingGameApp.Domain.Entities;
using GuessingGameApp.Domain.Parameters;
using GuessingGameApp.Domain.Results.Service.WithData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuessingGameApp.Application.Services;

public class RoleService : GenericService<Role>, IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IValidator<Role> _validator;
    private readonly ILogger<RoleService> _logger;
    public RoleService(
    IRoleRepository roleRepository,
    IValidator<Role> validator,
    ILogger<RoleService> logger)
    : base(roleRepository, validator, logger)
    {
        _roleRepository = roleRepository;
        _validator = validator;
        _logger = logger;
    }
    public async Task<IServiceResultWithData<IEnumerable<Role>>> GetRolesWithIncludesAsync(QueryParameters param)
    {
        try
        {
            var query = _roleRepository.GetAll().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(param.Include))
                query = QueryHelper.ApplyIncludesForRole(query, param.Include);

            query = query.Where(r => !r.IsDeleted);

            if (!string.IsNullOrWhiteSpace(param.Search))
            {
                var s = param.Search.ToLowerInvariant();
                query = query.Where(r => r.Name.ToLower().Contains(s));
            }

            var roles = await query.ToListAsync();

            if (!roles.Any())
                return new ErrorResultWithData<IEnumerable<Role>>("There is no role.");

            return new SuccessResultWithData<IEnumerable<Role>>("Roles found.", roles);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResultWithData<IEnumerable<Role>>(ex.Message);
        }
    }
    public async Task<IServiceResultWithData<Role>> GetRoleByIdWithIncludesAsync(int id, IncludeParameters param)
    {
        try
        {
            var query = _roleRepository.GetAll();

            if (!string.IsNullOrEmpty(param.Include))
                query = QueryHelper.ApplyIncludesForRole(query, param.Include);

            query = query.Where(r => !r.IsDeleted);

            var role = await query.FirstOrDefaultAsync(r => r.Id == id);

            if (role is null)
                return new ErrorResultWithData<Role>($"There is no role with ID : {id}");

            return new SuccessResultWithData<Role>($"Role with ID : {id} found.", role);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResultWithData<Role>(ex.Message);
        }
    }
}