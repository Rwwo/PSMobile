using MediatR;

using PSMobile.infrastructure.Repositories;

namespace PSMobile.application.Queries.ProdutosEmpresas;

public class GetProdutosEmpresasByEmpKeyQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.ProdutosEmpresas>>
{
    public int EmpKey { get; private set; }
    public GetProdutosEmpresasByEmpKeyQuery(int empKey, int pageNumber = 1, int pageSize = 10)
    {
        EmpKey = empKey;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
