using System.Text.Json.Serialization;

namespace PSMobile.core.ReturnFunctions;

public class PedidosAtualizarRetornoFuncao
{
    public PedidosAtualizarRetornoFuncao(bool input)
    {
        IsSucess = input;
    }
    public bool IsSucess { get; private set; }

    
    [JsonConstructor]
    public PedidosAtualizarRetornoFuncao()
    {
    }
}