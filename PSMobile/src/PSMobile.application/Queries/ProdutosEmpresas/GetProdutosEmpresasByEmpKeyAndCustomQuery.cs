using MediatR;

using PSMobile.infrastructure.Repositories;

namespace PSMobile.application.Queries.ProdutosEmpresas;

public class GetProdutosEmpresasByEmpKeyAndCustomQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.ProdutosEmpresas>>
{
    public int EmpKey { get; private set; }
    public string Custom { get; private set; }
    public GetProdutosEmpresasByEmpKeyAndCustomQuery(int empKey, string custom, int pageNumber = 1, int pageSize = 10)
    {
        EmpKey = empKey;
        Custom = custom;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
