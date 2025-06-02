using GuessingGameApp.Data.Contexts;
using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
{
    private readonly GuessingGameDbContext _context;
    public GenericRepository(GuessingGameDbContext context)
    {
        _context = context;
    }
    public IQueryable<T?> GetAll()
    {
        return _context.Set<T>();
    }
    public async Task<T?> GetByIdAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);

        if (entity is null)
            return null;

        return entity;
    }
    public async Task<T?> AddEntityAsync(T entity)
    {
        entity.Id = default;

        if (entity is null)
            return null;

        await _context.Set<T>().AddAsync(entity);
        entity.CreatedAt = DateTime.UtcNow;

        return entity;
    }
    public async Task<T?> UpdateEntityAsync(T entity)
    {
        entity.Id = default;

        var dbEntity = await _context.Set<T>().FindAsync(entity.Id);

        if (dbEntity is null)
            return null;

        _context.Set<T>().Update(dbEntity);

        return dbEntity;
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}