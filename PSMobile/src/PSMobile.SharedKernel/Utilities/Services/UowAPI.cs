using PSMobile.SharedKernel.Utilities.Interfaces;

using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using PSMobile.core.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class UowAPI : IUowAPI
{
    protected readonly HttpClient _HttpClient;
    public UowAPI(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }
    public void SetarToken(string token)
    {
        _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    private CadastroService? _CadastroService;
    public ICadastroService CadastroService
    {
        get => _CadastroService ??= new CadastroService(_HttpClient);
    }


    private CidadesService? _CidadesService;
    public ICidadesService CidadesService
    {
        get => _CidadesService ??= new CidadesService(_HttpClient);
    }

    private FormasPagamentosService? _FormasPagamentosService;
    public IFormasPagamentosService FormasPagamentosService
    {
        get => _FormasPagamentosService ??= new FormasPagamentosService(_HttpClient);
    }

    private FuncionariosService? _FuncionariosService;
    public IFuncionariosService FuncionariosService
    {
        get => _FuncionariosService ??= new FuncionariosService(_HttpClient);
    }

    private GeraisService? _GeraisService;
    public IGeraisService GeraisService
    {
        get => _GeraisService ??= new GeraisService(_HttpClient);
    }


    private IOrdemServicoService? _OrdemServicoService;
    public IOrdemServicoService OrdemServicoService
    {
        get => _OrdemServicoService ??= new OrdemServicoService(_HttpClient);
    }


    private IOrdemServicoItemService? _OrdemServicoItemService;
    public IOrdemServicoItemService OrdemServicoItemService
    {
        get => _OrdemServicoItemService ??= new OrdemServicoItemService(_HttpClient);
    }

    private PdvService? _PdvService;
    public IPdvService PdvService
    {
        get => _PdvService ??= new PdvService(_HttpClient);
    }

    private PedidoItemService? _PedidoItemService;
    public IPedidoItemService PedidoItemService
    {
        get => _PedidoItemService ??= new PedidoItemService(_HttpClient);
    }

    private PedidoFormaPagamentoService? _PedidoFormaPagamentoService;
    public IPedidoFormaPagamentoService PedidoFormaPagamentoService
    {
        get => _PedidoFormaPagamentoService ??= new PedidoFormaPagamentoService(_HttpClient);
    }

    private PedidoService? _PedidoService;
    public IPedidoService PedidoService
    {
        get => _PedidoService ??= new PedidoService(_HttpClient);
    }

    private PrescritoresService? _PrescritoresService;
    public IPrescritoresService PrescritoresService
    {
        get => _PrescritoresService ??= new PrescritoresService(_HttpClient);
    }

    private ProdutosEmpresasService? _ProdutosEmpresasService;
    public IProdutosEmpresasService ProdutosEmpresasService
    {
        get => _ProdutosEmpresasService ??= new ProdutosEmpresasService(_HttpClient);
    }

    private ReceituarioOticoService? _ReceituarioOticoService;
    public IReceituarioOticoService ReceituarioOticoService
    {
        get => _ReceituarioOticoService ??= new ReceituarioOticoService(_HttpClient);
    }

    private TiposMateriaisService? _TiposMateriaisService;
    public ITiposMateriaisService TiposMateriaisService
    {
        get => _TiposMateriaisService ??= new TiposMateriaisService(_HttpClient);
    }


    private UsuariosService? _UsuariosService;
    public IUsuariosService UsuariosService
    {
        get => _UsuariosService ??= new UsuariosService(_HttpClient);
    }

}

