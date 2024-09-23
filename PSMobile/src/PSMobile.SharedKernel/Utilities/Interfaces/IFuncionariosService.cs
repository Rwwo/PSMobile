using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IFuncionariosService : IBaseReadService<Funcionarios>
{
    Task<PaginatedResult<Funcionarios>> FuncionariosByName(string name, int pageSize = 10, int pageNumber = 1);
}