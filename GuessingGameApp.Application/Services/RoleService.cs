using FluentValidation;
using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Contracts;
using GuessingGameApp.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace GuessingGameApp.Application.Services;

public class RoleService : GenericService<Role>, IRoleService
{
    public RoleService(
    IRoleRepository roleRepository,
    IValidator<Role> validator,
    ILogger<RoleService> logger)
    : base(roleRepository,validator,logger){}
}