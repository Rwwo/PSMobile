
using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Common.Dtos.Extensions;

namespace PSMobile.application.Commands.Cadastros;

public class CadastroCommandHandler :
      IRequestHandler<GravarCadastroCommand, ClienteGravarRetornoFuncao>,
      IRequestHandler<GravarClienteOticaCommand, ClienteOticaGravarRetornoFuncao>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public CadastroCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<ClienteGravarRetornoFuncao> Handle(GravarCadastroCommand request, CancellationToken cancellationToken)
    {
        var cliente = request.Cliente.ToModel();

        return await _uow.CadastroRepository.GravarAsync(cliente);
    }

    public async Task<ClienteOticaGravarRetornoFuncao> Handle(GravarClienteOticaCommand request, CancellationToken cancellationToken)
    {
        return await _uow.ClienteOticaRepository.GravarAsync(request.Cliente);
    }
}