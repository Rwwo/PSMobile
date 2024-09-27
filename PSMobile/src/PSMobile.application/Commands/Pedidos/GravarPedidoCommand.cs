using MediatR;

using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.Pedidos;

public class GravarPedidoCommand : IRequest<PedidosGravarRetornoFuncao>
{
    public PedidoInputModel PedidoInputModel { get; private set; }

    public GravarPedidoCommand(PedidoInputModel input)
    {
        PedidoInputModel = input;
    }
}
