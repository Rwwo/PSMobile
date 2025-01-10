using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.core.Services;

using System.Linq.Expressions;

namespace PSMobile.application.Queries.ReceituarioOtico;
public class ReceituariosOticosQueryHandler
                : BaseService,
                IRequestHandler<GetAllReceituariosOticosQuery, PaginatedResult<core.Entities.ReceituarioOculos>>,
                IRequestHandler<GetReceituarioOculosByNumOSQuery, PaginatedResult<core.Entities.ReceituarioOculos>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;


    public ReceituariosOticosQueryHandler(IUnitOfWork uow,
                                                    IMapper map, INotificador notificador) : base(notificador)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<PaginatedResult<ReceituarioOculos>> Handle(GetAllReceituariosOticosQuery request, CancellationToken cancellationToken)
    {
        if (request.EmpKey == 0)
        {
            Notificar("Consulta de receitas óculos da empresa sem passagem de empresa");
            return PaginatedResult<core.Entities.ReceituarioOculos>.Empty(request.PageNumber, request.PageSize);
        }

        Expression<Func<core.Entities.ReceituarioOculos, bool>>? filter = c => c.recocu_exc == 0 &&
                                                                              (c.recocu_emp_key == request.EmpKey);

        var includes = new List<Expression<Func<core.Entities.ReceituarioOculos, object>>>
        {
            e => e.Prescritores,
            e => e.Funcionarios,
            e => e.Cadastros,
            e => e.ClientesOtica,
            e => e.ReceituarioOculosAnexos,
            e => e.ReceituarioOculosArmacao
        };

        var thenIncludes = new List<Func<IQueryable<core.Entities.ReceituarioOculos>, IIncludableQueryable<core.Entities.ReceituarioOculos, object>>>
        {
            query => query.Include(e => e.ReceituarioOculosArmacaoMaterial.Where(t=>t.recocuarmmat_exc == 0))
                          .ThenInclude(i => i.TiposMateriais)
        };


        Expression<Func<core.Entities.ReceituarioOculos, object>> order = o => o.recocu_data_abert;

        var dados = await _uow.ReceituarioOculosRepository.GetAllAsync(filter,
                                                                       includes,
                                                                       thenIncludes,
                                                                       order,
                                                                       false,
                                                                       request.PageNumber,
                                                                       request.PageSize);
        return dados;
    }

    public async Task<PaginatedResult<ReceituarioOculos>> Handle(GetReceituarioOculosByNumOSQuery request, CancellationToken cancellationToken)
    {
        if (request.NumOS == 0)
        {
            Notificar("Consulta de receitas óculos da empresa sem passagem de número OS");
            return PaginatedResult<core.Entities.ReceituarioOculos>.Empty(request.PageNumber, request.PageSize);
        }

        Expression<Func<core.Entities.ReceituarioOculos, bool>>? filter = c => c.recocu_exc == 0 &&
                                                                              (c.recocu_numos == request.NumOS);

        var includes = new List<Expression<Func<core.Entities.ReceituarioOculos, object>>>
        {
            e => e.Prescritores,
            e => e.Funcionarios,
            e => e.Cadastros,
            e => e.ClientesOtica,
            e => e.TiposMateriais,

            e => e.ReceituarioOculosAnexos,
            e => e.ReceituarioOculosArmacao
        };

        var thenIncludes = new List<Func<IQueryable<core.Entities.ReceituarioOculos>, IIncludableQueryable<core.Entities.ReceituarioOculos, object>>>
        {
            query => query.Include(e => e.ReceituarioOculosArmacaoMaterial.Where(t=>t.recocuarmmat_exc == 0))
                          .ThenInclude(i => i.TiposMateriais)
        };


        Expression<Func<core.Entities.ReceituarioOculos, object>> order = o => o.recocu_data_abert;

        var dados = await _uow.ReceituarioOculosRepository.GetAllAsync(filter,
                                                                       includes,
                                                                       thenIncludes,
                                                                       order,
                                                                       false,
                                                                       request.PageNumber,
                                                                       request.PageSize);
        return dados;
    }
}
