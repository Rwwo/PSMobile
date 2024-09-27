using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Pdvs;
public class GetAllPdvsByEmpKeyQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Pdvs>>
{
    public int EmpKey { get; set; }
    public GetAllPdvsByEmpKeyQuery(int empKey, int pageSize = 1, int pageNumber = 1)
    {
        EmpKey = empKey;
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}
