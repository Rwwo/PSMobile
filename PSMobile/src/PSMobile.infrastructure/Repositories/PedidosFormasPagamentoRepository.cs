using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class PedidosFormasPagamentoRepository : ReadRepository<PedidosFormasPagamento>, IPedidosFormasPagamentoRepository
{
    private readonly AppDbContext _ctx;
    public PedidosFormasPagamentoRepository(AppDbContext context)
        : base(context)
    {
        _ctx = context;
    }

    public async Task DeleteAsync(PedidosFormasPagamento entity)
    {
        _ctx.PedidosFormasPagamento.Remove(entity);
    }

    public async Task<PedidosFormasPagamento> GravarAsync(PedidoFormasPagamentoInputModel entity)
    {
        var input = new PedidosFormasPagamento
        {
            pedforpag_forpag_codigo = entity.pedforpag_forpag_codigo,
            pedforpag_ped_key = entity.pedforpag_ped_key,
            pedforpag_valor = entity.pedforpag_valor,
            pedforpag_lancado = 0,
            PedidosFormasPagamentoParcelas = entity.ParcelasInputModel.Select(x => new PedidosFormasPagamentoParcelas()
            {
                pedforpagpar_dataven = x.pedforpagpar_dataven,
                pedforpagpar_forpag_codigo = x.pedforpagpar_forpag_codigo,
                pedforpagpar_parcela = x.pedforpagpar_parcela,
                pedforpagpar_parcelas = x.pedforpagpar_parcelas,
                pedforpagpar_titulo = x.pedforpagpar_titulo,
                pedforpagpar_valor = x.pedforpagpar_valor,
            }).ToList()
        };

        await _ctx.PedidosFormasPagamento.AddAsync(input);

        return input;

    }
}