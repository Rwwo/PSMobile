
using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Common.Dtos.Extensions;

namespace PSMobile.application.Commands.Cadastros;

public class CadastroCommandHandler :
      IRequestHandler<GravarCadastroCommand, core.Entities.Cadastros>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public CadastroCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }


    public async Task<core.Entities.Cadastros> Handle(GravarCadastroCommand request, CancellationToken cancellationToken)
    {
        var cliente = request.Cliente.ToCadastros();

        return await _uow.CadastroRepository.GravarAsync(cliente);
    }
}