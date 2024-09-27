using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Cidades;
public class GetAllCidadesQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Cidades>>
{
    public GetAllCidadesQuery(int pageNumber = 1, int pageSize = 10000)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
