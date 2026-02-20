using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Anfx.Sistema.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddValidatorsFromAssemblyContaining<SistemaApplicationMarker>();

        services.AddLiteBus(configuration =>
        {
            var assembly = typeof(SistemaApplicationMarker).Assembly;

            configuration.AddCommandModule(m => m.RegisterFromAssembly(assembly));
            configuration.AddQueryModule(m => m.RegisterFromAssembly(assembly));

        });



        return services;
    }
}
class SistemaApplicationMarker { }