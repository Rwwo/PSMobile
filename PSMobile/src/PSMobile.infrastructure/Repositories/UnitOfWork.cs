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
     
    private ClienteOticaRepository? _clienteOticaRepository;
    public IClienteOticaRepository ClienteOticaRepository
    {
        get => _clienteOticaRepository ??= new ClienteOticaRepository(_context);
    }


    public CidadesRepository? _cidadesRepository;
    public ICidadesRepository CidadesRepository
    {
        get => _cidadesRepository ??= new CidadesRepository(_context);
    }


    private FormasPagamentosRepository? _FormasPagamentosRepository;
    public IFormasPagamentosRepository FormasPagamentosRepository
    {
        get => _FormasPagamentosRepository ??= new FormasPagamentosRepository(_context);
    }


    private FuncionariosRepository? _FuncionariosRepository;
    public IFuncionariosRepository FuncionariosRepository
    {
        get => _FuncionariosRepository ??= new FuncionariosRepository(_context);
    }


    private GeraisRepository? _GeraisRepository;
    public IGeraisRepository GeraisRepository
    {
        get => _GeraisRepository ??= new GeraisRepository(_context);
    }


    public OrdensServicosRepository? _OrdensServicosRepository;
    public IOrdensServicosRepository OrdensServicosRepository
    {
        get => _OrdensServicosRepository ??= new OrdensServicosRepository(_context);
    }


    public OrdensServicosItensRepository? _OrdensServicosItensRepository;
    public IOrdensServicosItensRepository OrdensServicosItensRepository
    {
        get => _OrdensServicosItensRepository ??= new OrdensServicosItensRepository(_context);
    }


    public PdvsRepository? _PdvsRepository;
    public IPdvsRepository PdvsRepository
    {
        get => _PdvsRepository ??= new PdvsRepository(_context);
    }


    public PedidosFormasPagamentoRepository? _PedidosFormasPagamentoRepository;
    public IPedidosFormasPagamentoRepository PedidosFormasPagamentoRepository
    {
        get => _PedidosFormasPagamentoRepository ??= new PedidosFormasPagamentoRepository(_context);
    }


    public PedidosFormasPagamentoParcelasRepository? _PedidosFormaPagamentoParcelasRepository;
    public IPedidosFormasPagamentoParcelasRepository PedidosFormasPagamentoParcelasRepository
    {
        get => _PedidosFormaPagamentoParcelasRepository ??= new PedidosFormasPagamentoParcelasRepository(_context);
    }


    public PedidosRepository? _PedidosRepository;
    public IPedidosRepository PedidosRepository
    {
        get => _PedidosRepository ??= new PedidosRepository(_context);
    }


    public PedidosItemRepository? _PedidosItemRepository;
    public IPedidosItemRepository PedidosItemRepository
    {
        get => _PedidosItemRepository ??= new PedidosItemRepository(_context);
    }


    private PrescritoresRepository? _PrescritoresRepository;
    public IPrescritoresRepository PrescritoresRepository
    {
        get => _PrescritoresRepository ??= new PrescritoresRepository(_context);
    }



    private ProdutosEmpresasRepository? _ProdutosEmpresasRepository;
    public IProdutosEmpresasRepository ProdutosEmpresasRepository
    {
        get => _ProdutosEmpresasRepository ??= new ProdutosEmpresasRepository(_context);
    }


    private ReceituarioOculosRepository? _ReceituarioOculosRepository;
    public IReceituarioOculosRepository ReceituarioOculosRepository
    {
        get => _ReceituarioOculosRepository ??= new ReceituarioOculosRepository(_context);
    }


    private UsuariosRepository? _UsuariosRepository;
    public IUsuariosRepository UsuariosRepository
    {
        get => _UsuariosRepository ??= new UsuariosRepository(_context);
    }


    private TiposMateriaisRepository? _TiposMateriaisRepository;
    public ITiposMateriaisRepository TiposMateriaisRepository
    {
        get => _TiposMateriaisRepository ??= new TiposMateriaisRepository(_context);
    }


    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
