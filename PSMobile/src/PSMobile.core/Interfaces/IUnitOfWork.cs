namespace PSMobile.core.Interfaces;

public interface IUnitOfWork
{
    ICadastroRepository CadastroRepository { get; }
    Task CommitAsync();
}
