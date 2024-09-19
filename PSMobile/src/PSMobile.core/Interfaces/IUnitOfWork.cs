namespace PSMobile.core.Interfaces;

public interface IUnitOfWork
{
    ICadastroRepository CadastroRepository { get; }
    ICidadesRepository CidadesRepository { get; }
    IFuncionariosRepository FuncionariosRepository { get; }
    Task CommitAsync();
}
