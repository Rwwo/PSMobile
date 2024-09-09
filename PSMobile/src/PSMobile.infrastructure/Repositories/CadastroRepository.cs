
using Microsoft.EntityFrameworkCore;

using PSMobile.infrastructure.Context;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

namespace PSMobile.infrastructure.Repositories;
public class CadastroRepository : Repository<Cadastros>, ICadastroRepository
{
    public CadastroRepository(MyDbContext contexto)
        : base(contexto) { }

    public async Task<List<Cadastros>> GetAllCustomColumn(string custom)
    {
        var result = await _context
                                .Cadastros
                                .Where(c =>

                                    c.cad_nome.ToUpper().Contains(custom.ToUpper()) ||
                                    c.cad_cnpj.ToUpper().Contains(custom.ToUpper()) ||
                                    c.cad_razao.ToUpper().Contains(custom.ToUpper())
                                 ).ToListAsync();

        return result;
    }

    public async Task<Cadastros> GetByCadKeyAsync(int CadKey, params System.Linq.Expressions.Expression<Func<Cadastros, object>>[] includes)
    {
        var result = await _context
                                .Cadastros
                                .SingleOrDefaultAsync(t => t.cad_key == CadKey);

        return result;
    }
}
