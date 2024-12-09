using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

using Microsoft.JSInterop;

public class WebStorageService : IStorageService
{
    private readonly IJSRuntime _jsRuntime;

    public WebStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SetAsync(string key, string value)
    {
        await EnsureJsRuntimeAvailable();
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
    }

    public async Task<string?> GetAsync(string key)
    {
        await EnsureJsRuntimeAvailable();
        return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
    }

    public async Task Remove(string key)
    {
        await EnsureJsRuntimeAvailable();
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
    }

    private async Task EnsureJsRuntimeAvailable()
    {
        if (_jsRuntime is IJSInProcessRuntime)
            return;

        // Aguarda até que o JavaScript esteja disponível (apenas para Blazor Server)
        var jsRuntimeAsInterop = _jsRuntime as IJSRuntime;
        if (jsRuntimeAsInterop != null)
        {
            await jsRuntimeAsInterop.InvokeVoidAsync("eval", "true");
        }
    }
}
