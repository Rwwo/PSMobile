using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IOrdemServicoService : IBaseReadServiceWithEmpKey<OrdensServicos>,
                                        IBaseWriteService<OrdensServicoGravarRetornoFuncao, OrdensServicosInputModel>
{

    Task<PaginatedResult<OrdensServicos>> GetByCustomColumnAsync(int empKey, string custom, int pageSize = 10, int pageNumber = 1);

    Task<PaginatedResult<OrdensServicos>> GetByOrdSerKeyAsync(int empKey, int ordSerKey, int pageSize = 10, int pageNumber = 1);
}


