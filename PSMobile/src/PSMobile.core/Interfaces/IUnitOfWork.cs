namespace PSMobile.core.Interfaces;

public interface IUnitOfWork
{
    ICadastroRepository ICadastroRepository { get; }
    Task CommitAsync();
}
