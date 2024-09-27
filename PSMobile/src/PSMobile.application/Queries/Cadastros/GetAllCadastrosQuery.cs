using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Cadastros;
public class GetAllCadastrosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Cadastros>>
{
    public GetAllCadastrosQuery(int pageNumber = 1, int pageSize = 10)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
