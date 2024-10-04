using MediatR;

using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IPedidoItemService : IBaseWriteServiceWithDelete<PedidosItemGravarRetornoFuncao, PedidoItemInputModel, PedidosItens>
{
    Task<PaginatedResult<PedidosItens>> GetAllByNumPedAsync(int empKey, int numPed, int pageSize = 10, int pageNumber = 1);
}

