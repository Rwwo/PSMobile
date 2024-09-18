using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    public ApiService(HttpClient httpClient)
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

        _httpClient = new HttpClient(handler);
        _httpClient.BaseAddress = httpClient.BaseAddress;
    }
    public async Task<List<Cidades>> CidadesGetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Cidades>>("api/Cidades");
    }
}



