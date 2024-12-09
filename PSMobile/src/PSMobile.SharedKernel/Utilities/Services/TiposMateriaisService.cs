using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class TiposMateriaisService : ITiposMateriaisService
{
    private readonly HttpClient _httpClient;
    public TiposMateriaisService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<PaginatedResult<TiposMateriais>> GetAllAsync(int pageSize = 1, int pageNumber = 100)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<TiposMateriais>>($"api/v1/tipos-materiais/all/{query}");
    }

    public async Task<PaginatedResult<TiposMateriais>> GetByIdAsync(int id, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<TiposMateriais>>($"api/v1/tipos-materiais/{id}{query}");

    }
}
