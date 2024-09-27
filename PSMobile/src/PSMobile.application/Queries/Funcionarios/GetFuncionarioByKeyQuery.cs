using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Funcionarios;

public class GetFuncionarioByKeyQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Funcionarios>>
{
    public int FunKey { get; private set; }
    public GetFuncionarioByKeyQuery(int funKey, int pageNumber = 1, int pageSize = 10)
    {
        FunKey = funKey;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

}
