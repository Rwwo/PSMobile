using MediatR;

using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.application.Commands.ReceituarioOculos;
public class ReceituarioOculosCommand : IRequest<ReceituarioOculosGravarRetornoFuncao>
{
    public ReceituarioOculosInputModel ReceituarioOculosInputModel { get; private set; }

    public ReceituarioOculosCommand(ReceituarioOculosInputModel input)
    {
        ReceituarioOculosInputModel = input;
    }
}
