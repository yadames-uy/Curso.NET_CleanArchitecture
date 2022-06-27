using Clean.Application.Handler;
using Clean.Application.Validations;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<Hero>, HeroValidator>();

        services.AddSingleton<IHeroHandler, HeroHandler>();

        return services;
    }
}