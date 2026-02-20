using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Anfx.Catalogo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddValidatorsFromAssemblyContaining<CatalogoApplicationMarker>();

        services.AddLiteBus(configuration =>
        {
            var assembly = typeof(CatalogoApplicationMarker).Assembly;

            configuration.AddCommandModule(m => m.RegisterFromAssembly(assembly));
            configuration.AddQueryModule(m => m.RegisterFromAssembly(assembly));

        });


        return services;
    }
}
class CatalogoApplicationMarker { }