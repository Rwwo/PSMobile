using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;
using PSMobile.infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IRepository<Cadastros> _repositoryBase;

    // Repositório privado e sua interface pública
    private CadastroRepository? _cadastroRepository;

    public UnitOfWork(AppDbContext contexto, IRepository<Cadastros> repositoryBase)
    {
        _context = contexto ?? throw new ArgumentNullException(nameof(contexto));
        _repositoryBase = repositoryBase ?? throw new ArgumentNullException(nameof(repositoryBase));
    }

    // Expondo o repositório através de uma interface
    public ICadastroRepository CadastroRepository
    {
        get => _cadastroRepository ??= new CadastroRepository(_context, _repositoryBase);
    }

    // Método de commit para salvar alterações no banco de dados
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
