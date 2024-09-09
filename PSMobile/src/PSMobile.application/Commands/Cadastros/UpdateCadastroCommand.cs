using MediatR;

namespace PSMobile.application.Commands.Cadastros;

public class UpdateCadastroCommand : IRequest<Unit>
{
    public UpdateCadastroCommand(int cad_key, core.Entities.Cadastros cadastro)
    {
        Cad_Key = cad_key;
        Cadastro = cadastro;
    }

    public int Cad_Key { get; private set; }
    public core.Entities.Cadastros Cadastro { get; private set; }
}
