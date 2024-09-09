using System.Linq.Expressions;

namespace PSMobile.core.Interfaces;
public interface IRepository<T>
{
    Task<List<T>> GetAllAsync(bool onlyActive = true, params Expression<Func<T, object>>[] includes);
    //Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
