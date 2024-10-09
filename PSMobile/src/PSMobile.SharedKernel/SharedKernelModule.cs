using Microsoft.Extensions.DependencyInjection;

using MudBlazor.Services;

using MudExtensions.Services;

using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedKernel.Utilities.Services;

namespace PSMobile.SharedKernel;
public static class SharedKernelModule
{
    public static IServiceCollection AddSharedKernelServices(this IServiceCollection services)
    {

        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

        services.AddSingleton(sp => new HttpClient(handler)
        {
            BaseAddress = new Uri("https://192.168.0.170:44332")
            //BaseAddress = new Uri("https://127.0.0.1:7159")
        });

        services.AddSingleton<IUowAPI, UowAPI>();

        services.AddSingleton<IPssysValidacoesService, PssysValidacoesService>();

        services.AddSingleton<ILocalNavigationService, LocalNavigationService>();
        

        services.AddMudExtensions();

        services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.MaxDisplayedSnackbars = 10;
            config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.BottomLeft;
            config.SnackbarConfiguration.VisibleStateDuration = 2000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
        });


        return services;
    }
}
