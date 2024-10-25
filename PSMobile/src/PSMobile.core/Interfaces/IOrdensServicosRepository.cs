using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.core.Interfaces;

public interface IOrdensServicosRepository : IWriteRepository<OrdensServicosInputModel, OrdensServicoGravarRetornoFuncao>,
                                             IReadRepository<OrdensServicos>
{

    abstract Task<OrdensServicoGravarRetornoFuncao> AtualizarAsync(OrdensServicosInputModel entity);
}
