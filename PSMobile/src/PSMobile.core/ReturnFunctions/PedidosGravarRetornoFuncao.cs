using System.Text.Json.Serialization;

namespace PSMobile.core.ReturnFunctions;

public class PedidosGravarRetornoFuncao
{
    public PedidosGravarRetornoFuncao(string text)
    {
        _ped_numero = Convert.ToInt32(text.Split('|')[0]);
        _ped_key = Convert.ToInt32(text.Split('|')[1]);
    }

    [JsonConstructor]
    public PedidosGravarRetornoFuncao()
    {
    }

    public int _ped_numero { get; set; }
    public int _ped_key { get; set; }
}
