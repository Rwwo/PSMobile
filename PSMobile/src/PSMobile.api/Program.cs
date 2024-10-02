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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
}

app.ConfigureCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
