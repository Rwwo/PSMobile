using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.Pedidos;

public class GravarPedidoItemCommandHandler :
      IRequestHandler<GravarPedidoItemCommand, PedidosItemGravarRetornoFuncao>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public GravarPedidoItemCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<PedidosItemGravarRetornoFuncao> Handle(GravarPedidoItemCommand request, CancellationToken cancellationToken)
    {
        return await _uow.PedidosItemRepository.GravarAsync(request.PedidoItemInputModel);
    }
}