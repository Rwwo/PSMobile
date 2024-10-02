using Microsoft.Extensions.Logging;

using PSMobile.SharedKernel;
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
        builder.Services.AddSharedKernelServices();

        InteractiveRenderSettings.ConfigureBlazorHybridRenderModes();

        return builder.Build();
    }

}
