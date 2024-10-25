using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Commands.OrdensServicos;

public class DeletarOrdemServicoItemCommandHandler :
      IRequestHandler<DeletarOrdemServicoItemCommand, Unit>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public DeletarOrdemServicoItemCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<Unit> Handle(DeletarOrdemServicoItemCommand request, CancellationToken cancellationToken)
    {
        await _uow.OrdensServicosItensRepository.DeleteAsync(request.OrdSerIteKey);
        return Unit.Value;
    }
}
