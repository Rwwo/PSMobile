using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Common.Dtos;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IPedidoService : IBaseReadServiceWithEmpKey<Pedidos>, IBaseWriteService<Pedidos, PedidoInputModel>
{
    Task<PaginatedResult<Pedidos>> GetByCustomColumnAsync(int empKey, string custom, int pageSize = 10, int pageNumber = 1);
}

