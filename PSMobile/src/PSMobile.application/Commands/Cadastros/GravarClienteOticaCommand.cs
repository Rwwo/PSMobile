using MediatR;

using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.Cadastros;

public class GravarClienteOticaCommand : IRequest<ClienteOticaGravarRetornoFuncao>
{
    public ClienteOticaInputModel Cliente { get; private set; }

    public GravarClienteOticaCommand(ClienteOticaInputModel cliente)
    {
        Cliente = cliente;
    }

}
