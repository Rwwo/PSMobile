using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Utilities.Services;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IPedidoService : IBaseReadServiceWithEmpKey<Pedidos>,
                                  IBaseWriteService<PedidosGravarRetornoFuncao,PedidoInputModel>
{
    Task<PaginatedResult<Pedidos>> GetByCustomColumnAsync(int empKey, string custom, int pageSize = 10, int pageNumber = 1);
    Task<PaginatedResult<Pedidos>> GetByPedKeyAsync(int empKey, int pedKey, int pageSize = 10, int pageNumber = 1);

    Task<Result<PedidosAtualizarRetornoFuncao>> AtualizarAsync(PedidoAtualizarInputModel entity);


}


