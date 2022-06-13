using AnticariApp.Application.Common;
using AnticariApp.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace AnticariApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.RegisterAssemblyPublicNonGenericClasses(typeof(DataService).Assembly)
            .Where(c => c.Name.EndsWith("Service"))
            .AsPublicImplementedInterfaces();

        return services;
    }

    public static IServiceCollection AddACContext(this IServiceCollection services)
    {
        services.AddDbContext<ACContext>();

        return services;
    }
}
