using Microsoft.Extensions.Logging;

using PSMobile.SharedKernel.Utilities;
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

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://192.168.0.170:5000") });
        builder.Services.AddScoped<ICadastroService, CadastroService>(); // Registrar o serviço

        builder.Services.AddSingleton<IConnectivity>(c => Connectivity.Current);

        InteractiveRenderSettings.ConfigureBlazorHybridRenderModes();

        return builder.Build();
    }
}
