namespace PSMobile.core.Interfaces;

public interface IUnitOfWork
{
    ICadastroRepository CadastroRepository { get; }
    ICidadesRepository CidadesRepository { get; }
    IFuncionariosRepository FuncionariosRepository { get; }
    IGeraisRepository GeraisRepository { get; }
    IPdvsRepository PdvsRepository { get; }
    IPedidosRepository PedidosRepository { get; }
    IPedidosItemRepository PedidosItemRepository { get; }
    IProdutosEmpresasRepository ProdutosEmpresasRepository { get; }
    Task CommitAsync();
}
