using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Gerais;
public class GetAllGeraisQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Gerais>>
{
    public GetAllGeraisQuery(int pageSize = 1, int pageNumber = 1)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}
