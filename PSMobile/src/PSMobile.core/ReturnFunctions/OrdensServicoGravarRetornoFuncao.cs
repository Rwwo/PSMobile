using System.Text.Json.Serialization;

namespace PSMobile.core.ReturnFunctions;

public class OrdensServicoGravarRetornoFuncao
{
    public OrdensServicoGravarRetornoFuncao(string text)
    {
        _ordser_numero = Convert.ToInt32(text.Split('|')[0]);
        _ordser_key = Convert.ToInt32(text.Split('|')[1]);
    }

    [JsonConstructor]
    public OrdensServicoGravarRetornoFuncao()
    {
    }

    public int _ordser_numero { get; set; }
    public int _ordser_key { get; set; }
}
