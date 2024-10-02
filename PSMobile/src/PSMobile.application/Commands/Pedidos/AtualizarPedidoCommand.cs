using MediatR;

using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.Pedidos;

public class AtualizarPedidoCommand : IRequest<PedidosAtualizarRetornoFuncao>
{
    public PedidoAtualizarInputModel PedidoAtualizarInputModel { get; private set; }

    public AtualizarPedidoCommand(PedidoAtualizarInputModel input)
    {
        PedidoAtualizarInputModel = input;
    }
}
