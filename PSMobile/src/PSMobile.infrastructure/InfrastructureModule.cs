using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using PSMobile.core.Interfaces;
using PSMobile.core.Notifications;
using PSMobile.infrastructure.Context;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedKernel.Utilities.Services;

namespace PSMobile.infrastructure;
public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextConfig(configuration);

        services.AddScoped<INotificador, Notificador>();

        return services;
    }

    public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        //services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<ICadastroRepository, CadastroRepository>();
        services.AddScoped<ICidadesRepository, CidadesRepository>();
        services.AddScoped<IFuncionariosRepository, FuncionariosRepository>();
        services.AddScoped<IUFsRepository, UFsRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IPssysValidacoesService, PssysValidacoesService>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            options.EnableSensitiveDataLogging();
            options.LogTo(Console.WriteLine, LogLevel.Warning);
        });


        return services;
    }


}
