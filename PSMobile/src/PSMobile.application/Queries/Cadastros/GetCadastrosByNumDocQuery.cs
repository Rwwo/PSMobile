using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Cadastros;

public class GetCadastrosByNumDocQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Cadastros>>
{
    public string NumDoc { get; private set; }
    public GetCadastrosByNumDocQuery(string numDoc, int pageNumber = 1,  int pageSize = 10)
    {
        NumDoc = numDoc;
        PageNumber = pageNumber;
        PageSize = pageSize;    
    }
}
