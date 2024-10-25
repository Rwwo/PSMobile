using MediatR;

using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.OrdensServicos;

public class GravarOrdensServicosItemCommand : IRequest<OrdensServicosItensGravarRetornoFuncao>
{
    public OrdensServicosItensInputModel OrdensServicosItensInputModel { get; private set; }

    public GravarOrdensServicosItemCommand(OrdensServicosItensInputModel input)
    {
        OrdensServicosItensInputModel = input;
    }
}
