using AutoMapper;
using System.Linq.Expressions;

using MediatR;
using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Pdvs;

public class GetAllPdvsByEmpKeyQueryHandler
    : IRequestHandler<GetAllPdvsByEmpKeyQuery, PaginatedResult<core.Entities.Pdvs>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public GetAllPdvsByEmpKeyQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<PaginatedResult<core.Entities.Pdvs>> Handle(GetAllPdvsByEmpKeyQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Pdvs, bool>> filtro = c => c.pdv_exc == 0 &&
                                                                 c.pdv_emp_key == request.EmpKey;

        return await _uow.PdvsRepository.GetAllAsync(filtro,
                                                       null,
                                                       null,
                                                       null,
                                                       false,
                                                       request.PageNumber,
                                                       request.PageSize
                                                       );
    }
}
