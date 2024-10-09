using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Authentication.JwtBearer;


using PSMobile.core.Interfaces;
using PSMobile.core.Notifications;
using PSMobile.infrastructure.Context;
using PSMobile.infrastructure.Repositories;
using PSMobile.infrastructure.Services;
using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedKernel.Utilities.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PSMobile.infrastructure;
public static class InfrastructureModule
{

    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextConfig(configuration)
            .AddAuth(configuration)
            .AddScoped<INotificador, Notificador>();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = "sub",
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });

        services.AddScoped<IAuthService, AuthService>();

        return services;

    }

    public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IPssysValidacoesService, PssysValidacoesService>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            options.EnableSensitiveDataLogging();
            options.LogTo(Console.WriteLine, LogLevel.Trace);
        });


        return services;
    }


}
