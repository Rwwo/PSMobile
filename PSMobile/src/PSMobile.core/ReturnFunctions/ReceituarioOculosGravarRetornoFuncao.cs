using System.Text.Json.Serialization;

namespace PSMobile.core.ReturnFunctions;

public class ReceituarioOculosGravarRetornoFuncao
{
    public ReceituarioOculosGravarRetornoFuncao(int recocu_key)
    {
        Recocu_Key = recocu_key;
    }

    [JsonConstructor]
    public ReceituarioOculosGravarRetornoFuncao()
    {
    }

    public int Recocu_Key { get; set; }
}
