using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PSMobile.core.Entities;
using PSMobile.core.Exceptions;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public partial class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    public async Task DeleteAsync(T entity)
    {
        try
        {
            if (entity != null)
            {
                entity.Deletar();
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
    {
        try
        {
            var query = _dbSet.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            HandleException(ex);
            return new List<T>(); // Em caso de exceção, retorna uma lista vazia para evitar quebra de aplicação
        }
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null)
    {
        try
        {
            return filter == null ? null : await _dbSet.AsNoTracking().SingleOrDefaultAsync(filter);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            return null; // Em caso de exceção, retorna null
        }
    }

    public async Task UpdateAsync(T entity)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    private void HandleException(Exception ex)
    {
        if (ex is DbUpdateException dbUpdateEx && dbUpdateEx.InnerException != null)
        {
            throw new RepositoryException(dbUpdateEx.InnerException.Message, dbUpdateEx);
        }

        throw new RepositoryException("Um erro não esperado ocorreu", ex);
    }
}
