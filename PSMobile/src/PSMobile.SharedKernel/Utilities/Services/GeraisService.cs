﻿using System.Net.Http.Headers;
using System.Net.Http.Json;

using MediatR;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class GeraisService : IGeraisService
{
    private readonly HttpClient _httpClient;
    public GeraisService(HttpClient httpClient)
    {
        _httpClient = httpClient;

    }
    public async Task<PaginatedResult<Gerais>> GetAllAsync(int pageSize = 1, int pageNumber = 10000)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Gerais>>($"api/v1/gerais/all{query}");
    }

    public async Task<PaginatedResult<Gerais>> GetByIdAsync(int id, int pageSize = 10, int pageNumber = 1)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Gerais>>($"api/v1/gerais/{id}{query}");
    }
}



