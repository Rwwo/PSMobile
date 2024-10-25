using PSMobile.Web.Components;
using PSMobile.SharedKernel;
using PSMobile.SharedUI.Services;


var builder = WebApplication.CreateBuilder(args);
//var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSharedKernelServices();
builder.Services.AddScoped<ConfirmationDialogService>();

//InteractiveRenderSettings.ConfigureBlazorHybridRenderModes();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
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
