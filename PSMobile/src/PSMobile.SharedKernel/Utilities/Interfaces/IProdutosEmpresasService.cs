using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IProdutosEmpresasService : IBaseReadServiceWithEmpKey<ProdutosEmpresas>
{
    Task<PaginatedResult<ProdutosEmpresas>> GetAllAsync(int empKey, string custom, int pageSize = 10, int pageNumber = 1);
}