using PSMobile.core.Entities;

namespace PSMobile.SharedKernel.Utilities;

public interface ICadastroService
{
    Task<List<Cadastros>> GetAllAsync();
    Task<List<Cadastros>> GetByCustomColumnAsync(string custom);
    Task<Cadastros> CreateAsync(Cadastros cadastro);
    Task<Cadastros> UpdateAsync(int cadKey, Cadastros cadastro);
    Task<bool> DeleteAsync(int cadKey);
}


