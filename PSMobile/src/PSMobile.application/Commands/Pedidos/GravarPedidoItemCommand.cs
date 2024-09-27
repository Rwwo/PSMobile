using MediatR;

using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.Pedidos;

public class GravarPedidoItemCommand : IRequest<PedidosItemGravarRetornoFuncao>
{
    public PedidoItemInputModel PedidoItemInputModel { get; private set; }

    public GravarPedidoItemCommand(PedidoItemInputModel input)
    {
        PedidoItemInputModel = input;
    }
}
