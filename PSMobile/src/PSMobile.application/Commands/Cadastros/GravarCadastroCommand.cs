using MediatR;

using PSMobile.SharedKernel.Common.Dtos;

namespace PSMobile.application.Commands.Cadastros;

public class GravarCadastroCommand : IRequest<core.Entities.Cadastros>
{
    public ClienteInputModel Cliente { get; private set; }

    public GravarCadastroCommand(ClienteInputModel cliente)
    {
        Cliente = cliente;
    }

}
