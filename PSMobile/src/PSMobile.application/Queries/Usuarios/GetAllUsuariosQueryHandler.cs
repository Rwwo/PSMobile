using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Usuarios;

public class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, PaginatedResult<core.Entities.Usuarios>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public GetAllUsuariosQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }
    public async  Task<PaginatedResult<core.Entities.Usuarios>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Usuarios, bool>> filtro = c => c.usu_exc == 0;

        Expression<Func<core.Entities.Usuarios, object>> order = o => o.usu_key;

        return await _uow.UsuariosRepository.GetAllAsync(filtro,
                                                        null,
                                                        null,
                                                        order,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize
                                                        );
    }
}
