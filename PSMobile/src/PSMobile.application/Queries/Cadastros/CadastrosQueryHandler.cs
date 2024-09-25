using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.application.Queries.Cadastros;

public class CadastrosQueryHandler
    : IRequestHandler<GetAllCadastrosQuery, PaginatedResult<core.Entities.Cadastros>>
    , IRequestHandler<GetCadastrosByCadKeyQuery, PaginatedResult<core.Entities.Cadastros>>
    , IRequestHandler<GetCadastrosByNumDocQuery, PaginatedResult<core.Entities.Cadastros>>
    , IRequestHandler<GetAllCustomColumnCadastrosQuery, PaginatedResult<core.Entities.Cadastros>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;
    private readonly IPssysValidacoesService _psservice;

    public CadastrosQueryHandler(IUnitOfWork uow, IMapper map, IPssysValidacoesService psservice)
    {
        _uow = uow;
        _map = map;
        _psservice = psservice;
    }

    public async Task<PaginatedResult<core.Entities.Cadastros>> Handle(GetAllCadastrosQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Cadastros, object>> order = o => o.cad_key;

        return await _uow.CadastroRepository.GetAllAsync(null,
                                                        null,
                                                        null,
                                                        order,
                                                        true,
                                                        request.PageNumber,
                                                        request.PageSize);
    }

    public async Task<PaginatedResult<core.Entities.Cadastros>> Handle(GetAllCustomColumnCadastrosQuery request, CancellationToken cancellationToken)
    {
        var toLower = request.Custom.ToLower();

        Expression<Func<core.Entities.Cadastros, bool>>? filter = c => (c.cad_nome.ToLower().Contains(toLower) ||
                                                                        (c.cad_cnpj.ToLower().Contains(toLower) || c.cad_cnpj.ToLower().Equals(toLower)) ||
                                                                        c.cad_razao.ToLower().Contains(toLower)
                                                                        );
        Expression<Func<core.Entities.Cadastros, object>> order = o => o.cad_key;


        return await _uow.CadastroRepository.GetAllAsync(filter,
                                                        null,
                                                        null,
                                                        order,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize);
    }

    public async Task<PaginatedResult<core.Entities.Cadastros>> Handle(GetCadastrosByCadKeyQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Cadastros, bool>>? filter = c => c.cad_key == request.CadKey;

        return await _uow.CadastroRepository.GetAllAsync(filter,
                                                null,
                                                null,
                                                null,
                                                false,
                                                request.PageNumber,
                                                request.PageSize);
    }

    public async Task<PaginatedResult<core.Entities.Cadastros>> Handle(GetCadastrosByNumDocQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Cadastros, bool>>? filter = c => c.cad_cnpj.Equals(_psservice.PSFormatarCNPJ(request.NumDoc));

        return await _uow.CadastroRepository.GetAllAsync(filter,
                                        null,
                                        null,
                                        null,
                                        false,
                                        request.PageNumber,
                                        request.PageSize);
    }
}
