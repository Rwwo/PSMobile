
using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class PedidosFormasPagamentoParcelasRepository : ReadRepository<PedidosFormasPagamentoParcelas>, IPedidosFormasPagamentoParcelasRepository
{
    private readonly AppDbContext _ctx;
    public PedidosFormasPagamentoParcelasRepository(AppDbContext context)
        : base(context)
    {
        _ctx = context;
    }

    public async Task DeleteAsync(PedidosFormasPagamentoParcelas entity)
    {
        _ctx.PedidosFormasPagamentoParcelas.Remove(entity);
    }

    public async Task<PedidosFormasPagamentoParcelas> GravarAsync(PedidoFormasPagamentoParcelaInputModel entity)
    {
        var input = new PedidosFormasPagamentoParcelas
        {
            pedforpagpar_dataven = entity.pedforpagpar_dataven,
            pedforpagpar_parcela = entity.pedforpagpar_parcela,
            pedforpagpar_parcelas = entity.pedforpagpar_parcelas,
            pedforpagpar_titulo = entity.pedforpagpar_titulo,
            pedforpagpar_forpag_codigo = entity.pedforpagpar_forpag_codigo,
            pedforpagpar_valor = entity.pedforpagpar_valor,
            pedforpagpar_pedforpag_key = entity.pedforpagpar_pedforpag_key,
        };

        await _ctx.PedidosFormasPagamentoParcelas.AddAsync(input);

        return input;
    }
}
