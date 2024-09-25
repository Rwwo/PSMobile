using MediatR;

using PSMobile.infrastructure.Repositories;

namespace PSMobile.application.Queries.Cadastros;

public class GetAllCustomColumnCadastrosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Cadastros>>
{
    public string Custom { get; private set; }
    public GetAllCustomColumnCadastrosQuery(string custom)
    {
        Custom = custom;
    }
    public GetAllCustomColumnCadastrosQuery(string custom, int pageNumber = 1, int pageSize = 10)
    {
        Custom = custom;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

}
