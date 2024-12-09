using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.TiposMateriais;

public class GetTipoMaterialByKeyQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.TiposMateriais>>
{
    public int TipMatKey { get; set; }
    public GetTipoMaterialByKeyQuery(int tipMatKey, int pageSize = 10, int pageNumber = 1)
    {
        TipMatKey = tipMatKey;
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}

