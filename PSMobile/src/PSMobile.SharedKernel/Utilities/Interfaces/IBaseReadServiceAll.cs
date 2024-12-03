using System.Diagnostics;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IBaseReadServiceId<T> where T : Entity
{
    Task<PaginatedResult<T>> GetByIdAsync(int id, int pageSize = 10, int pageNumber = 1);
}
public interface IBaseReadServiceAll<T> : IBaseReadServiceId<T> where T : Entity
{
    Task<PaginatedResult<T>> GetAllAsync( int pageSize = 10, int pageNumber = 1);
}

public interface IBaseReadServiceWithEmpKey<T> where T : Entity
{
    Task<PaginatedResult<T>> GetAllAsync(int empKey, int pageSize = 10, int pageNumber = 1);
}
