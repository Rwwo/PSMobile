using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

using MudBlazor.Services;

using MudExtensions.Services;

using PSMobile.SharedKernel.Utilities.Handler;
using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedKernel.Utilities.Services;

namespace PSMobile.SharedKernel;
public static class SharedKernelModule
{
    public static IServiceCollection AddSharedKernelServices(this IServiceCollection services)
    {

        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

        // Adiciona o handler personalizado para JWT
        services.AddSingleton<TokenService>();
        services.AddTransient<JwtAuthorizationHandler>();

        // Configura o HttpClient para usar o handler JWT e ignora erros de certificado (somente em desenvolvimento)
        services.AddHttpClient("WithJwtClient", client =>
        {
            client.BaseAddress = new Uri("https://192.168.0.170:41352/");
            //client.BaseAddress = new Uri("https://192.168.0.170:44332");
            //client.BaseAddress = new Uri("https://192.168.0.170:5000");
        })
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
        })
        .AddHttpMessageHandler<JwtAuthorizationHandler>();

        services.AddSingleton(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WithJwtClient"));

        services.AddHttpContextAccessor();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

        services.AddSingleton<IUowAPI, UowAPI>();
        services.AddSingleton<IPssysValidacoesService, PssysValidacoesService>();
        services.AddSingleton<ILocalNavigationService, LocalNavigationService>();

        services.AddMudExtensions();

        services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.BottomLeft;
            config.SnackbarConfiguration.VisibleStateDuration = 2000;
            config.SnackbarConfiguration.MaxDisplayedSnackbars = 10;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
        });

        if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
            services.AddScoped<IStorageService, MobileStorageService>();
        else
            services.AddScoped<IStorageService, WebStorageService>();


        return services;
    }
}
