
using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Cidades;

public class CidadesQueryHandler
    : IRequestHandler<GetAllCidadesQuery, PaginatedResult<core.Entities.Cidades>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public CidadesQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }
    public async Task<PaginatedResult<core.Entities.Cidades>> Handle(GetAllCidadesQuery request, CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<core.Entities.Cidades, object>>>
        {
            e => e.Ufs
        };

        Expression<Func<core.Entities.Cidades, object>> order = o => o.cid_nome;

        var dados = await _uow.CidadesRepository.GetAllAsync(null,
                                                             includes,
                                                             null,
                                                             null,
                                                             true,
                                                             request.PageNumber,
                                                             request.PageSize);
        return dados;
    }
}
