using MediatR;

namespace PSMobile.application.Queries.Cadastros;

public class GetCadastrosByCadKeyQuery : IRequest<core.Entities.Cadastros>
{
    public int CadKey { get; private set; }
    public GetCadastrosByCadKeyQuery(int cadKey)
    {
        CadKey = cadKey;
    }

}
