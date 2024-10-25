using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.OrdensServicos;

public class GravarOrdemServicoCommandHandler :
      IRequestHandler<GravarOrdemServicoCommand, OrdensServicoGravarRetornoFuncao>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public GravarOrdemServicoCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<OrdensServicoGravarRetornoFuncao> Handle(GravarOrdemServicoCommand request, CancellationToken cancellationToken)
    {
        return await _uow.OrdensServicosRepository.GravarAsync(request.OrdensServicosInputModel);
    }
}
