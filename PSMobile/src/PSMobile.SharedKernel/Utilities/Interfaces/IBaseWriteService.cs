using PSMobile.SharedKernel.Utilities.Services;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IBaseWriteService<T, Q> where T : class where Q : class
{
    Task<Result<T>> GravarAsync(Q entity);
}

public interface IBaseWriteServiceWithDelete<T, Q, R> : IBaseWriteService<T, Q> where T : class where Q : class where R : class
{
    Task DeleteAsync(R entity);
}