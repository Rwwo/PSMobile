using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Pedidos;

public class GetAllCustomColumnPedidosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Pedidos>>
{
    public string Custom { get; private set; }
    public int EmpKey { get; private set; }
    public GetAllCustomColumnPedidosQuery(int empKey, string custom, int pageNumber = 1, int pageSize = 10)
    {
        EmpKey = empKey;
        Custom = custom;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
