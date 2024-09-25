using MediatR;

using PSMobile.application.Commands.Cadastros;
using PSMobile.SharedKernel.Common.Dtos;

namespace PSMobile.application.Commands.Pedidos;

public class GravarPedidoCommand : IRequest<core.Entities.Pedidos>
{
    public PedidoInputModel PedidoInputModel { get; private set; }

    public GravarPedidoCommand(PedidoInputModel input)
    {
        PedidoInputModel = input;
    }
}
