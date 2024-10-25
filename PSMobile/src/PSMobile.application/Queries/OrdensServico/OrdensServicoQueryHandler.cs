
using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.OrdensServico;
public class OrdensServicoQueryHandler
    : IRequestHandler<GetAllByNumOrdemQuery, PaginatedResult<core.Entities.OrdensServicos>>,
      IRequestHandler<GetAllOrdensServicosQuery, PaginatedResult<core.Entities.OrdensServicos>>,
      IRequestHandler<GetAllByKeyOrdensServicosQuery, PaginatedResult<core.Entities.OrdensServicos>>,
      IRequestHandler<GetAllCustomColumnOrdensServicosQuery, PaginatedResult<core.Entities.OrdensServicos>>
{

    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;
    public OrdensServicoQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }
    public async Task<PaginatedResult<core.Entities.OrdensServicos>> Handle(GetAllOrdensServicosQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.OrdensServicos, bool>> filtro = c => c.ordser_exc == 0 &&
                                                                           c.ordser_emp_key == request.EmpKey;

        var includes = new List<Expression<Func<core.Entities.OrdensServicos, object>>>
        {
            e => e.Cliente,
            e => e.Funcionario,
        };

        var thenIncludes = new List<Func<IQueryable<core.Entities.OrdensServicos>, IIncludableQueryable<core.Entities.OrdensServicos, object>>>
        {
            query => query.Include(e => e.OrdensServicosItens.Where(t=>t.ordserite_exc == 0))
                          .ThenInclude(i => i.Produto)
        };

        Expression<Func<core.Entities.OrdensServicos, object>> order = o => o.ordser_key;

        return await _uow.OrdensServicosRepository.GetAllAsync(filtro,
                                                                includes,
                                                                thenIncludes,
                                                                order,
                                                                false,
                                                                request.PageNumber,
                                                                request.PageSize
                                                                );
    }

    public async Task<PaginatedResult<core.Entities.OrdensServicos>> Handle(GetAllCustomColumnOrdensServicosQuery request, CancellationToken cancellationToken)
    {
        var toLower = request.Custom.ToLower();

        Expression<Func<core.Entities.OrdensServicos, bool>> filtro = c => c.ordser_exc == 0 &&
                                                                          (c.ordser_numero.ToString().ToLower().Equals(toLower) ||
                                                                          (c.Cliente.cad_nome.ToLower().Contains(toLower) || c.Cliente.cad_nome.ToLower().Equals(toLower)));

        var includes = new List<Expression<Func<core.Entities.OrdensServicos, object>>>
        {
            e => e.Cliente,
            e => e.Funcionario,
        };

        var thenIncludes = new List<Func<IQueryable<core.Entities.OrdensServicos>, IIncludableQueryable<core.Entities.OrdensServicos, object>>>
        {
            query => query.Include(e => e.OrdensServicosItens.Where(t=>t.ordserite_exc == 0))
                          .ThenInclude(i => i.Produto)
        };

        Expression<Func<core.Entities.OrdensServicos, object>> order = o => o.ordser_key;

        return await _uow.OrdensServicosRepository.GetAllAsync(filtro,
                                                        includes,
                                                        thenIncludes,
                                                        order,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize
                                                        );
    }

    public async Task<PaginatedResult<core.Entities.OrdensServicos>> Handle(GetAllByKeyOrdensServicosQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.OrdensServicos, bool>> filtro = c => c.ordser_exc == 0 &&
                                                                          (c.ordser_key == request.OrdSerKey &&
                                                                           c.ordser_emp_key == request.EmpKey);

        var includes = new List<Expression<Func<core.Entities.OrdensServicos, object>>>
        {
            e => e.Cliente,
            e => e.Funcionario,
        };

        var thenIncludes = new List<Func<IQueryable<core.Entities.OrdensServicos>, IIncludableQueryable<core.Entities.OrdensServicos, object>>>
        {
            query => query.Include(e => e.OrdensServicosItens.Where(t=>t.ordserite_exc == 0))
                          .ThenInclude(i => i.Produto)
        };

        Expression<Func<core.Entities.OrdensServicos, object>> order = o => o.ordser_key;

        return await _uow.OrdensServicosRepository.GetAllAsync(filtro,
                                                        includes,
                                                        thenIncludes,
                                                        order,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize
                                                        );
    }

    public async Task<PaginatedResult<OrdensServicos>> Handle(GetAllByNumOrdemQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.OrdensServicos, bool>> filtro = c => c.ordser_exc == 0 &&
                                                                          (c.ordser_key == request.NumOrdem &&
                                                                           c.ordser_emp_key == request.EmpKey);

        var includes = new List<Expression<Func<core.Entities.OrdensServicos, object>>>
        {
            e => e.Cliente,
            e => e.Funcionario,
        };

        var thenIncludes = new List<Func<IQueryable<core.Entities.OrdensServicos>, IIncludableQueryable<core.Entities.OrdensServicos, object>>>
        {
            query => query.Include(e => e.OrdensServicosItens.Where(t=>t.ordserite_exc == 0))
                          .ThenInclude(i => i.Produto)
        };

        Expression<Func<core.Entities.OrdensServicos, object>> order = o => o.ordser_key;

        return await _uow.OrdensServicosRepository.GetAllAsync(filtro,
                                                        includes,
                                                        thenIncludes,
                                                        order,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize
                                                        );
    }
}
