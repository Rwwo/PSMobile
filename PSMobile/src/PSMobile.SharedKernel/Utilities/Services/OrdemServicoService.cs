using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Extensions;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class OrdemServicoService : IOrdemServicoService
{
    private readonly HttpClient _httpClient;
    public OrdemServicoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PaginatedResult<OrdensServicos>> GetAllAsync(int empKey, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<OrdensServicos>>($"api/v1/ordens-servicos/all/{empKey}{query}");
    }
    public async Task<PaginatedResult<OrdensServicos>> GetByOrdSerKeyAsync(int empKey, int ordSerKey, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<OrdensServicos>>($"api/v1/ordens-servicos/all/{empKey}/ordserkey/{ordSerKey}{query}");

    }
    public async Task<PaginatedResult<OrdensServicos>> GetByCustomColumnAsync(int empKey, string custom, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<OrdensServicos>>($"api/v1/ordens-servicos/all/{empKey}/custom/{custom}{query}");
    }


    public async Task<Result<OrdensServicoGravarRetornoFuncao>> GravarAsync(OrdensServicosInputModel entity)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/ordens-servicos/gravar-os", entity);
        if (response.IsSuccessStatusCode)
        {
            var inputResult = await response.Content.ReadFromJsonAsync<OrdensServicoGravarRetornoFuncao>();
            return Result<OrdensServicoGravarRetornoFuncao>.Success(inputResult);
        }

        var errors = await response.TratarErroAsync();
        return Result<OrdensServicoGravarRetornoFuncao>.Failure(errors);
    }
}



