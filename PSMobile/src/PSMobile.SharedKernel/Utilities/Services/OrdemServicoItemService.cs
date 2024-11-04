using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Extensions;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class OrdemServicoItemService : IOrdemServicoItemService
{
    private readonly HttpClient _httpClient;
    public OrdemServicoItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task DeleteAsync(OrdensServicosItens entity)
    {
        await _httpClient.DeleteAsync($"api/v1/ordens-servicos/deletar-item-os/{entity.ordserite_key}");
    }

    public async Task<PaginatedResult<OrdensServicosItens>> GetAllByNumOrdemAsync(int empKey, int numOrdem, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<OrdensServicosItens>>($"api/v1/ordens-servicos/all/{empKey}/{numOrdem}/items{query}");

    }

    public async Task<Result<OrdensServicosItensGravarRetornoFuncao>> GravarAsync(OrdensServicosItensInputModel entity)
    {

        var response = await _httpClient.PostAsJsonAsync("api/v1/ordens-servicos/gravar-item-os", entity);
        if (response.IsSuccessStatusCode)
        {
            var inputResult = await response.Content.ReadFromJsonAsync<OrdensServicosItensGravarRetornoFuncao>();
            return Result<OrdensServicosItensGravarRetornoFuncao>.Success(inputResult);
        }

        var errors = await response.TratarErroAsync();
        return Result<OrdensServicosItensGravarRetornoFuncao>.Failure(errors);

    }
}



