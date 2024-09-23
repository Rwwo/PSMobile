using PSMobile.core.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IUowAPI
{
    ICidadesService CidadesService { get; }
    IFuncionariosService FuncionariosService { get; }
    ICadastroService CadastroService { get; }
}

