using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.ReceituarioOtico;
public class GetAllReceituariosOticosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.ReceituarioOculos>>
{
    public int EmpKey { get; set; }

    public GetAllReceituariosOticosQuery(int empkey, int pageNumber = 1, int pageSize = 10)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        EmpKey = empkey;
    }
}
