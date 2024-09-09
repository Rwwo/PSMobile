using System.Linq.Expressions;

using PSMobile.core.Entities;

namespace PSMobile.core.Interfaces;

public interface ICadastroRepository : IRepository<Cadastros>
{
    Task<List<Cadastros>> GetAllCustomColumn(string custom);
    Task<Cadastros> GetByCadKeyAsync(int CadKey, params Expression<Func<Cadastros, object>>[] includes);

}