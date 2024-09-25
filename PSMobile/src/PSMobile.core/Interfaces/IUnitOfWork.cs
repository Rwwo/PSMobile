namespace PSMobile.core.Interfaces;

public interface IUnitOfWork
{
    ICadastroRepository CadastroRepository { get; }
    ICidadesRepository CidadesRepository { get; }
    IFuncionariosRepository FuncionariosRepository { get; }
    IGeraisRepository GeraisRepository { get; }
    IPedidosRepository PedidosRepository { get; }
    IProdutosEmpresasRepository ProdutosEmpresasRepository { get; }
    Task CommitAsync();
}
