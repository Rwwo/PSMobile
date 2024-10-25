using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.Services;

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

        Expression<Func<core.Entities.ProdutosEmpresas, bool>>? filter = c => c.proemp_exc == 0 &&
                                                                              (c.proemp_emp_key == request.EmpKey);

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
        var toUpper = request.Custom.ToUpper();

        Expression<Func<core.Entities.ProdutosEmpresas, bool>>? filter = c => c.proemp_exc == 0 &&
                                                                              (c.proemp_emp_key == request.EmpKey
                                                                                &&
                                                                                (
                                                                                    c.Produto.pro_exc == 0 &&

                                                                                    c.Produto.pro_codigo.Contains(toUpper) ||
                                                                                    c.Produto.pro_codigo == toUpper ||

                                                                                    c.Produto.pro_reduzido.Contains(toUpper) ||
                                                                                    c.Produto.pro_reduzido == toUpper ||

                                                                                    c.Produto.pro_nome.StartsWith(toUpper) ||
                                                                                    c.Produto.pro_nome == toUpper

                                                                                ));

        var includes = new List<Expression<Func<core.Entities.ProdutosEmpresas, object>>>
        {
            e => e.Produto
        };

        Expression<Func<core.Entities.ProdutosEmpresas, object>> order = o => o.Produto.pro_nome;

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