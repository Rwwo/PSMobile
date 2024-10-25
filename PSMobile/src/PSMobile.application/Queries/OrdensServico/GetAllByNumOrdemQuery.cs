using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.OrdensServico;

public class GetAllByNumOrdemQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.OrdensServicos>>
{
    public int NumOrdem { get; private set; }
    public int EmpKey { get; private set; }
    public GetAllByNumOrdemQuery(int empKey, int pedNum, int pageNumber = 1, int pageSize = 10)
    {
        EmpKey = empKey;
        NumOrdem = pedNum;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
