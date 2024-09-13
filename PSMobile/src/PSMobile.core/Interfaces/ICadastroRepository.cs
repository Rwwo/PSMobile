using System.Linq.Expressions;

using PSMobile.core.Entities;

namespace PSMobile.core.Interfaces;

public interface ICadastroRepository
{
    Task DeleteAsync(Cadastros input);
    Task<List<Cadastros>> GetAllAsync();
    Task<Cadastros> ClientesGravarAsync(Cadastros input);
    Task<List<Cadastros>> GetAllCustomColumnAsync(string custom);
    Task<Cadastros> GetByCadKeyAsync(int CadKey, params Expression<Func<Cadastros, object>>[] includes);

}