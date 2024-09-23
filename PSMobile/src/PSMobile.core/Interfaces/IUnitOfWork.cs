namespace PSMobile.core.Interfaces;

public interface IUnitOfWork
{
    ICadastroRepository CadastroRepository { get; }
    ICidadesRepository CidadesRepository { get; }
    IFuncionariosRepository FuncionariosRepository { get; }

    IPedidosRepository PedidosRepository { get; }
    Task CommitAsync();
}
