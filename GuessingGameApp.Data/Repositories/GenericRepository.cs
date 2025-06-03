using GuessingGameApp.Data.Contexts;
using GuessingGameApp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GuessingGameApp.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
{
    private readonly GuessingGameDbContext _context;
    public GenericRepository(GuessingGameDbContext context)
    {
        _context = context;
    }
    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().Where(e => !e.IsDeleted);
    }
    public async Task<T?> GetByIdAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);

        if (entity is null || entity.IsDeleted)
            return null;

        return entity;
    }
    public async Task<T?> AddEntityAsync(T entity)
    {
        if (entity is null)
            return null;

        await _context.Set<T>().AddAsync(entity);
        entity.CreatedAt = DateTime.UtcNow;

        return entity;
    }
    public async Task<T?> UpdateEntityAsync(T entity)
    {
        var exists = await _context.Set<T>().AnyAsync(e => e.Id == entity.Id && !e.IsDeleted);
        if (!exists) return null;

        entity.UpdatedAt = DateTime.UtcNow;
        _context.Update(entity);

        return entity;
    }
    public async Task<T?> DeleteEntityAsync(T entity)
    {
        var exists = await _context.Set<T>().AnyAsync(e => e.Id == entity.Id && !e.IsDeleted);

        if (!exists) return null;

        _context.Remove(entity);

        return entity;
    }
    public async Task<T?> SoftDeleteEntityAsync(T entity)
    {
        var exists = await _context.Set<T>().AnyAsync(e => e.Id == entity.Id && !e.IsDeleted);

        if (!exists) return null;

        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;

        _context.Update(entity);

        return entity;
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}