using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PSMobile.core.Entities;
using PSMobile.core.Exceptions;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;
public class ReadRepository<T> : IReadRepository<T> where T : Entity
{
    private readonly DbSet<T> _dbSet;
    private readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<PaginatedResult<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
                                                              List<Expression<Func<T, object>>>? includes = null,
                                                              int pageNumber = 1,
                                                              int pageSize = 10)
    {
        try
        {
            var query = _dbSet.AsNoTracking();

            // Aplica os includes se houver
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Aplica o filtro se houver
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Obtém o número total de itens sem paginação
            var totalItems = await query.CountAsync();

            // Aplica a paginação
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            // Retorna o resultado paginado de forma assíncrona
            return new PaginatedResult<T>(items, totalItems, pageNumber, pageSize);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            return new PaginatedResult<T>(new List<T>(), 0, pageNumber, pageSize);

        }
    }




    public async Task<T> GetByIdAsync(Expression<Func<T, bool>>? filter = null,
                                      List<Expression<Func<T, object>>>? includes = null)
    {
        try
        {
            var query = _dbSet.AsNoTracking();

            // Aplica os includes se houver
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Aplica o filtro
            return filter == null ? null : await query.SingleOrDefaultAsync(filter);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            return null; // Em caso de exceção, retorna null
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
