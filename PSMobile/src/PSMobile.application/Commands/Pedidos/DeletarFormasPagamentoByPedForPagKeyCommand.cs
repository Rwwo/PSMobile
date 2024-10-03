using MediatR;

namespace PSMobile.application.Commands.Pedidos;

public class DeletarFormasPagamentoByPedForPagKeyCommand : IRequest<Unit>
{
    public DeletarFormasPagamentoByPedForPagKeyCommand(int input)
    {
        PedForPagKey = input;
    }

    public int PedForPagKey { get; private set; }

}
