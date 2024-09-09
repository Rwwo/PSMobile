using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Cadastros;

public class CadastrosQueryHandler
    : IRequestHandler<GetAllCadastrosQuery, List<core.Entities.Cadastros>>
    , IRequestHandler<GetAllCustomColumnCadastrosQuery, List<core.Entities.Cadastros>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public CadastrosQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<List<core.Entities.Cadastros>> Handle(GetAllCadastrosQuery request, CancellationToken cancellationToken)
        => await _uow.ICadastroRepository.GetAllAsync();



    public async Task<List<core.Entities.Cadastros>> Handle(GetAllCustomColumnCadastrosQuery request, CancellationToken cancellationToken)
        => await _uow.ICadastroRepository.GetAllCustomColumn(request.Custom);

}
