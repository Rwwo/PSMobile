using Microsoft.Extensions.Logging;

using PSMobile.SharedKernel;
using PSMobile.SharedUI.Services;


#if ANDROID
[assembly: Android.App.UsesPermission(Android.Manifest.Permission.Camera)]
#endif

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
        builder.Services.AddScoped<ConfirmationDialogService>();


        //InteractiveRenderSettings.ConfigureBlazorHybridRenderModes();

        return builder.Build();
    }

}
