using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.core.Interfaces;

public interface IPedidosRepository : IWriteRepository<PedidoInputModel, PedidosGravarRetornoFuncao>, IReadRepository<Pedidos>
{
    abstract Task<PedidosAtualizarRetornoFuncao> AtualizarAsync(PedidoAtualizarInputModel entity);
}
