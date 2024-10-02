using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.FormasPagamentos;
public class GetAllFormasPagamentosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.FormasPagamento>>
{
    public GetAllFormasPagamentosQuery(int pageSize = 10, int pageNumber = 1)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}
