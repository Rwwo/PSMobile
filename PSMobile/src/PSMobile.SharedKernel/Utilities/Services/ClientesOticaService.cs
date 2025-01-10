using System.Net.Http.Json;

using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Extensions;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class ClientesOticaService : IClientesOticaService
{
    private readonly HttpClient _httpClient;
    public ClientesOticaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<Result<ClienteOticaGravarRetornoFuncao>> GravarAsync(ClienteOticaInputModel cadastro)
    {
        cadastro.clioti_data_mud = DateTime.Now;

        var response = await _httpClient.PostAsJsonAsync("api/v1/cadastros/gravar-cliente-otica", cadastro);
        if (response.IsSuccessStatusCode)
        {
            var cadastroResult = await response.Content.ReadFromJsonAsync<ClienteOticaGravarRetornoFuncao>();
            return Result<ClienteOticaGravarRetornoFuncao>.Success(cadastroResult);
        }

        var errors = await response.TratarErroAsync();
        return Result<ClienteOticaGravarRetornoFuncao>.Failure(errors);
    }


}