using PSMobile.core.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IUowAPI
{
    ICidadesService CidadesService { get; }
    IGeraisService GeraisService { get; }
    IFuncionariosService FuncionariosService { get; }
    ICadastroService CadastroService { get; }
    IPedidoService PedidoService { get; }
    IProdutosEmpresasService ProdutosEmpresasService { get; }
}

