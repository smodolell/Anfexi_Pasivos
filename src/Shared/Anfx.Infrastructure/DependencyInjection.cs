using Anfx.Auth.Application.Common.Interfaces;
using Anfx.Infrastructure.Persistence;
using Anfx.Infrastructure.Services;
using Anfx.Sistema.Application.Common.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anfx.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
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



        #region Sistema

        services.AddScoped<ISistemaDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        #endregion




        #region Auth

        services.AddScoped<IAuthDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IJwtService, JwtService>();

        #endregion
        return services;
    }
}