
using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class UsuariosRepository : ReadRepository<Usuarios>, IUsuariosRepository
{
    private readonly AppDbContext _context;

    public UsuariosRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<(bool, Usuarios)> GetAuthentication(string nome, string password)
    {
        var nomeToLower = nome.ToLower();

        var usuarioEncontrado = _context.Usuarios.FirstOrDefault(c => c.usu_nome.ToLower().Equals(nomeToLower) && c.usu_senha.Equals(password));

        if (usuarioEncontrado is not null)
            return (true, usuarioEncontrado);

        return (false, null);

    }
}

