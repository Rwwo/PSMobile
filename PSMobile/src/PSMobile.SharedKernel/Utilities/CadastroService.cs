using System.Net.Http.Json;

using PSMobile.core.Entities;

namespace PSMobile.SharedKernel.Utilities;

public class CadastroService : ICadastroService
{
    private readonly HttpClient _httpClient;

    public CadastroService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Cadastros>> GetAllAsync()
    {
        var ret = await _httpClient.GetFromJsonAsync<List<Cadastros>>("api/Cadastros");
        return ret;
    }

    public async Task<List<Cadastros>> GetByCustomColumnAsync(string custom)
    {
        return await _httpClient.GetFromJsonAsync<List<Cadastros>>($"api/Cadastros/{custom}");
    }

    public async Task<Cadastros> CreateAsync(Cadastros cadastro)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Cadastros", cadastro);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Cadastros>();
    }

    public async Task<Cadastros> UpdateAsync(int cadKey, Cadastros cadastro)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Cadastros/{cadKey}", cadastro);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Cadastros>();
    }

    public async Task<bool> DeleteAsync(int cadKey)
    {
        var response = await _httpClient.DeleteAsync($"api/Cadastros/{cadKey}");
        return response.IsSuccessStatusCode;
    }
}


