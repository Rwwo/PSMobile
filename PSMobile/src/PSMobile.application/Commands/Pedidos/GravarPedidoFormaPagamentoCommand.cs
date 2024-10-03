using MediatR;

using PSMobile.core.InputModel;

namespace PSMobile.application.Commands.Pedidos;

public class GravarPedidoFormaPagamentoCommand : IRequest<Unit>
{
    public List<PedidoFormasPagamentoInputModel> Input { get; private set; }

    public GravarPedidoFormaPagamentoCommand(List<PedidoFormasPagamentoInputModel> input)
    {
        Input = input;
    }
}
