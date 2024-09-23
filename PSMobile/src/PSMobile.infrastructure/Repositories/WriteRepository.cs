using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

namespace PSMobile.infrastructure.Repositories;

public abstract class WriteRepository<T> : IWriteRepository<T> where T : Entity
{
    public abstract Task<T> GravarAsync(T entity);
}