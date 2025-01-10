namespace PSMobile.core.Interfaces;

public interface IUnitOfWork
{
    ICadastroRepository CadastroRepository { get; }
    IClienteOticaRepository ClienteOticaRepository { get; }
    ICidadesRepository CidadesRepository { get; }
    IFormasPagamentosRepository FormasPagamentosRepository { get; }
    IFuncionariosRepository FuncionariosRepository { get; }
    IGeraisRepository GeraisRepository { get; }
    IPdvsRepository PdvsRepository { get; }
    IPedidosFormasPagamentoRepository PedidosFormasPagamentoRepository { get; }
    IPedidosFormasPagamentoParcelasRepository PedidosFormasPagamentoParcelasRepository { get; }
    IPedidosItemRepository PedidosItemRepository { get; }
    IProdutosEmpresasRepository ProdutosEmpresasRepository { get; }
    IPedidosRepository PedidosRepository { get; }
    IReceituarioOculosRepository ReceituarioOculosRepository { get; }
    IOrdensServicosRepository OrdensServicosRepository { get; }
    IOrdensServicosItensRepository OrdensServicosItensRepository { get; }
    IPrescritoresRepository PrescritoresRepository { get; }
    IUsuariosRepository UsuariosRepository { get; }
    ITiposMateriaisRepository TiposMateriaisRepository { get; }
    Task CommitAsync();
}
