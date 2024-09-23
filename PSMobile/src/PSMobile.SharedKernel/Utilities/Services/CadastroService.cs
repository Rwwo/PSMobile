using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Common.Dtos;
using PSMobile.SharedKernel.Responses;
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
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Cadastros>>($"api/Cadastros/all{query}");
    }

    public async Task<PaginatedResult<Cadastros>> GetByCustomColumnAsync(string custom, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"custom?Custom={custom}&PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Cadastros>>($"api/Cadastros/{query}");
    }
    public async Task<Cadastros> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Cadastros>($"api/Cadastros/{id}");
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


}



