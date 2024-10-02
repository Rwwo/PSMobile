
using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.FormasPagamentos;

public class FormasPagamentosQueryHandler
    : IRequestHandler<GetAllFormasPagamentosQuery, PaginatedResult<core.Entities.FormasPagamento>>
    , IRequestHandler<GetFormasPagamentosByCodigoQuery, PaginatedResult<core.Entities.FormasPagamento>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public FormasPagamentosQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }
    public async Task<PaginatedResult<FormasPagamento>> Handle(GetAllFormasPagamentosQuery request,
                                                         CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.FormasPagamento, bool>> filtro = c => c.forpag_exc == 0;

        Expression<Func<core.Entities.FormasPagamento, object>> order = o => o.forpag_codigo;

        return await _uow.FormasPagamentosRepository.GetAllAsync(filtro,
                                                             null,
                                                             null,
                                                             order,
                                                             true,
                                                             request.PageNumber,
                                                             request.PageSize
                                                             );
    }

    public async Task<PaginatedResult<FormasPagamento>> Handle(GetFormasPagamentosByCodigoQuery request,
                                                         CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.FormasPagamento, bool>> filtro = c => c.forpag_exc == 0
                                                                    && c.forpag_codigo == request.ForPagCodigo;

        Expression<Func<core.Entities.FormasPagamento, object>> order = o => o.forpag_codigo;

        return await _uow.FormasPagamentosRepository.GetAllAsync(filtro,
                                                             null,
                                                             null,
                                                             order,
                                                             true,
                                                             request.PageNumber,
                                                             request.PageSize);
    }
}