using MediatR;

using PSMobile.SharedKernel.Common.Dtos;

namespace PSMobile.application.Commands.Cadastros;

public class GravarCadastroCommand : IRequest<core.Entities.Cadastros>
{
    public CadastroInputModel Cliente { get; private set; }

    public GravarCadastroCommand(CadastroInputModel cliente)
    {
        Cliente = cliente;
    }

}
