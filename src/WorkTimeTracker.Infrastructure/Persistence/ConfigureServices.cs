using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkTimeTracker.Application.WorkTimeTrackings.Repositories;
using WorkTimeTracker.Infrastructure.Persistence.Repositories;
using WorkTimeTracker.Application.Projects.Repositories;
using WorkTimeTracker.Application.ProjectTypes.Repositories;

namespace WorkTimeTracker.Infrastructure.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var conntectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conntectionString));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWorkTimeTrackingRepository, WorkTimeTrackingRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IProjectTypeRepository, ProjectTypeRepository>();

        return services;
    }
}
