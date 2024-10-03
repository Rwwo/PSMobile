namespace PSMobile.core.Interfaces;

public interface IWriteRepository<T, Q> where T : class where Q : class
{
    Task<Q> GravarAsync(T entity);
}

public interface IWriteWithDeleteRepository<T, Q>
    : IWriteRepository<T, Q> where T : class where Q : class
{
    Task DeleteAsync(Q entity);
}
