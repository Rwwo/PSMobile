using MediatR;

using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.Pedidos;

public class DeletarFormasPagamentoByPedKeyCommand : IRequest<Unit>
{
    public DeletarFormasPagamentoByPedKeyCommand(int pedKey)
    {
        PedKey = pedKey;
    }
    public int PedKey { get; private set; }
}
