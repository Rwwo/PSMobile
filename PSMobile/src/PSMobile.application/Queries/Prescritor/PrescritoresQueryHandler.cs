using AutoMapper;

using MediatR;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.core.Services;

using System.Linq.Expressions;

namespace PSMobile.application.Queries.Prescritor;
public class PrescritoresQueryHandler
         : BaseService,
        IRequestHandler<GetAllPrescritoresQuery, PaginatedResult<core.Entities.Prescritores>>,
        IRequestHandler<GetAllPrescritoresForNameQuery, PaginatedResult<core.Entities.Prescritores>>,
        IRequestHandler<GetPrescritorByKeyQuery, PaginatedResult<core.Entities.Prescritores>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public PrescritoresQueryHandler(IUnitOfWork uow, IMapper map, INotificador notificador) : base(notificador)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<PaginatedResult<core.Entities.Prescritores>> Handle(GetAllPrescritoresQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Prescritores, bool>> filtro = c => c.pre_exc == 0;

        return await _uow.PrescritoresRepository.GetAllAsync(filtro,
                                                        null,
                                                        null,
                                                        null,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize
                                                        );

    }

    public async Task<PaginatedResult<Prescritores>> Handle(GetAllPrescritoresForNameQuery request, CancellationToken cancellationToken)
    {

        if (string.IsNullOrEmpty(request.Nome))
        {
            Notificar("Você precisa informar um nome para realizar a consulta");
        }

        Expression<Func<core.Entities.Prescritores, bool>> filtro = c => c.pre_exc == 0
                                                                      && c.pre_nome.ToLower().Contains(request.Nome.ToLower());

        return await _uow.PrescritoresRepository.GetAllAsync(filtro,
                                                        null,
                                                        null,
                                                        null,
                                                        false,
                                                        request.PageNumber,
                                                        request.PageSize
                                                        );

    }

    public async Task<PaginatedResult<Prescritores>> Handle(GetPrescritorByKeyQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Prescritores, bool>> filtro = c => c.pre_exc == 0 && c.pre_key == request.PreKey;

        return await _uow.PrescritoresRepository.GetAllAsync(filtro,
                                                null,
                                                null,
                                                null,
                                                false,
                                                request.PageNumber,
                                                request.PageSize
                                                );
    }
}