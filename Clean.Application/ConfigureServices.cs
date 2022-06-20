using Clean.Application.Handler.Hero;
using Clean.Domain.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IHeroHandler, HeroHandler>();

        return services;
    }
}