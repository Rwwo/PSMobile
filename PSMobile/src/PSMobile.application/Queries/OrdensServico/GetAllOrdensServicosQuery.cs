using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.OrdensServico;
public class GetAllOrdensServicosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.OrdensServicos>>
{
    public int EmpKey { get; set; }
    public GetAllOrdensServicosQuery(int empKey, int pageNumber = 1, int pageSize = 10)
    {
        EmpKey = empKey;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
