using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Prescritor;

public class GetPrescritorByKeyQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Prescritores>>
{
    public int PreKey { get; set; }
    public GetPrescritorByKeyQuery(int preKey, int pageSize = 100, int pageNumber = 1)
    {
        PreKey = preKey;

        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}
