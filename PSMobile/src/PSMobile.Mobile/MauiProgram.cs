using CommunityToolkit.Maui;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using PSMobile.SharedKernel;
using PSMobile.SharedKernel.Common.Dtos;
using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedUI.Components.MauiPages.Values;
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
        // Configura o logging com nível de detalhe
        builder.Logging.SetMinimumLevel(LogLevel.Error); // Defina como Debug para capturar mais eventos
#endif
        builder.Services.AddSharedKernelServices();

        builder.Services.AddCascadingAuthenticationState();

        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
        builder.Services.AddScoped<ConfirmationDialogService>();
        builder.Services.AddScoped<INavigationService, Services.NavigationService>();

        builder.Services.AddAuthentication(Constants.AuthScheme)
            .AddCookie(Constants.AuthScheme, options =>
            {
                options.Cookie.Name = Constants.AuthCookie;
                options.LoginPath = "/auth/login";
                options.AccessDeniedPath = "/auth/access-denied";
                options.LogoutPath = "/auth/logout";

                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;

                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.SlidingExpiration = true;
            });

        builder.Services.AddSingleton<BarcodeResultsStates>();

        return builder.Build();
    }
}