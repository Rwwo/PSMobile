using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IReceituarioOticoService :
    IBaseReadServiceWithEmpKey<ReceituarioOculos>, IBaseReadServiceId<ReceituarioOculos>,
    IBaseWriteService<ReceituarioOculosGravarRetornoFuncao, ReceituarioOculosInputModel>;

