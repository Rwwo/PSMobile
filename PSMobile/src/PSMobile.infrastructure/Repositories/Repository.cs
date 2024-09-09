using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PSMobile.core.Entities;
using PSMobile.core.Extensions;
using PSMobile.core.Exceptions;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public partial class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected MyDbContext _context;
    public Repository(MyDbContext contexto)
    {
        _context = contexto;
    }

    public async Task AddAsync(T entity)
    {
        try
        {
            _context.ChangeTracker.Clear();

            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Added;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    public async Task DeleteAsync(T entity)
    {
        if (entity != null)
        {
            entity.Deletar();
            await UpdateAsync(entity);
        }
    }

    public async Task<List<T>> GetAllAsync(bool onlyActive = true, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>()
                                      //.When(onlyActive, x => !x.Excluido)
                                      ;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        try
        {
            _context.ChangeTracker.Clear();

            _context.Attach(entity);
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

        // Trate tipos específicos de exceção, se necessário
        if (ex is DbUpdateException dbUpdateEx)
        {
            if (dbUpdateEx.InnerException is not null)
                throw new RepositoryException(dbUpdateEx.InnerException.Message, dbUpdateEx);
        }

        // Tratamento genérico de exceções
        throw new RepositoryException("Um erro não esperado ocorreu", ex);
    }
}