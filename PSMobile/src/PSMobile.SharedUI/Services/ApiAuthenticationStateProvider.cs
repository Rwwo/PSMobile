using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

using MudBlazor.Interfaces;

using System.Security.Claims;

namespace PSMobile.SharedUI.Services;
public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime _jsRuntime;

    public ApiAuthenticationStateProvider(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task MarkUserAsAuthenticated(string token)
    {
        var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");
        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Verifica se estamos em pré-renderização
        if (_jsRuntime is not IJSInProcessRuntime)
            // Durante a pré-renderização, retorna um estado não autenticado
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        // Recupera o token do localStorage
        var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

        if (string.IsNullOrWhiteSpace(token))
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");
        var user = new ClaimsPrincipal(identity);

        return new AuthenticationState(user);
    }
}
