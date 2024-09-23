using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class CidadesService : ICidadesService
{
    private readonly HttpClient _httpClient;
    public CidadesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<PaginatedResult<Cidades>> GetAllAsync(int pageSize = 1, int pageNumber = 10000)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Cidades>>($"api/Cidades/all{query}");
    }

    public async Task<Cidades> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Cidades>($"api/Cidades/{id}");
    }
}



