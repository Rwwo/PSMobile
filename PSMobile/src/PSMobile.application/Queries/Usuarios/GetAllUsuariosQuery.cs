using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Usuarios;
public class GetAllUsuariosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Usuarios>>
{
    public GetAllUsuariosQuery(int pageNumber = 1, int pageSize = 10)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
