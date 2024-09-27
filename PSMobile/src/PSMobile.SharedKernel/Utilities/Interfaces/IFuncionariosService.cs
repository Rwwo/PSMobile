using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IFuncionariosService : IBaseReadServiceAll<Funcionarios>
{
    Task<PaginatedResult<Funcionarios>> FuncionariosByName(string name, int pageSize = 10, int pageNumber = 1);
}