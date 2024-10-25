using System.Text.Json.Serialization;

namespace PSMobile.core.ReturnFunctions;

public class OrdensServicosItensGravarRetornoFuncao
{
    public OrdensServicosItensGravarRetornoFuncao(int valor)
    {
        _pedite_key = valor;
    }
    [JsonConstructor]
    public OrdensServicosItensGravarRetornoFuncao() { }

    public int _pedite_key { get; set; }
}
