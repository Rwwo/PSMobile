using System.Text.Json;

namespace PSMobile.SharedKernel.Extensions;
public static class HttpResponseMessageExtension
{
    public static async Task<List<string>> TratarErroAsync(this HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        var mensagensErro = new List<string>();

        try
        {
            var errorResponse = JsonSerializer.Deserialize<ValidationErrorResponse>(content);
            if (errorResponse?.errors != null && errorResponse.errors.Any())
            {
                foreach (var erro in errorResponse.errors)
                {
                    mensagensErro.AddRange(erro.Value);
                }
            }
        }
        catch
        {
            mensagensErro.Add("Erro desconhecido ao processar a solicitação.");
        }

        return mensagensErro;
    }
}


