using MediatR;

using PSMobile.core.Interfaces;
namespace PSMobile.application.Queries.OrdensServico;
public class GetAllByKeyOrdensServicosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.OrdensServicos>>
{
    public int OrdSerKey { get; private set; }
    public int EmpKey { get; private set; }
    public GetAllByKeyOrdensServicosQuery(int empKey, int ordserKey, int pageNumber = 1, int pageSize = 10)
    {
        EmpKey = empKey;
        OrdSerKey = ordserKey;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}