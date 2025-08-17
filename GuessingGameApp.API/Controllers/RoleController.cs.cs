using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : GenericController<Role>
    {
        private readonly IRoleService _roleService;
        public RoleController(
            IRoleService roleService
        ) : base(roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            var result = await _roleService.AddAsync(role);

            return Ok(result);
        }
    }
}
