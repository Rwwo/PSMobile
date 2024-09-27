using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class FuncionariosService : IFuncionariosService
{
    private readonly HttpClient _httpClient;

    public FuncionariosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<PaginatedResult<Funcionarios>> GetAllAsync(int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Funcionarios>>($"api/Funcionarios/all{query}");
    }

    public async Task<PaginatedResult<Funcionarios>> FuncionariosByName(string name, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Funcionarios>>($"api/Funcionarios/search-by-name/{name}{query}");
    }


    public async Task<PaginatedResult<Funcionarios>> GetByIdAsync(int id, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Funcionarios>>($"api/Funcionarios/{id}{query}");
    }
}



