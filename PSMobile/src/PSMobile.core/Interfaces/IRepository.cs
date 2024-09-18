using System.Linq.Expressions;

using PSMobile.core.Entities;

namespace PSMobile.core.Interfaces;
public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        List<Expression<Func<T, object>>>? includes = null);

    Task<T> GetByIdAsync(
        Expression<Func<T, bool>>? filter = null,
        List<Expression<Func<T, object>>>? includes = null);

    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
