using PSMobile.Web.Components;
using PSMobile.SharedKernel;
using PSMobile.SharedUI.Services;
using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedKernel.Utilities.Services;
using Microsoft.AspNetCore.Components.Authorization;
using PSMobile.SharedKernel.Common.Dtos;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddSharedKernelServices();
        builder.Services.AddScoped<ConfirmationDialogService>();
        builder.Services.AddScoped<INavigationService, NavigationService>();

        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

        builder.Services.AddCascadingAuthenticationState();

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

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        // Middleware de autenticação e autorização
        app.UseAuthentication()
            .UseAuthorization();

        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddAdditionalAssemblies(typeof(PSMobile.SharedUI._Imports).Assembly)
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}