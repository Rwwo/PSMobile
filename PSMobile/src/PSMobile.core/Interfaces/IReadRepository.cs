using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;

using PSMobile.core.Entities;

namespace PSMobile.core.Interfaces;
public interface IReadRepository<T> where T : Entity
{
    Task<PaginatedResult<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        List<Expression<Func<T, object>>>? includes = null,
        List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? thenIncludes = null,
        Expression<Func<T, object>>? orderBy = null,
        bool ascending = true,
        int pageNumber = 1,
        int pageSize = 10
        );


    Task<T> GetByIdAsync(
        Expression<Func<T, bool>>? filter = null,
        List<Expression<Func<T, object>>>? includes = null);

}


