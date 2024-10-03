using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.SharedKernel.Responses;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class PedidoFormaPagamentoService : IPedidoFormaPagamentoService
{
    private readonly HttpClient _httpClient;
    public PedidoFormaPagamentoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task DeleteAsync(Pedidos entity)
    {
        await _httpClient.DeleteAsync($"api/v1/pedidos/deletar-formapagamento-pedido/pedkey/{entity.ped_key}");
    }  
    public async Task DeleteAsync(PedidosFormasPagamento entity)
    {
        await _httpClient.DeleteAsync($"api/v1/pedidos/deletar-formapagamento-pedido/pedforpag/{entity.pedforpag_key}");
    }

    public async Task<Result<PedidosFormasPagamento>> GravarAsync(List<PedidoFormasPagamentoInputModel> entity)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/pedidos/gravar-pedido-formapagamento", entity);
        if (response.IsSuccessStatusCode)
        {
            var inputResult = await response.Content.ReadFromJsonAsync<PedidosFormasPagamento>();
            return Result<PedidosFormasPagamento>.Success(inputResult);
        }

        var errors = await response.TratarErroAsync();
        return Result<PedidosFormasPagamento>.Failure(errors);
    }
}