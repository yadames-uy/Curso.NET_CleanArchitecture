using Clean.Domain.Entities;

namespace Clean.Domain.Interfaces
{
    public interface IHeroHandler
    {
        bool InsertHero(Hero hero);

        Hero FindHeroById(int id);

        IList<Hero> GetAllHero();
    }
}