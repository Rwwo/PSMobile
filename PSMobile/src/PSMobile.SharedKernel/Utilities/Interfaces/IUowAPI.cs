namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IUowAPI
{
    ICadastroService CadastroService { get; }
    ICidadesService CidadesService { get; }
    IFormasPagamentosService FormasPagamentosService { get; }
    IFuncionariosService FuncionariosService { get; }
    IGeraisService GeraisService { get; }
    IPedidoService PedidoService { get; }
    IPedidoFormaPagamentoService PedidoFormaPagamentoService { get; }
    IPdvService PdvService { get; }
    IPedidoItemService PedidoItemService { get; }
    IProdutosEmpresasService ProdutosEmpresasService { get; }
}

