using AutoMapper;

using MediatR;

using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;

namespace PSMobile.application.Commands.Pedidos;

public class GravarPedidoFormaPagamentoCommandHandler :
      IRequestHandler<GravarPedidoFormaPagamentoCommand, Unit>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public GravarPedidoFormaPagamentoCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<Unit> Handle(GravarPedidoFormaPagamentoCommand request, CancellationToken cancellationToken)
    {
        var tasks = new List<Task>();

        foreach (var item in request.Input)
        {
            var task = ProcessItemAsync(item, cancellationToken);
            tasks.Add(task);
        }

        await Task.WhenAll(tasks);

        await _uow.CommitAsync();

        return Unit.Value;
    }

    private async Task ProcessItemAsync(PedidoFormasPagamentoInputModel item, CancellationToken cancellationToken)
    {
        await _uow.PedidosFormasPagamentoRepository.GravarAsync(item);
    }
}
