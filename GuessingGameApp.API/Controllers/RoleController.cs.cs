using AutoMapper;
using FluentValidation;
using GuessingGameApp.Application.DTOs.Create;
using GuessingGameApp.Application.DTOs.List;
using GuessingGameApp.Application.DTOs.Update;
using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Entities;
using GuessingGameApp.Domain.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGameApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : GenericController<Role, RoleDTO, CreateRoleDTO, UpdateRoleDTO>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(
            IRoleService roleService,
            IValidator<CreateRoleDTO> createValidator,
            IValidator<UpdateRoleDTO> updateValidator,
            IMapper mapper
        ) : base(roleService, mapper, createValidator, updateValidator)
        {
            _mapper = mapper;
            _roleService = roleService;
        }
        [HttpGet("with-includes")]
        public async Task<IActionResult> GetRolesWithIncludesAsync([FromQuery] QueryParameters param)
        {
            var result = await _roleService.GetRolesWithIncludesAsync(param);

            var errorResponse = HandleServiceResult(result);

            if (errorResponse != null)
                return errorResponse;

            var roles = result.Data;

            var dto = _mapper.Map<IEnumerable<RoleDTO>>(roles);

            return Ok(dto);
        }
        [HttpGet("with-includes/{id:int}")]
        public async Task<IActionResult> GetRoleByIdWithIncludesAsync([FromRoute] int id, [FromQuery] IncludeParameters param)
        {
            var result = await _roleService.GetRoleByIdWithIncludesAsync(id, param);

            var errorResponse = HandleServiceResult(result);

            if (errorResponse != null)
                return errorResponse;

            var role = result.Data;

            var dto = _mapper.Map<RoleDTO>(role);

            return Ok(dto);
        }
    }
}
