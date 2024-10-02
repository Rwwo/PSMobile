using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.Pedidos;

public class AtualizarPedidoCommandHandler :
      IRequestHandler<AtualizarPedidoCommand, PedidosAtualizarRetornoFuncao>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public AtualizarPedidoCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<PedidosAtualizarRetornoFuncao> Handle(AtualizarPedidoCommand request, CancellationToken cancellationToken)
    {
        return await _uow.PedidosRepository.AtualizarAsync(request.PedidoAtualizarInputModel);
    }
}
