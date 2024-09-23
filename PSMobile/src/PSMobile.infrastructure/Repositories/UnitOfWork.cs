using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IReadRepository<Cadastros> _repositoryBase;

    public UnitOfWork(AppDbContext contexto, IReadRepository<Cadastros> repositoryBase)
    {
        _context = contexto ?? throw new ArgumentNullException(nameof(contexto));
        _repositoryBase = repositoryBase ?? throw new ArgumentNullException(nameof(repositoryBase));
    }


    private CadastroRepository? _cadastroRepository;
    public ICadastroRepository CadastroRepository
    {
        get => _cadastroRepository ??= new CadastroRepository(_context);
    }


    public CidadesRepository? _cidadesRepository;
    public ICidadesRepository CidadesRepository
    {
        get => _cidadesRepository ??= new CidadesRepository(_context);
    }


    private FuncionariosRepository? _FuncionariosRepository;
    public IFuncionariosRepository FuncionariosRepository
    {
        get => _FuncionariosRepository ??= new FuncionariosRepository(_context);
    }

    public PedidosRepository? _PedidosRepository;
    public IPedidosRepository PedidosRepository
    {
        get => _PedidosRepository ??= new PedidosRepository(_context);
    }


    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
