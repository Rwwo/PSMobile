using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class ProdutosEmpresasService : IProdutosEmpresasService
{
    private readonly HttpClient _httpClient;
    public ProdutosEmpresasService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<PaginatedResult<ProdutosEmpresas>> GetAllAsync(int empKey, int pageSize = 1, int pageNumber = 10000)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<ProdutosEmpresas>>($"api/ProdutosEmpresas/all/{empKey}{query}");
    }

    public async Task<PaginatedResult<ProdutosEmpresas>> GetAllAsync(int empKey, string custom, int pageSize = 1, int pageNumber = 10000)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<ProdutosEmpresas>>($"api/ProdutosEmpresas/all/{empKey}/custom/{custom}{query}");
    }


}



