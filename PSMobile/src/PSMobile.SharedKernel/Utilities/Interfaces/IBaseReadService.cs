using System.Diagnostics;

using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IBaseReadService<T> where T : Entity
{
    Task<PaginatedResult<T>> GetAllAsync(int pageSize = 10, int pageNumber = 1);
    Task<PaginatedResult<T>> GetByIdAsync(int id, int pageSize = 10, int pageNumber = 1);
}

public interface IBaseReadServiceWithEmpKey<T> where T : Entity
{
    Task<PaginatedResult<T>> GetAllAsync(int empKey , int pageSize = 10, int pageNumber = 1);
}
