using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.ReceituarioOculos;

public class GravarReceituarioOculosCommandHandler :
      IRequestHandler<ReceituarioOculosCommand, ReceituarioOculosGravarRetornoFuncao>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public GravarReceituarioOculosCommandHandler(IUnitOfWork uow, IMapper mapper) 
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<ReceituarioOculosGravarRetornoFuncao> Handle(ReceituarioOculosCommand request, CancellationToken cancellationToken)
    {
        return await _uow.ReceituarioOculosRepository.GravarAsync(request.ReceituarioOculosInputModel);
    }
}
