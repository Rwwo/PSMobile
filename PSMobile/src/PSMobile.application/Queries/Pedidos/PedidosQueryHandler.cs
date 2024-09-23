
using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Repositories;

namespace PSMobile.application.Queries.Pedidos;

public class PedidosQueryHandler
    : IRequestHandler<GetAllPedidosQuery, PaginatedResult<core.Entities.Pedidos>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public PedidosQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }
    public async Task<PaginatedResult<core.Entities.Pedidos>> Handle(GetAllPedidosQuery request, CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<core.Entities.Pedidos, object>>>
        {
            e =>e.PedidosItens,
            e => e.PedidosFormasPagamento,
        };

        return await _uow.PedidosRepository.GetAllAsync(null, includes, request.PageNumber, request.PageSize);
    }
}
