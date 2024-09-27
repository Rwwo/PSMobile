using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Funcionarios;

public class GetFuncionariosByNomeQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Funcionarios>>
{
     public string PartialName { get; private set; }
    public GetFuncionariosByNomeQuery(string partialName, int pageNumber = 1, int pageSize = 10)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;

        PartialName = partialName;
    }

}
