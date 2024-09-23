using MediatR;

using PSMobile.infrastructure.Repositories;

namespace PSMobile.application.Queries.Pedidos;
public class GetAllPedidosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Pedidos>>
{
    public GetAllPedidosQuery() { }
    public GetAllPedidosQuery(int pageNumber = 1, int pageSize = 10)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
