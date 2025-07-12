using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace WorkTimeTracker.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = typeof(ConfigureServices).Assembly;
        services.AddAutoMapper(assembly);
        services.AddMediatR((x) => x.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);

        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
