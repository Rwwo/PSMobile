namespace PSMobile.core.Interfaces;

public interface IUnitOfWork
{
    ICadastroRepository CadastroRepository { get; }
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
    IOrdensServicosRepository OrdensServicosRepository { get; }
    IOrdensServicosItensRepository OrdensServicosItensRepository { get; }
    IUsuariosRepository UsuariosRepository { get; }
    Task CommitAsync();
}
