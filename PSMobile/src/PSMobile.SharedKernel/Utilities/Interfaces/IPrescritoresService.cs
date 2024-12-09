using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IPrescritoresService : IBaseReadServiceAll<Prescritores>
{
    Task<PaginatedResult<Prescritores>> GetByCustomColumn(string nome, int pageSize = 10, int pageNumber = 1);
}
