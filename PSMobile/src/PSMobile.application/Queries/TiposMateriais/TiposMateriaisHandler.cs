using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.Services;

using System.Linq.Expressions;

namespace PSMobile.application.Queries.TiposMateriais;

public class TiposMateriaisHandler
    : BaseService,
     IRequestHandler<GetAllTiposMateriais, PaginatedResult<core.Entities.TiposMateriais>>,
     IRequestHandler<GetTipoMaterialByKeyQuery, PaginatedResult<core.Entities.TiposMateriais>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public TiposMateriaisHandler(IUnitOfWork uow,
                                        IMapper map, INotificador notificador) : base(notificador)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<PaginatedResult<core.Entities.TiposMateriais>> Handle(GetAllTiposMateriais request, CancellationToken cancellationToken)
    {

        Expression<Func<core.Entities.TiposMateriais, bool>>? filter = c => c.tipmat_exc == 0;

        return await _uow.TiposMateriaisRepository.GetAllAsync(filter,
                                                                 null,
                                                                 null,
                                                                 null,
                                                                 false,
                                                                 request.PageNumber,
                                                                 request.PageSize
                                                                 );
    }

    public async Task<PaginatedResult<core.Entities.TiposMateriais>> Handle(GetTipoMaterialByKeyQuery request, CancellationToken cancellationToken)
    {

        Expression<Func<core.Entities.TiposMateriais, bool>>? filter = c => c.tipmat_exc == 0 && c.tipmat_key == request.TipMatKey;

        return await _uow.TiposMateriaisRepository.GetAllAsync(filter,
                                                                 null,
                                                                 null,
                                                                 null,
                                                                 false,
                                                                 request.PageNumber,
                                                                 request.PageSize
                                                                 );
    }
}
