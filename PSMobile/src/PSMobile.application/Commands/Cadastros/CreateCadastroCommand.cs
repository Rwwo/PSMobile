using MediatR;

namespace PSMobile.application.Commands.Cadastros;
public class CreateCadastroCommand : IRequest<core.Entities.Cadastros>
{
    public core.Entities.Cadastros Cadastro { get; private set; }
    public CreateCadastroCommand(core.Entities.Cadastros cadastro)
    {
        Cadastro = cadastro;
    }
}
