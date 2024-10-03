using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class FormasPagamentosService : IFormasPagamentosService
{
    private readonly HttpClient _httpClient;
    public FormasPagamentosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PaginatedResult<FormasPagamento>> GetAllAsync(int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<FormasPagamento>>($"api/v1/formaspagamentos/all{query}");
    }

    public async Task<PaginatedResult<FormasPagamento>> GetByIdAsync(int id, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<FormasPagamento>>($"api/v1/formaspagamentos/{id}{query}");
    }
}