using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

using PSMobile.core.Entities;
using PSMobile.SharedKernel.Common.Dtos;
using PSMobile.SharedKernel.Responses;
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

    public async Task<Result<Cadastros>> GravarAsync(CadastroInputModel cadastro)
    {
        cadastro.CliDataCad = DateTime.Now;

        var response = await _httpClient.PostAsJsonAsync("api/Cadastros", cadastro);
        if (response.IsSuccessStatusCode)
        {
            var cadastroResult = await response.Content.ReadFromJsonAsync<Cadastros>();
            return Result<Cadastros>.Success(cadastroResult);
        }

        var errors = await response.TratarErroAsync();
        return Result<Cadastros>.Failure(errors);
    }

    public async Task<Result<bool>> DeleteAsync(int cadKey)
    {
        var response = await _httpClient.DeleteAsync($"api/Cadastros/{cadKey}");

        if (response.IsSuccessStatusCode)
            return Result<bool>.Success(true);

        var errors = await response.TratarErroAsync();
        return Result<bool>.Failure(errors);
    }
}



