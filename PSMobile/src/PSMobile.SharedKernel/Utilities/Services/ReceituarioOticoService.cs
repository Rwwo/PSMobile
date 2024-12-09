using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class ReceituarioOticoService : IReceituarioOticoService
{
    private readonly HttpClient _httpClient;
    public ReceituarioOticoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<PaginatedResult<ReceituarioOculos>> GetAllAsync(int empKey, int pageSize = 1, int pageNumber = 100)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<ReceituarioOculos>>($"api/v1/receituario-oculos/all/{empKey}{query}");
    }

    public async Task<PaginatedResult<ReceituarioOculos>> GetByIdAsync(int id, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<ReceituarioOculos>>($"api/v1/receituario-oculos/os/{id}{query}");

    }
}

