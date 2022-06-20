using Clean.Application.Interfaces;
using Clean.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHeroRepository, HeroRepository>();

        return services;
    }
}