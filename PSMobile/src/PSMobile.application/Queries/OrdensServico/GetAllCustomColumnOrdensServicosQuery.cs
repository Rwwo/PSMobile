using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.OrdensServico;

public class GetAllCustomColumnOrdensServicosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.OrdensServicos>>
{
    public string Custom { get; private set; }
    public int EmpKey { get; private set; }
    public GetAllCustomColumnOrdensServicosQuery(int empKey, string custom, int pageNumber = 1, int pageSize = 10)
    {
        EmpKey = empKey;
        Custom = custom;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
