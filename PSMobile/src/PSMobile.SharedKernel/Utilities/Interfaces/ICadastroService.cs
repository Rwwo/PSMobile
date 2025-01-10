using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Interfaces;
public interface ICadastroService : IBaseReadServiceAll<Cadastros>, IBaseWriteService<Cadastros, CadastroInputModel>
{
    Task<PaginatedResult<Cadastros>> GetByCustomColumnAsync(string custom, int pageSize = 10, int pageNumber = 1);
    Task<PaginatedResult<Cadastros>> GetByDocNumberAsync(string NumDoc, int pageSize = 10, int pageNumber = 1);
}
