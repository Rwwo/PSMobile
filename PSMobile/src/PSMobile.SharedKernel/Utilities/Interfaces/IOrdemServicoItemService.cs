using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IOrdemServicoItemService : IBaseWriteServiceWithDelete<OrdensServicosItensGravarRetornoFuncao, OrdensServicosItensInputModel, OrdensServicosItens>
{
    Task<PaginatedResult<OrdensServicosItens>> GetAllByNumOrdemAsync(int empKey, int numOrdem, int pageSize = 10, int pageNumber = 1);
}


