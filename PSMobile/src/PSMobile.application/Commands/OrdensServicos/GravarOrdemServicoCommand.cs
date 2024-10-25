using MediatR;

using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.OrdensServicos;

public class GravarOrdemServicoCommand : IRequest<OrdensServicoGravarRetornoFuncao>
{
    public OrdensServicosInputModel OrdensServicosInputModel { get; private set; }

    public GravarOrdemServicoCommand(OrdensServicosInputModel input)
    {
        OrdensServicosInputModel = input;
    }
}
