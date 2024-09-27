using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.Pedidos;

public class GravarPedidoCommandHandler :
      IRequestHandler<GravarPedidoCommand, PedidosGravarRetornoFuncao>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public GravarPedidoCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<PedidosGravarRetornoFuncao> Handle(GravarPedidoCommand request, CancellationToken cancellationToken)
    {
        return await _uow.PedidosRepository.GravarAsync(request.PedidoInputModel);
    }
}
