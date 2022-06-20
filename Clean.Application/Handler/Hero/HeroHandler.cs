using Clean.Application.Interfaces;
using Clean.Domain.Interfaces;

namespace Clean.Application.Handler.Hero
{
    public class HeroHandler : IHeroHandler
    {
        private readonly IHeroRepository _heroRepository;

        public HeroHandler(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public Domain.Entities.Hero FindHeroById(int id)
        {
            return _heroRepository.FindHeroById(id);
        }

        public IList<Domain.Entities.Hero> GetAllHero()
        {
            return _heroRepository.GetAllHeros();
        }

        public bool InsertHero(Domain.Entities.Hero hero)
        {
            return _heroRepository.InsertHero(hero);
        }
    }
}