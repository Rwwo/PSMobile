using MediatR;

namespace PSMobile.application.Queries.Funcionarios;

public class GetFuncionarioByKeyQuery : IRequest<core.Entities.Funcionarios>
{
    public int FunKey { get; set; }
    public GetFuncionarioByKeyQuery(int funKey)
    {
        FunKey = funKey;
    }

}
