using PSMobile.core.Entities;
using PSMobile.core.InputModel;

namespace PSMobile.core.Interfaces;

public interface IPedidosFormasPagamentoRepository : IWriteWithDeleteRepository<PedidoFormasPagamentoInputModel, PedidosFormasPagamento>,
                                                    IReadRepository<PedidosFormasPagamento>;

