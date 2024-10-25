using PSMobile.core.Entities;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.core.Interfaces;

public interface IOrdensServicosItensRepository : IWriteWithDeleteKeyRepository<InputModel.OrdensServicosItensInputModel, OrdensServicosItensGravarRetornoFuncao>,
                                                 IReadRepository<OrdensServicosItens>;