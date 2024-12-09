using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Gerais;

public class GetAllGeraisQueryHandler
    : IRequestHandler<GetAllGeraisQuery, PaginatedResult<core.Entities.Gerais>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public GetAllGeraisQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<PaginatedResult<core.Entities.Gerais>> Handle(GetAllGeraisQuery request, CancellationToken cancellationToken)
    {
        
        var includes = new List<Expression<Func<core.Entities.Gerais, object>>>
        {
            e => e.Empresa
        };

        return await _uow.GeraisRepository.GetAllAsync(null,
                                                       includes,
                                                       null,
                                                       null,
                                                       false,
                                                       request.PageNumber,
                                                       request.PageSize
                                                       );
    }
}
