namespace PSMobile.core.Interfaces;

public interface IWriteRepository<T, Q> where T : class where Q : class
{    
    abstract Task<Q> GravarAsync(T entity);
}
