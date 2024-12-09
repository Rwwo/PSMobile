using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.ReceituarioOtico;

public class GetReceituarioOculosByNumOSQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.ReceituarioOculos>>
{
    public int NumOS { get; set; }

    public GetReceituarioOculosByNumOSQuery( int numos, int pageNumber = 1, int pageSize = 10)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        NumOS = numos;
    }
}
