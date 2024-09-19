
using MudBlazor;
using MudBlazor.Services;


using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedKernel.Utilities.Services;
using PSMobile.SharedUI;
using PSMobile.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://192.168.0.170:44332") });
builder.Services.AddScoped<ICadastroService, CadastroService>(); // Registrar o serviço
builder.Services.AddScoped<IApiService, ApiService>();


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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(typeof(PSMobile.SharedUI._Imports).Assembly)
    .AddInteractiveServerRenderMode();


app.Run();
