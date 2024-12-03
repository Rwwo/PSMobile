using System.Net.Http.Json;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.core.ViewModel;
using PSMobile.SharedKernel.Extensions;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class UsuariosService : IUsuariosService
{
    private readonly HttpClient _httpClient;
    public UsuariosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<PaginatedResult<Usuarios>> GetAllAsync(int empKey, int pageSize = 1, int pageNumber = 10000)
    {
        var query = $"?PageNumber={pageNumber}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PaginatedResult<Usuarios>>($"api/v1/usuarios/all/{empKey}{query}");
    }

    public async Task<Result<LoginViewModel>> Login(string usu_nome, string usu_senha)
    {

        if (string.IsNullOrEmpty(usu_nome))
        {
            return Result<LoginViewModel>.Failure(new List<string> { "O nome do usuário é obrigatório" });
        }
        else if (string.IsNullOrEmpty(usu_senha))
        {
            return Result<LoginViewModel>.Failure(new List<string> { "A Senha é obrigatória" });
        }
        else
        {
            var entity = new { usu_nome, usu_senha };

            var response = await _httpClient.PostAsJsonAsync("api/v1/usuarios/login", entity);
            if (response.IsSuccessStatusCode)
            {
                var inputResult = await response.Content.ReadFromJsonAsync<LoginViewModel>();

                return Result<LoginViewModel>.Success(inputResult);
            }

            var errors = await response.TratarErroAsync();
            return Result<LoginViewModel>.Failure(errors);
        }
    }

}




