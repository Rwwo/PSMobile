using System.Net.Http.Json;
using System.Reflection;

using MudBlazor;

using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Extensions;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class CadastroService : ICadastroService
{
    private readonly HttpClient _httpClient;
    public CadastroService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PaginatedResult<Cadastros>> GetAllAsync(int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Cadastros>>($"api/v1/cadastros/all{query}");
    }
    public async Task<PaginatedResult<Cadastros>> GetByIdAsync(int id, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Cadastros>>($"api/v1/cadastros/{id}{query}");
    }

    public async Task<PaginatedResult<Cadastros>> GetByCustomColumnAsync(string custom, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Cadastros>>($"api/v1/cadastros/custom/{custom}{query}");
    }

    public async Task<PaginatedResult<Cadastros>> GetByDocNumberAsync(string NumDoc, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Cadastros>>($"api/v1/cadastros/numdoc/{NumDoc}{query}");
    }


    public async Task<Result<Cadastros>> GravarAsync(CadastroInputModel cadastro)
    {
        cadastro.CliDataCad = DateTime.Now;

        var response = await _httpClient.PostAsJsonAsync("api/v1/cadastros", cadastro);
        if (response.IsSuccessStatusCode)
        {
            var cadastroResult = await response.Content.ReadFromJsonAsync<Cadastros>();
            return Result<Cadastros>.Success(cadastroResult);
        }

        var errors = await response.TratarErroAsync();
        return Result<Cadastros>.Failure(errors);
    }


}



