using PSMobile.core.Entities;

namespace PSMobile.core.Interfaces;

public interface IWriteRepository<T> where T : Entity
{    
    abstract Task<T> GravarAsync(T entity);
}
