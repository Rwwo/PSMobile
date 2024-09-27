using PSMobile.core.Entities;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.core.Interfaces;

public interface ICadastroRepository : IWriteRepository<Cadastros, ClienteGravarRetornoFuncao>, IReadRepository<Cadastros>
{
}
