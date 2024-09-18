using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using PSMobile.core.Interfaces;
using PSMobile.core.Notifications;
using PSMobile.infrastructure.Context;
using PSMobile.infrastructure.Repositories;

namespace PSMobile.infrastructure;
public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextConfig(configuration);

        services.AddScoped<INotify, Notificador>();

        return services;
    }

    public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<ICidadesRepository, CidadesRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            options.EnableSensitiveDataLogging();
            options.LogTo(Console.WriteLine, LogLevel.Warning);
        });


        return services;
    }


}
