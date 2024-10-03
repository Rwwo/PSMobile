using PSMobile.core.Entities;
using PSMobile.core.InputModel;

namespace PSMobile.core.Interfaces;

public interface IPedidosFormasPagamentoParcelasRepository : IWriteWithDeleteRepository<PedidoFormasPagamentoParcelaInputModel, PedidosFormasPagamentoParcelas>,
                                                            IReadRepository<PedidosFormasPagamentoParcelas>;

