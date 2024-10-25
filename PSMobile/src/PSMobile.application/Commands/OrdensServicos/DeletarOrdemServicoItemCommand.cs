using MediatR;


namespace PSMobile.application.Commands.OrdensServicos;

public class DeletarOrdemServicoItemCommand : IRequest<Unit>
{
    public DeletarOrdemServicoItemCommand(int input)
    {
        OrdSerIteKey = input;
    }

    public int OrdSerIteKey { get; private set; }

}
