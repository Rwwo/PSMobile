using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Commands.Pedidos;

public class DeletarFormasPagamentoCommandHandler :
      IRequestHandler<DeletarFormasPagamentoByPedKeyCommand, Unit>,
      IRequestHandler<DeletarFormasPagamentoByPedForPagKeyCommand, Unit>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public DeletarFormasPagamentoCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    private async Task DeleteFormasPagamentoAsync(Expression<Func<core.Entities.PedidosFormasPagamento, bool>> filtro)
    {
        var includes = new List<Expression<Func<core.Entities.PedidosFormasPagamento, object>>>
        {
            e => e.PedidosFormasPagamentoParcelas
        };

        var formasPagamento = await _uow.PedidosFormasPagamentoRepository.GetAllAsync(
            filtro, includes, null, null, true, 1, 100
        );

        var formasPagamentoList = formasPagamento.Items.ToList();

        foreach (var item in formasPagamentoList)
        {
            var parcelasList = item.PedidosFormasPagamentoParcelas.ToList();

            foreach (var parcela in parcelasList)
            {
                await _uow.PedidosFormasPagamentoParcelasRepository.DeleteAsync(parcela);
            }

            await _uow.PedidosFormasPagamentoRepository.DeleteAsync(item);
        }

        await _uow.CommitAsync();
    }

    public async Task<Unit> Handle(DeletarFormasPagamentoByPedKeyCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.PedidosFormasPagamento, bool>> filtro =
            c => c.pedforpag_ped_key == request.PedKey;

        await DeleteFormasPagamentoAsync(filtro);

        return Unit.Value;
    }

    public async Task<Unit> Handle(DeletarFormasPagamentoByPedForPagKeyCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.PedidosFormasPagamento, bool>> filtro =
            c => c.pedforpag_key == request.PedForPagKey;

        await DeleteFormasPagamentoAsync(filtro);

        return Unit.Value;
    }
}
