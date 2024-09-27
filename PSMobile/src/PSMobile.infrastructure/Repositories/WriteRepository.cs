using PSMobile.core.Interfaces;

namespace PSMobile.infrastructure.Repositories;

public abstract class WriteRepository<T, Q> : IWriteRepository<T, Q> where T : class where Q : class
{
    public abstract Task<Q> GravarAsync(T entity);
}