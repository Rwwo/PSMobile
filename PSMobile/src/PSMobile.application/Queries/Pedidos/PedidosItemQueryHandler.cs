
using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.Entities;

namespace PSMobile.application.Queries.Pedidos;

public class PedidosItemQueryHandler
    : IRequestHandler<GetAllByPedNumPedidosQuery, PaginatedResult<PedidosItens>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public PedidosItemQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<PaginatedResult<PedidosItens>> Handle(GetAllByPedNumPedidosQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.PedidosItens, bool>> filtro = c => c.pedite_exc == 0 &&
                                                                        (c.pedite_emp_key == request.EmpKey &&
                                                                         c.pedite_ped_key == request.PedNum );

        var includes = new List<Expression<Func<core.Entities.PedidosItens, object>>>
        {
            e => e.Produto,
        };

        Expression<Func<core.Entities.PedidosItens, object>> order = o => o.pedite_item;

        return await _uow.PedidosItemRepository.GetAllAsync(filtro,
                                                            includes,
                                                            null,
                                                            order,
                                                            false,
                                                            request.PageNumber,
                                                            request.PageSize
                                                            );
    }
}
