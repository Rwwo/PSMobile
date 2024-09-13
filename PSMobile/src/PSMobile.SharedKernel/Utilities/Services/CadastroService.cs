using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.SharedKernel.Common.Dtos;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class CadastroService : ICadastroService
{
    private readonly HttpClient _httpClient;

    public CadastroService(HttpClient httpClient)
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

        _httpClient = new HttpClient(handler);
        _httpClient.BaseAddress = httpClient.BaseAddress;
    }

    public async Task<List<Cadastros>> GetAllAsync()
    {
        var dados = await _httpClient.GetFromJsonAsync<List<Cadastros>>("api/Cadastros");
        return dados;
    }

    public async Task<List<Cadastros>> GetByCustomColumnAsync(string custom)
    {
        return await _httpClient.GetFromJsonAsync<List<Cadastros>>($"api/Cadastros/{custom}");
    }

    public async Task<Cadastros> GravarAsync(ClienteInputModel cadastro)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Cadastros", cadastro);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Cadastros>();
    }



    public async Task<bool> DeleteAsync(int cadKey)
    {
        var response = await _httpClient.DeleteAsync($"api/Cadastros/{cadKey}");
        return response.IsSuccessStatusCode;
    }
}


