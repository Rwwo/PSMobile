using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Pedidos;

public class GetAllByKeyPedidosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Pedidos>>
{
    public int PedKey { get; private set; }
    public int EmpKey { get; private set; }
    public GetAllByKeyPedidosQuery(int empKey, int pedKey, int pageNumber = 1, int pageSize = 10)
    {
        EmpKey = empKey;
        PedKey = pedKey;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}