
using AutoMapper;

using MediatR;

using PSMobile.core.Extensions;
using PSMobile.core.Interfaces;

namespace PSMobile.application.Commands.Cadastros;

public class CadastroCommandHandler
    : IRequestHandler<CreateCadastroCommand, PSMobile.core.Entities.Cadastros>
    , IRequestHandler<UpdateCadastroCommand, Unit>
    , IRequestHandler<DeleteCadastroCommand, Unit>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public CadastroCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<core.Entities.Cadastros> Handle(CreateCadastroCommand request, CancellationToken cancellationToken)
    {
        await _uow.ICadastroRepository.AddAsync(request.Cadastro);
        await _uow.CommitAsync();

        return request.Cadastro;
    }
    public async Task<Unit> Handle(UpdateCadastroCommand request, CancellationToken cancellationToken)
    {
        var db = await _uow.ICadastroRepository.GetByCadKeyAsync(request.Cad_Key);
        db.UpdateCadastro(request.Cadastro);

        await _uow.ICadastroRepository.UpdateAsync(db);
        await _uow.CommitAsync();

        return Unit.Value;
    }
    public async Task<Unit> Handle(DeleteCadastroCommand request, CancellationToken cancellationToken)
    {
        var db = await _uow.ICadastroRepository.GetByCadKeyAsync(request.Cad_Key);
        await _uow.ICadastroRepository.DeleteAsync(db);

        return Unit.Value;
    }
}