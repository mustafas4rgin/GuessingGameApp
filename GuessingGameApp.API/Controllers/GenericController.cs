using AutoMapper;
using FluentValidation;
using GuessingGameApp.API.Controllers;
using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Contracts;
using GuessingGameApp.Domain.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuessingGameApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T, TDto, TCreateDto, TUpdateDto> : BaseApiController
    where T : EntityBase
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
    {
        private readonly IValidator<TCreateDto> _createValidator;
        private readonly IValidator<TUpdateDto> _updateValidator;
        private readonly IGenericService<T> _genericService;
        private readonly IMapper _mapper;
        public GenericController
        (IGenericService<T> genericService,
        IMapper mapper,
        IValidator<TCreateDto> createValidator,
        IValidator<TUpdateDto> updateValidator)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _genericService = genericService;
            _updateValidator = updateValidator;
        }
        [HttpGet("GetAll")]
        public virtual async Task<IActionResult> GetAllAsync([FromQuery] QueryParameters param)
        {
            var result = await _genericService.GetAllAsync();

            var errorResponse = HandleServiceResult(result);

            if (errorResponse != null)
                return errorResponse;

            var entities = result.Data;

            var dtoList = _mapper.Map<IEnumerable<TDto>>(entities);

            return Ok(dtoList);
        }
        [HttpGet("GetById/{id}")]
        public virtual async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var result = await _genericService.GetByIdAsync(id);

            var errorResponse = HandleServiceResult(result);

            if (errorResponse != null)
                return errorResponse;

            var entity = result.Data;

            var dto = _mapper.Map<TDto>(entity);

            return Ok(dto);
        }
        [HttpPost("Add")]
        public virtual async Task<IActionResult> AddAsync([FromBody] TCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return HandleValidationErrors(validationResult.Errors);

            var entity = _mapper.Map<T>(dto);

            var addingResult = await _genericService.AddAsync(entity);

            var errorResponse = HandleServiceResult(addingResult);

            if (errorResponse != null)
                return errorResponse;

            return Ok(addingResult);
        }
        [HttpPut("Update/{id}")]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] TUpdateDto dto, int id)
        {
            var existingEntityResult = await _genericService.GetByIdAsync(id);

            var existingEntityErrorResponse = HandleServiceResult(existingEntityResult);

            if (existingEntityErrorResponse != null)
                return existingEntityErrorResponse;

            var existingEntity = existingEntityResult.Data;

            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return HandleValidationErrors(validationResult.Errors);

            _mapper.Map(dto, existingEntity);

            var updateEntityResult = await _genericService.UpdateAsync(existingEntity);

            var updateEntityErrorResponse = HandleServiceResult(updateEntityResult);

            if (updateEntityErrorResponse != null)
                return updateEntityErrorResponse;

            return Ok(updateEntityResult);
        }
        [HttpDelete("Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var result = await _genericService.DeleteAsync(id);

            var errorResult = HandleServiceResult(result);

            if (errorResult != null)
                return errorResult;

            return Ok(result);
        }
    }
}
