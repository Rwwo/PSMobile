using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.core.Interfaces;

public interface IReceituarioOculosRepository
    :IWriteRepository<ReceituarioOculosInputModel, ReceituarioOculosGravarRetornoFuncao>,
     IReadRepository<ReceituarioOculos>
{

}