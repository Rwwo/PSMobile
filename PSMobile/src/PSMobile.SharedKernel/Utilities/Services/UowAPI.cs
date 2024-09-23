using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class UowAPI : IUowAPI
{
    protected readonly HttpClient _HttpClient;
    public UowAPI(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }

    private CidadesService? _CidadesService;
    public ICidadesService CidadesService
    {
        get => _CidadesService ??= new CidadesService(_HttpClient);
    }

    private FuncionariosService? _FuncionariosService;
    public IFuncionariosService FuncionariosService
    {
        get => _FuncionariosService ??= new FuncionariosService(_HttpClient);
    }

    private CadastroService? _CadastroService;
    public ICadastroService CadastroService
    {
        get => _CadastroService ??= new CadastroService(_HttpClient);
    }

}

