using PSMobile.core.Entities;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.core.Interfaces;

public interface IPedidosItemRepository : IWriteRepository<InputModel.PedidoItemInputModel, PedidosItemGravarRetornoFuncao>, IReadRepository<PedidosItens>
{ }