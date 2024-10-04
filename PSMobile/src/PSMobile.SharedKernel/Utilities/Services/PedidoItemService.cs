using System.Net.Http.Json;

using MediatR;

using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Responses;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class PedidoItemService : IPedidoItemService
{
    private readonly HttpClient _httpClient;
    public PedidoItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task DeleteAsync(PedidosItens entity)
    {
        await _httpClient.DeleteAsync($"api/v1/pedidos/deletar-pedido-item/{entity.pedite_key}");
    }

    public async Task<PaginatedResult<PedidosItens>> GetAllByNumPedAsync(int empKey, int numPed, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<PedidosItens>>($"api/v1/pedidos/all/{empKey}/{numPed}/items{query}");
    }
    public async Task<Result<PedidosItemGravarRetornoFuncao>> GravarAsync(PedidoItemInputModel entity)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/pedidos/gravar-pedido-item", entity);
        if (response.IsSuccessStatusCode)
        {
            var inputResult = await response.Content.ReadFromJsonAsync<PedidosItemGravarRetornoFuncao>();
            return Result<PedidosItemGravarRetornoFuncao>.Success(inputResult);
        }

        var errors = await response.TratarErroAsync();
        return Result<PedidosItemGravarRetornoFuncao>.Failure(errors);
    }
}
