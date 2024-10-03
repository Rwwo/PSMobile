using PSMobile.core.Entities;
using PSMobile.core.InputModel;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IPedidoFormaPagamentoService : IBaseWriteServiceWithDelete<PedidosFormasPagamento, List<PedidoFormasPagamentoInputModel>, Pedidos>
{
    Task DeleteAsync(PedidosFormasPagamento entity);
}

