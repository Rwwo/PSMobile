using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Prescritor;

public class GetAllPrescritoresForNameQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.Prescritores>>
{
    public string Nome { get; private set; }
    public GetAllPrescritoresForNameQuery(string nome)
    {
        Nome = nome;
    }
    public GetAllPrescritoresForNameQuery(string nome, int pageNumber = 1, int pageSize = 10)
    {
        Nome = nome;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

}
