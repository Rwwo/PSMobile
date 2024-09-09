using PSMobile.infrastructure.Context;

using PSMobile.core.Interfaces;

namespace PSMobile.infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    public MyDbContext _context;

    public UnitOfWork(MyDbContext contexto)
    {
        _context = contexto;
    }

    private CadastroRepository? CadastroRepository { get; set; } = null!;
    public ICadastroRepository ICadastroRepository
    {
        get => CadastroRepository ?? (CadastroRepository = new CadastroRepository(_context));
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
