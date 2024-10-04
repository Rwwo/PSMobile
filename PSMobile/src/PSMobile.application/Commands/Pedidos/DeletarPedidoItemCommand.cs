using MediatR;


namespace PSMobile.application.Commands.Pedidos;

public class DeletarPedidoItemCommand : IRequest<Unit>
{
    public DeletarPedidoItemCommand(int input)
    {
        PedIteKey = input;
    }

    public int PedIteKey { get; private set; }

}
