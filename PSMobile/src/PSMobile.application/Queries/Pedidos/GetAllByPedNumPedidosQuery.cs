using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Pedidos;

public class GetAllByPedNumPedidosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.PedidosItens>>
{
    public int PedNum { get; private set; }
    public int EmpKey { get; private set; }
    public GetAllByPedNumPedidosQuery(int empKey, int pedNum, int pageNumber = 1, int pageSize = 10)
    {
        EmpKey = empKey;
        PedNum = pedNum;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
