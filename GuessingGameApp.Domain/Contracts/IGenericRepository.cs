namespace GuessingGameApp.Domain.Contracts;

public interface IGenericRepository<T> where T : EntityBase
{
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(int id);
    Task<T?> AddEntityAsync(T entity);
    Task<T?> UpdateEntityAsync(T entity);
    Task<T?> DeleteEntityAsync(T entity);
    Task<T?> SoftDeleteEntityAsync(T entity);
    Task SaveChangesAsync();
}