using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Application.Interfaces;

public interface IGenericService<T> where T : EntityBase
{
    Task<IServiceResultWithData<IEnumerable<T>>> GetAllAsync();
    Task<IServiceResultWithData<T>> GetByIdAsync(int id);
    Task<IServiceResult> AddAsync(T entity);
    Task<IServiceResult> UpdateAsync(T entity);
    Task<IServiceResult> DeleteAsync(int id);
}