using PSMobile.core.Entities;
using PSMobile.SharedKernel.Common.Dtos;
using PSMobile.SharedKernel.Utilities.Services;

namespace PSMobile.SharedKernel.Utilities.Interfaces;
public interface ICadastroService
{
    Task<Result<bool>> DeleteAsync(int cadKey);
    Task<List<Cadastros>> GetAllAsync();
    Task<List<Cadastros>> GetByCustomColumnAsync(string custom);
    Task<Result<Cadastros>> GravarAsync(CadastroInputModel cadastro);
}
