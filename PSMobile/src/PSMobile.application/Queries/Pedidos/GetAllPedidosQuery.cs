using MediatR;

using PSMobile.infrastructure.Repositories;

namespace PSMobile.application.Queries.Pedidos;
public class GetAllPedidosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Pedidos>>
{
    public int EmpKey { get; set; }
    public GetAllPedidosQuery(int empKey, int pageNumber = 1, int pageSize = 10)
    {
        EmpKey = empKey;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
