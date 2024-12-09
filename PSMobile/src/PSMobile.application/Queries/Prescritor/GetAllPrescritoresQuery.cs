using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Prescritor;
public class GetAllPrescritoresQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Prescritores>>
{
    public GetAllPrescritoresQuery(int pageSize = 100, int pageNumber = 1)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}
