using PSMobile.core.Entities;
using PSMobile.SharedKernel.Utilities.Services;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IBaseWriteService<T, Q> where T : class
{
    public abstract Task<Result<T>> GravarAsync(Q entity);
}