
using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Funcionarios;

public class FuncionariosQueryHandler
    : IRequestHandler<GetAllFuncionariosQuery, PaginatedResult<core.Entities.Funcionarios>>
    , IRequestHandler<GetFuncionariosByNomeQuery, PaginatedResult<core.Entities.Funcionarios>>
    , IRequestHandler<GetFuncionarioByKeyQuery, PaginatedResult<core.Entities.Funcionarios>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public FuncionariosQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<PaginatedResult<core.Entities.Funcionarios>> Handle(GetFuncionariosByNomeQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Funcionarios, bool>> filtro = c => c.fun_exc == 0 &&
                                                                         c.fun_nome.ToLower().Contains(request.PartialName.ToLower());

        Expression<Func<core.Entities.Funcionarios, object>> order = o => o.fun_nome;

        return await _uow.FuncionariosRepository.GetAllAsync(filtro,
                                                             null,
                                                             null,
                                                             order,
                                                             true,
                                                             request.PageNumber,
                                                             request.PageSize);
    }

    public async Task<PaginatedResult<core.Entities.Funcionarios>> Handle(GetAllFuncionariosQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Funcionarios, bool>> filtro = c => c.fun_exc == 0;

        Expression<Func<core.Entities.Funcionarios, object>> order = o => o.fun_nome;

        return await _uow.FuncionariosRepository.GetAllAsync(filtro,
                                                            null,
                                                            null,
                                                            order,
                                                            true,
                                                            request.PageNumber,
                                                            request.PageSize);
    }

    public async Task<PaginatedResult<core.Entities.Funcionarios>> Handle(GetFuncionarioByKeyQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Funcionarios, bool>> filtro = c => c.fun_exc == 0 &&
                                                                         c.fun_key == request.FunKey;

        return await _uow.FuncionariosRepository.GetAllAsync(filtro,
                                                            null,
                                                            null,
                                                            null,
                                                            true,
                                                            request.PageNumber,
                                                            request.PageSize);
    }
}
