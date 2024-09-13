using PSMobile.core.Entities;
using PSMobile.SharedKernel.Common.Dtos;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface ICadastroService
{
    Task<List<Cadastros>> GetAllAsync();
    Task<List<Cadastros>> GetByCustomColumnAsync(string custom);
    Task<Cadastros> GravarAsync(ClienteInputModel cadastro);
    Task<bool> DeleteAsync(int cadKey);
}


