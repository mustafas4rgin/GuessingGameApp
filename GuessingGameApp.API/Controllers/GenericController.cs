using GuessingGameApp.API.Controllers;
using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Contracts;
using GuessingGameApp.Domain.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : BaseApiController
    where T : EntityBase
    {
        private readonly IGenericService<T> _genericService;
        public GenericController
        (IGenericService<T> genericService)
        {
            _genericService = genericService;
        }
        [HttpGet("/GetAll")]
        public virtual async Task<IActionResult> GetAllAsync([FromQuery] QueryParameters param)
        {
            var result = await _genericService.GetAllAsync();

            var errorResponse = HandleServiceResult(result);

            if (errorResponse != null)
                return errorResponse;

            var entities = result.Data;

            return Ok(entities);
        }
    }
}
