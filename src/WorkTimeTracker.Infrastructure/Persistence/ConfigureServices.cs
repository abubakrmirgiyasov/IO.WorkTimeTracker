using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WorkTimeTracker.Infrastructure.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }
}
