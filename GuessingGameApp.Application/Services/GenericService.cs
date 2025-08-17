using FluentValidation;
using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Domain.Contracts;
using GuessingGameApp.Domain.Query;
using GuessingGameApp.Domain.Results.Raw;
using GuessingGameApp.Domain.Results.Service.WithData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuessingGameApp.Application.Services;

public class GenericService<T> : IGenericService<T> where T : EntityBase
{
    private readonly IGenericRepository<T> _genericRepository;
    private readonly IValidator<T> _validator;
    private readonly ILogger<GenericService<T>> _logger;
    public GenericService
    (IGenericRepository<T> genericRepository,
     IValidator<T> validator,
     ILogger<GenericService<T>> logger)
    {
        _genericRepository = genericRepository;
        _validator = validator;
        _logger = logger;
    }
    public async Task<IServiceResultWithData<IEnumerable<T>>> GetAllAsync()
    {
        try
        {
            var entities = await _genericRepository.GetAll()
                                    .ToListAsync();

            if (!entities.Any())
                return new ErrorResultWithData<IEnumerable<T>>("There is no entity.");

            return new SuccessResultWithData<IEnumerable<T>>("Entities found.", entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResultWithData<IEnumerable<T>>(ex.Message);
        }
    }
    public async Task<IServiceResultWithData<T>> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _genericRepository.GetByIdAsync(id);

            if (entity is null)
                return new ErrorResultWithData<T>($"There is no entity with ID : {id}");

            return new SuccessResultWithData<T>($"Entity found with ID : {id}", entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResultWithData<T>(ex.Message);
        }
    }
    public async Task<IServiceResult> AddAsync(T entity)
    {
        try
        {
            var validationResult = await _validator.ValidateAsync(entity);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning($"Validation failed for entity with ID : {entity.Id} Errors : {validationResult.Errors}");
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }
                

            await _genericRepository.AddEntityAsync(entity);
            await _genericRepository.SaveChangesAsync();

            _logger.LogInformation($"Entity with ID {entity.Id} added successfully.");
            return new SuccessResult("Entity added successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResult(ex.Message);
        }
    }
    public async Task<IServiceResult> UpdateAsync(T entity)
    {
        try
        {
            var validationResult = await _validator.ValidateAsync(entity);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning($"Validation failed for entity with ID : {entity.Id} Errors: {validationResult.Errors}");
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }
                

            await _genericRepository.UpdateEntityAsync(entity);
            await _genericRepository.SaveChangesAsync();

            _logger.LogInformation($"Entity with ID {entity.Id} updated successfully.");
            return new SuccessResult("Entity updated successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResult(ex.Message);
        }
    }
    public async Task<IServiceResult> DeleteAsync(int id)
    {
        try
        {
            var entity = await _genericRepository.GetByIdAsync(id);

            if (entity is null)
                return new ErrorResult($"There is no entity with ID : {id}");

            var validationResult = await _validator.ValidateAsync(entity);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning($"Validation failed for entity with ID : {id} Errors : {validationResult.Errors}");
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }
                

            await _genericRepository.DeleteEntityAsync(entity);
            await _genericRepository.SaveChangesAsync();

            _logger.LogInformation($"Entity with ID : {id} deleted successfully.");
            return new SuccessResult("Entity deleted successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResult(ex.Message);
        }
    }
    public async Task<IServiceResult> SoftDeleteAsync(int id)
    {
        try
        {
            var entity = await _genericRepository.GetByIdAsync(id);

            if (entity is null || entity.IsDeleted)
                return new ErrorResult($"There is no entity with ID : {id}");

            var validationResult = await _validator.ValidateAsync(entity);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning($"Validation failed for entity with ID : {id} Errors: {validationResult.Errors}");
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }
                

            await _genericRepository.SoftDeleteEntityAsync(entity);
            await _genericRepository.SaveChangesAsync();

            _logger.LogInformation("Entity with ID {EntityId} updated successfully.", entity.Id);
            return new SuccessResult("Entity deleted successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ErrorResult(ex.Message);
        }
    }
}