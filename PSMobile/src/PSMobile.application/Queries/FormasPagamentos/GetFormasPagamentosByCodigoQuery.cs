using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.FormasPagamentos;

public class GetFormasPagamentosByCodigoQuery : BaseQueyLimits, IRequest<PaginatedResult<core.Entities.FormasPagamento>>
{
    public int ForPagCodigo { get; set; }
    public GetFormasPagamentosByCodigoQuery(int forPagCodigo, int pageSize = 1, int pageNumber = 1)
    {
        ForPagCodigo = forPagCodigo;
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}
