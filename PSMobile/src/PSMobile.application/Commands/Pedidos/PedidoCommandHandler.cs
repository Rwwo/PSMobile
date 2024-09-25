using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Common.Dtos.Extensions;

namespace PSMobile.application.Commands.Pedidos;

public class PedidoCommandHandler :
      IRequestHandler<GravarPedidoCommand, core.Entities.Pedidos>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public PedidoCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<core.Entities.Pedidos> Handle(GravarPedidoCommand request, CancellationToken cancellationToken)
    {
        var input = request.PedidoInputModel.ToPedido();

        return await _uow.PedidosRepository.GravarAsync(input);
    }
}