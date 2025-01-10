using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.core.Interfaces;

public interface IClienteOticaRepository : IWriteRepository<ClienteOticaInputModel, ClienteOticaGravarRetornoFuncao>, IReadRepository<ClientesOtica>;
