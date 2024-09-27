using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Funcionarios;

public class GetAllFuncionariosQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Funcionarios>>
{
    public GetAllFuncionariosQuery(int pageNumber = 1, int pageSize = 50)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
