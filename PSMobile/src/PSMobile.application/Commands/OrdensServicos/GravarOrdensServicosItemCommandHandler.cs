using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.OrdensServicos;

public class GravarOrdensServicosItemCommandHandler :
      IRequestHandler<GravarOrdensServicosItemCommand, OrdensServicosItensGravarRetornoFuncao>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public GravarOrdensServicosItemCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<OrdensServicosItensGravarRetornoFuncao> Handle(GravarOrdensServicosItemCommand request, CancellationToken cancellationToken)
    {
        return await _uow.OrdensServicosItensRepository.GravarAsync(request.OrdensServicosItensInputModel);
    }
}