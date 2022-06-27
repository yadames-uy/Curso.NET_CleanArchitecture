using AutoMapper;
using Clean.Application.Interfaces;
using Clean.Infrastructure;
using Clean.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MapperProfile());
        });

        services.AddSingleton(mapperConfig.CreateMapper());

        services.AddSingleton<IHeroRepository, HeroRepository>();

        return services;
    }
}