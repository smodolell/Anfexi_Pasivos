using Anfx.Common.Application.Interfaces;
using Anfx.Infrastructure.Persistence;
using Anfx.Infrastructure.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anfx.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Configuración de Mapster
        MapsterConfig.Configure();

        services.AddMapster();


        // 2. Configuración de Base de Datos
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Yggdrasil.Infrastructure"));
        }, ServiceLifetime.Scoped);

        services.AddDbContextFactory<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        }, ServiceLifetime.Scoped);



        return services;
    }

    public static IServiceCollection AddSistemaInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ISistemaDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IPaginator, Paginator>();
        services.AddScoped<IDynamicSorter, DynamicSorter>();
        return services;
    }

    public static IServiceCollection AddAuthInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IAuthDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IPaginator, Paginator>();
        services.AddScoped<IDynamicSorter, DynamicSorter>();

        return services;
    }

    public static IServiceCollection AddCatalogoInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<ISistemaDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ICatalogoDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IExcelExportService, ExcelExportService>();
        services.AddScoped<IPaginator, Paginator>();
        services.AddScoped<IDynamicSorter, DynamicSorter>();
        return services;
    }
}