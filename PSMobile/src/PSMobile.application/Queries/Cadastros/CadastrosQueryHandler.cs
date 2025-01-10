using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
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
    private List<Expression<Func<core.Entities.Cadastros, object>>>? includes = null;

    public CadastrosQueryHandler(IUnitOfWork uow, IMapper map, IPssysValidacoesService psservice)
    {
        _uow = uow;
        _map = map;
        _psservice = psservice;

        includes = new List<Expression<Func<core.Entities.Cadastros, object>>>()
        {
            e => e.ClientesOtica
        };
    }

    public async Task<PaginatedResult<core.Entities.Cadastros>> Handle(GetAllCadastrosQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Cadastros, bool>>? filter = c => c.CadastroCliente.cad_cli_exc == 0;

        Expression<Func<core.Entities.Cadastros, object>> order = o => o.cad_key;

        return await _uow.CadastroRepository.GetAllAsync(filter,
                                                        includes,
                                                        null,
                                                        order,
                                                        true,
                                                        request.PageNumber,
                                                        request.PageSize);
    }

    public async Task<PaginatedResult<core.Entities.Cadastros>> Handle(GetAllCustomColumnCadastrosQuery request, CancellationToken cancellationToken)
    {
        var toUpper = request.Custom.ToUpper();

        Expression<Func<core.Entities.Cadastros, bool>>? filter = c => c.CadastroCliente.cad_cli_exc == 0 &&
                                                                        (
                                                                            c.cad_nome.StartsWith(toUpper) ||
                                                                            (c.cad_cnpj.Contains(toUpper) || c.cad_cnpj.Equals(toUpper))
                                                                        );

        Expression<Func<core.Entities.Cadastros, object>> order = o => o.cad_nome;


        return await _uow.CadastroRepository.GetAllAsync(filter,
                                                        includes,
                                                        null,
                                                        order,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize);
    }

    public async Task<PaginatedResult<core.Entities.Cadastros>> Handle(GetCadastrosByCadKeyQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Cadastros, bool>>? filter = c => c.CadastroCliente.cad_cli_exc == 0 &&
                                                                       c.cad_key == request.CadKey;

        return await _uow.CadastroRepository.GetAllAsync(filter,
                                                includes,
                                                null,
                                                null,
                                                false,
                                                request.PageNumber,
                                                request.PageSize);
    }

    public async Task<PaginatedResult<core.Entities.Cadastros>> Handle(GetCadastrosByNumDocQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Cadastros, bool>>? filter = c => c.CadastroCliente.cad_cli_exc == 0 &&
                                                                       c.cad_cnpj.Equals(_psservice.PSFormatarCNPJ(request.NumDoc));

        return await _uow.CadastroRepository.GetAllAsync(filter,
                                        includes,
                                        null,
                                        null,
                                        false,
                                        request.PageNumber,
                                        request.PageSize);
    }
}
