using PSMobile.api.Extensions;

using PSMobile.application;
using PSMobile.infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .AddSwaggerConfig()
    .Services
        .AddInfrastructureModule(builder.Configuration)
        .AddApplicationModule();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
}

app.UseHttpsRedirection();
app.UseRouting();

app.ConfigureCustomExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
