using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.TiposMateriais;
public class GetAllTiposMateriais : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.TiposMateriais>>
{
    public GetAllTiposMateriais(int pageSize = 10, int pageNumber = 1)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}

