using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class PrescritoresService : IPrescritoresService
{
    private readonly HttpClient _httpClient;
    public PrescritoresService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<PaginatedResult<Prescritores>> GetAllAsync(int pageSize = 200, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Prescritores>>($"api/v1/prescritores/all/{query}");
    }

    public async Task<PaginatedResult<Prescritores>> GetByCustomColumn(string nome, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Prescritores>>($"api/v1/prescritores/nome/{nome}{query}");
    }

    public async Task<PaginatedResult<Prescritores>> GetByIdAsync(int id, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Prescritores>>($"api/v1/prescritores/{id}{query}");

    }
}

