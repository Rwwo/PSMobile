using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Common.Dtos;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;
public class PedidoService : IPedidoService
{
    private readonly HttpClient _httpClient;
    public PedidoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PaginatedResult<Pedidos>> GetAllAsync(int empKey = 1, int pageSize = 10, int pageNumber = 1)
    {

        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Pedidos>>($"api/Pedidos/all/{empKey}{query}");
    }

    public async Task<PaginatedResult<Pedidos>> GetByCustomColumnAsync(int empKey, string custom, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Pedidos>>($"api/Pedidos/all/{empKey}/custom/{custom}{query}");
    }

    public async Task<Result<Pedidos>> GravarAsync(PedidoInputModel entity)
    {
        throw new NotImplementedException();
    }
}
