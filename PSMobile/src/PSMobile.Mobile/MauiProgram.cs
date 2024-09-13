using Microsoft.Extensions.Logging;

using MudBlazor;
using MudBlazor.Services;

using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedKernel.Utilities.Services;
using PSMobile.SharedUI;

namespace PSMobile.Mobile;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://192.168.0.170:44332") });
        builder.Services.AddScoped<ICadastroService, CadastroService>(); // Registrar o serviço

        builder.Services.AddSingleton<ILocalNavigationService, LocalNavigationService>();

        InteractiveRenderSettings.ConfigureBlazorHybridRenderModes();

        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.MaxDisplayedSnackbars = 10;
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
            config.SnackbarConfiguration.VisibleStateDuration = 2000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
        });

        return builder.Build();
    }
}
