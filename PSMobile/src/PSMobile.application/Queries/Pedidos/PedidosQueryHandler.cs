
using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Pedidos;
public class PedidosQueryHandler
    : IRequestHandler<GetAllPedidosQuery, PaginatedResult<core.Entities.Pedidos>>,
      IRequestHandler<GetAllCustomColumnPedidosQuery, PaginatedResult<core.Entities.Pedidos>>,
      IRequestHandler<GetAllByKeyPedidosQuery, PaginatedResult<core.Entities.Pedidos>>


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
        Expression<Func<core.Entities.Pedidos, bool>> filtro = c => c.ped_exc == 0;

        var includes = new List<Expression<Func<core.Entities.Pedidos, object>>>
        {
            e => e.Cliente,
            e => e.Funcionario,
            //e => e.PedidosItens,
            //e => e.PedidosFormasPagamento
        };

        var thenIncludes = new List<Func<IQueryable<core.Entities.Pedidos>, IIncludableQueryable<core.Entities.Pedidos, object>>>
        {
            query => query.Include(e => e.PedidosItens)
                          .ThenInclude(i => i.Produto),
            query => query.Include(e=>e.PedidosFormasPagamento)
                            .ThenInclude(i=>i.PedidosFormasPagamentoParcelas),
            query => query.Include(e=>e.PedidosFormasPagamento)
                            .ThenInclude(i=>i.FormaPagamento)
        };

        Expression<Func<core.Entities.Pedidos, object>> order = o => o.ped_key;

        return await _uow.PedidosRepository.GetAllAsync(filtro,
                                                        includes,
                                                        thenIncludes,
                                                        order,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize
                                                        );
    }

    public async Task<PaginatedResult<core.Entities.Pedidos>> Handle(GetAllCustomColumnPedidosQuery request, CancellationToken cancellationToken)
    {
        var toLower = request.Custom.ToLower();

        Expression<Func<core.Entities.Pedidos, bool>> filtro = c => c.ped_exc == 0 &&
                                                                    (c.ped_numero.ToString().ToLower().Equals(toLower) ||
                                                                    (c.Cliente.cad_nome.ToLower().Contains(toLower) || c.Cliente.cad_nome.ToLower().Equals(toLower)));

        var includes = new List<Expression<Func<core.Entities.Pedidos, object>>>
        {
            e => e.Cliente,
            e => e.Funcionario,
            //e => e.PedidosItens,
            //e => e.PedidosFormasPagamento
        };

        var thenIncludes = new List<Func<IQueryable<core.Entities.Pedidos>, IIncludableQueryable<core.Entities.Pedidos, object>>>
        {
            query => query.Include(e => e.PedidosItens)
                          .ThenInclude(i => i.Produto),
            query => query.Include(e=>e.PedidosFormasPagamento)
                            .ThenInclude(i=>i.PedidosFormasPagamentoParcelas),
            query => query.Include(e=>e.PedidosFormasPagamento)
                            .ThenInclude(i=>i.FormaPagamento)
        };


        Expression<Func<core.Entities.Pedidos, object>> order = o => o.ped_key;

        return await _uow.PedidosRepository.GetAllAsync(filtro,
                                                        includes,
                                                        thenIncludes,
                                                        order,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize
                                                        );
    }

    public async Task<PaginatedResult<core.Entities.Pedidos>> Handle(GetAllByKeyPedidosQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Pedidos, bool>> filtro = c => c.ped_exc == 0 &&
                                                                    (c.ped_key == request.PedKey && c.ped_emp_key == request.EmpKey);


        var includes = new List<Expression<Func<core.Entities.Pedidos, object>>>
        {
            e => e.Cliente,
            e => e.Funcionario,
            //e => e.PedidosItens,
            //e => e.PedidosFormasPagamento
        };

        var thenIncludes = new List<Func<IQueryable<core.Entities.Pedidos>, IIncludableQueryable<core.Entities.Pedidos, object>>>
        {
            query => query.Include(e => e.PedidosItens)
                          .ThenInclude(i => i.Produto),
            query => query.Include(e=>e.PedidosFormasPagamento)
                            .ThenInclude(i=>i.PedidosFormasPagamentoParcelas),
            query => query.Include(e=>e.PedidosFormasPagamento)
                            .ThenInclude(i=>i.FormaPagamento)
        };


        Expression<Func<core.Entities.Pedidos, object>> order = o => o.ped_key;

        return await _uow.PedidosRepository.GetAllAsync(filtro,
                                                        includes,
                                                        thenIncludes,
                                                        order,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize
                                                        );
    }
}
