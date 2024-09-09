using MediatR;

namespace PSMobile.application.Commands.Cadastros;

public class DeleteCadastroCommand : IRequest<Unit>
{
    public DeleteCadastroCommand(int cad_key)
    {
        Cad_Key = cad_key;
    }

    public int Cad_Key { get; private set; }
}
