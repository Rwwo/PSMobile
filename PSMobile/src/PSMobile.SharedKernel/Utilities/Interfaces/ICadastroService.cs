using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Common.Dtos;

namespace PSMobile.SharedKernel.Utilities.Interfaces;
public interface ICadastroService : IBaseReadService<Cadastros>, IBaseWriteService<Cadastros, CadastroInputModel>
{
    Task<PaginatedResult<Cadastros>> GetByCustomColumnAsync(string custom, int pageSize = 10, int pageNumber = 1);
}
