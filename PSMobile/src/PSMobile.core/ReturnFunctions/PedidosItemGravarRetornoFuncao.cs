using System.Text.Json.Serialization;

namespace PSMobile.core.ReturnFunctions;

public class PedidosItemGravarRetornoFuncao
{
    public PedidosItemGravarRetornoFuncao(int valor)
    {
        _pedite_key = valor;
    }
    [JsonConstructor]
    public PedidosItemGravarRetornoFuncao() { }

    public int _pedite_key { get; set; }
}
