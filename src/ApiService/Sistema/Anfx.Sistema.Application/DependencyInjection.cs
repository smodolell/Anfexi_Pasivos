using Anfx.Sistema.Application.Common.Services;
using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Anfx.Sistema.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddValidatorsFromAssemblyContaining<Dummy>();

        services.AddLiteBus(configuration =>
        {
            var assembly = typeof(DependencyInjection).Assembly;

            configuration.AddCommandModule(m => m.RegisterFromAssembly(assembly));
            configuration.AddQueryModule(m => m.RegisterFromAssembly(assembly));

        });


        services.AddScoped<IPaginator, Paginator>();
        services.AddScoped<IDynamicSorter, DynamicSorter>();

        return services;
    }
}
class Dummy { }