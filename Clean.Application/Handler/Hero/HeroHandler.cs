using Clean.Application.Interfaces;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Clean.Application.Handler
{
    public class HeroHandler : IHeroHandler
    {
        private readonly IHeroRepository _heroRepository;
        private readonly ILogger<HeroHandler> _logger;
        private readonly IValidator<Hero> _validator;

        public HeroHandler(IHeroRepository heroRepository, ILogger<HeroHandler> logger, IValidator<Hero> validator)
        {
            _heroRepository = heroRepository;
            _logger = logger;
            _validator = validator;
        }

        public Hero FindHeroById(int id)
        {
            _logger.LogInformation("Buscando por un id {0}", id);

            //ESTE CÓDIGO ES SOLO DE EJEMPLO PARA EXPLICAR LA VALIDACIÓN USANDO FLUENTVALIDATION
            Hero hero = new Hero();

            ValidationResult result = _validator.Validate(hero, options => options.IncludeRuleSets("Nombre"));

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }
            //ESTE CÓDIGO ES SOLO DE EJEMPLO PARA EXPLICAR LA VALIDACIÓN USANDO FLUENTVALIDATION

            return _heroRepository.FindHeroById(id);
        }

        public IList<Hero> GetAllHero()
        {
            return _heroRepository.GetAllHeros();
        }

        public bool InsertHero(Hero hero)
        {
            return _heroRepository.InsertHero(hero);
        }
    }
}