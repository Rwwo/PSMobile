using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.Services;
using PSMobile.infrastructure.Repositories;

namespace PSMobile.application.Queries.ProdutosEmpresas;

public class ProdutosEmpresasHandler
    : BaseService,
     IRequestHandler<GetProdutosEmpresasByEmpKeyQuery, PaginatedResult<core.Entities.ProdutosEmpresas>>,
     IRequestHandler<GetProdutosEmpresasByEmpKeyAndCustomQuery, PaginatedResult<core.Entities.ProdutosEmpresas>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public ProdutosEmpresasHandler(IUnitOfWork uow,
                                   IMapper map, INotificador notificador) : base(notificador)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<PaginatedResult<core.Entities.ProdutosEmpresas>> Handle(GetProdutosEmpresasByEmpKeyQuery request,
                                                                        CancellationToken cancellationToken)
    {
        if (request.EmpKey == 0)
        {
            Notificar("Consulta de produtos da empresa sem passagem de empresa");
            return PaginatedResult<core.Entities.ProdutosEmpresas>.Empty(request.PageNumber, request.PageSize);
        }

        Expression<Func<core.Entities.ProdutosEmpresas, bool>>? filter = c => (c.proemp_emp_key == request.EmpKey);

        var includes = new List<Expression<Func<core.Entities.ProdutosEmpresas, object>>>
        {
            e => e.Produto
        };


        Expression<Func<core.Entities.ProdutosEmpresas, object>> order = o => o.proemp_key;

        return await _uow.ProdutosEmpresasRepository.GetAllAsync(filter,
                                                                 includes,
                                                                 null,
                                                                 order,
                                                                 false,
                                                                 request.PageNumber,
                                                                 request.PageSize
                                                                 );
    }

    public async Task<PaginatedResult<core.Entities.ProdutosEmpresas>> Handle(GetProdutosEmpresasByEmpKeyAndCustomQuery request,
                                                            CancellationToken cancellationToken)
    {
        var toLower = request.Custom;

        Expression<Func<core.Entities.ProdutosEmpresas, bool>>? filter = c => (c.proemp_emp_key == request.EmpKey
                                                                                &&
                                                                                (
                                                                                    c.Produto.pro_codigo.Contains(toLower) ||
                                                                                    c.Produto.pro_codigo == toLower ||

                                                                                    c.Produto.pro_reduzido.Contains(toLower) ||
                                                                                    c.Produto.pro_reduzido == toLower ||

                                                                                    c.Produto.pro_nome.Contains(toLower) ||
                                                                                    c.Produto.pro_nome == toLower

                                                                                ));

        var includes = new List<Expression<Func<core.Entities.ProdutosEmpresas, object>>>
        {
            e => e.Produto
        };

        Expression<Func<core.Entities.ProdutosEmpresas, object>> order = o => o.proemp_key;

        return await _uow.ProdutosEmpresasRepository.GetAllAsync(filter,
                                                                 includes,
                                                                 null,
                                                                 order,
                                                                 false,
                                                                 request.PageNumber,
                                                                 request.PageSize
                                                                 );

    }
}