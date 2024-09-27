using System.Text.Json.Serialization;

namespace PSMobile.core.ReturnFunctions;

public class ClienteGravarRetornoFuncao

{
    [JsonConstructor]
    public ClienteGravarRetornoFuncao() { }
    public ClienteGravarRetornoFuncao(int valor)
    {
        codigo = valor;

    }
    public int codigo { get; set; }
}