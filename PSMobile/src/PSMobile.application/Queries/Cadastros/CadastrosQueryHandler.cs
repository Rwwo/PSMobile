using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Repositories;

namespace PSMobile.application.Queries.Cadastros;

public class CadastrosQueryHandler
    : IRequestHandler<GetAllCadastrosQuery, PaginatedResult<core.Entities.Cadastros>>
    , IRequestHandler<GetCadastrosByCadKeyQuery, core.Entities.Cadastros>
    , IRequestHandler<GetAllCustomColumnCadastrosQuery, PaginatedResult<core.Entities.Cadastros>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public CadastrosQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<PaginatedResult<core.Entities.Cadastros>> Handle(GetAllCadastrosQuery request, CancellationToken cancellationToken)
    {
        return await _uow.CadastroRepository.GetAllAsync(null, null, request.PageNumber, request.PageSize);
    }

    public async Task<PaginatedResult<core.Entities.Cadastros>> Handle(GetAllCustomColumnCadastrosQuery request, CancellationToken cancellationToken)
    {
        var toLower = request.Custom.ToLower();

        Expression<Func<core.Entities.Cadastros, bool>>? filter = c => (c.cad_nome.ToLower().Contains(toLower) ||
                                                                        c.cad_cnpj.ToLower().Contains(toLower) ||
                                                                        c.cad_razao.ToLower().Contains(toLower)
                                                                        );

        return await _uow.CadastroRepository.GetAllAsync(filter, null, request.PageNumber, request.PageSize);
    }

    public async Task<core.Entities.Cadastros> Handle(GetCadastrosByCadKeyQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Cadastros, bool>>? filter = c => c.cad_key == request.CadKey;

        return await _uow.CadastroRepository.GetByIdAsync(filter);
    }
}
