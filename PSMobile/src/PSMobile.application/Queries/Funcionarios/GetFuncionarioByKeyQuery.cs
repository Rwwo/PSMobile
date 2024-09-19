using MediatR;

namespace PSMobile.application.Queries.Funcionarios;

public class GetFuncionarioByKeyQuery : IRequest<core.Entities.Funcionarios>
{
    public GetFuncionarioByKeyQuery(int funKey)
    {
        FunKey = funKey;
    }

    public int FunKey { get; private set; }
}
