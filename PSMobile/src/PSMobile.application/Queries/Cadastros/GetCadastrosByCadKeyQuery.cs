using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Cadastros;

public class GetCadastrosByCadKeyQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Cadastros>>
{
    public int CadKey { get; private set; }
    public GetCadastrosByCadKeyQuery(int cadKey, int pageSize = 10, int pageNumber = 1)
    {
        CadKey = cadKey;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

}
