using MediatR;

namespace PSMobile.application.Queries.Cadastros;

public class GetAllCustomColumnCadastrosQuery : IRequest<List<core.Entities.Cadastros>>
{
    public string Custom { get; private set; }
    public GetAllCustomColumnCadastrosQuery(string custom)
    {
        Custom = custom;
    }

}
