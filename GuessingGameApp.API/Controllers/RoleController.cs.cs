using AutoMapper;
using FluentValidation;
using GuessingGameApp.Application.DTOs.Create;
using GuessingGameApp.Application.DTOs.List;
using GuessingGameApp.Application.DTOs.Update;
using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : GenericController<Role, RoleDTO, CreateRoleDTO, UpdateRoleDTO>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateRoleDTO> _createValidator;
        private readonly IValidator<UpdateRoleDTO> _updateValidator;
        public RoleController(
            IRoleService roleService,
            IValidator<CreateRoleDTO> createValidator,
            IValidator<UpdateRoleDTO> updateValidator,
            IMapper mapper
        ) : base(roleService,mapper,createValidator,updateValidator)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _roleService = roleService;
        }
    }
}
