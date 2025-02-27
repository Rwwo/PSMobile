﻿using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Extensions;
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
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Pedidos>>($"api/v1/pedidos/all/{empKey}{query}");
    }

    public async Task<PaginatedResult<Pedidos>> GetByCustomColumnAsync(int empKey, string custom, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Pedidos>>($"api/v1/pedidos/all/{empKey}/custom/{custom}{query}");
    }

    public async Task<PaginatedResult<Pedidos>> GetByPedKeyAsync(int empKey, int pedKey, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Pedidos>>($"api/v1/pedidos/all/{empKey}/pedkey/{pedKey}{query}");
    }


    public async Task<Result<PedidosGravarRetornoFuncao>> GravarAsync(PedidoInputModel entity)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/pedidos/gravar-pedido", entity);
        if (response.IsSuccessStatusCode)
        {
            var inputResult = await response.Content.ReadFromJsonAsync<PedidosGravarRetornoFuncao>();
            return Result<PedidosGravarRetornoFuncao>.Success(inputResult);
        }

        var errors = await response.TratarErroAsync();
        return Result<PedidosGravarRetornoFuncao>.Failure(errors);
    }

    public async Task<Result<PedidosAtualizarRetornoFuncao>> AtualizarAsync(PedidoAtualizarInputModel entity)
    {

        var response = await _httpClient.PostAsJsonAsync("api/v1/pedidos/atualizar-pedido", entity);
        if (response.IsSuccessStatusCode)
        {
            var inputResult = await response.Content.ReadFromJsonAsync<PedidosAtualizarRetornoFuncao>();
            return Result<PedidosAtualizarRetornoFuncao>.Success(inputResult);
        }

        var errors = await response.TratarErroAsync();
        return Result<PedidosAtualizarRetornoFuncao>.Failure(errors);
    }
}
