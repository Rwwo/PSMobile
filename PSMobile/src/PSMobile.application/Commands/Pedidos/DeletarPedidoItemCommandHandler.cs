using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Commands.Pedidos;

public class DeletarPedidoItemCommandHandler :
      IRequestHandler<DeletarPedidoItemCommand, Unit>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public DeletarPedidoItemCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<Unit> Handle(DeletarPedidoItemCommand request, CancellationToken cancellationToken)
    {
        await _uow.PedidosItemRepository.DeleteAsync(request.PedIteKey);
        return Unit.Value;
    }
}
