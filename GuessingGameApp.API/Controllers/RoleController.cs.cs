using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetAllAsync();

            return Ok(roles);
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            var result = await _roleService.AddAsync(role);

            return Ok(result);
        }
    }
}
