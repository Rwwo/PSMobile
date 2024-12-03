using PSMobile.core.Entities;

namespace PSMobile.core.Interfaces;

public interface IUsuariosRepository : IReadRepository<Usuarios>
{
    Task<(bool, Usuarios)> GetAuthentication(string nome, string password);
}


