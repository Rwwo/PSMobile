namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IUowAPI
{
    void SetarToken(string token);
    ICadastroService CadastroService { get; }
    ICidadesService CidadesService { get; }
    IFormasPagamentosService FormasPagamentosService { get; }
    IFuncionariosService FuncionariosService { get; }
    IGeraisService GeraisService { get; }
    IPedidoService PedidoService { get; }
    IOrdemServicoService OrdemServicoService { get; }
    IOrdemServicoItemService OrdemServicoItemService { get; }
    IPedidoFormaPagamentoService PedidoFormaPagamentoService { get; }
    IPdvService PdvService { get; }
    IPedidoItemService PedidoItemService { get; }
    IPrescritoresService PrescritoresService { get; }
    IProdutosEmpresasService ProdutosEmpresasService { get; }
    IReceituarioOticoService ReceituarioOticoService { get; }
    ITiposMateriaisService TiposMateriaisService { get; }
    IUsuariosService UsuariosService { get; }

}

