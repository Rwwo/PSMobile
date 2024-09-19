using MediatR;

namespace PSMobile.application.Queries.Funcionarios;

public class GetFuncionariosByNomeQuery : IRequest<List<core.Entities.Funcionarios>>
{
    public string PartialName { get; private set; }
    public GetFuncionariosByNomeQuery(string partialName)
    {
        PartialName = partialName;
    }

}
