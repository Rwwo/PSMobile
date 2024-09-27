using MediatR;

using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.Cadastros;

public class GravarCadastroCommand : IRequest<ClienteGravarRetornoFuncao>
{
    public CadastroInputModel Cliente { get; private set; }

    public GravarCadastroCommand(CadastroInputModel cliente)
    {
        Cliente = cliente;
    }

}
