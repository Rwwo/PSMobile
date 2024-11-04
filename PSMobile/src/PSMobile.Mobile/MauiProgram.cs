using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;

using PSMobile.Mobile.Services;
using PSMobile.SharedKernel;
using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedKernel.Utilities.Services;
using PSMobile.SharedUI.Services;

using ZXing.Net.Maui.Controls;


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
            .UseMauiCommunityToolkit()
            .UseBarcodeReader()
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
        
        builder.Services.AddScoped<INavigationService, Services.NavigationService>();


        //InteractiveRenderSettings.ConfigureBlazorHybridRenderModes();

        return builder.Build();
    }

}
