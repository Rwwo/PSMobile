using PSMobile.core.Entities;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.core.Interfaces;

public interface IPedidosItemRepository : IWriteWithDeleteKeyRepository<InputModel.PedidoItemInputModel, PedidosItemGravarRetornoFuncao>, 
                                        IReadRepository<PedidosItens>;
