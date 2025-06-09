using FluentValidation;
using FluentValidation.Results;
using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGameApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExceptionTestController : ControllerBase
{
    private readonly IGenericService<ErrorLog> _service;
    public ExceptionTestController(IGenericService<ErrorLog> service)
    {
        _service = service;
    }
    [HttpGet("validation")]
    public async Task<IActionResult> ThrowValidationException()
    {
        await Task.Run(() =>
        {
            var failures = new List<ValidationFailure>
            {
            new("Field1", "Field1 is required."),
            new("Field2", "Field2 must be greater than 5.")
            };

            throw new ValidationException(failures);
        });

        return Ok();
    }

    [HttpGet("unauthorized")]
    public IActionResult ThrowUnauthorizedException()
    {
        throw new UnauthorizedAccessException("You are not allowed to access this resource.");
    }

    [HttpGet("general")]
    public IActionResult ThrowGeneralException()
    {
        throw new Exception("This is a general exception.");
    }
    [HttpGet("Logs")]
    public async Task<IActionResult> Logs()
    {
        var logs = await _service.GetAllAsync();

        return Ok(logs);
    }
}
