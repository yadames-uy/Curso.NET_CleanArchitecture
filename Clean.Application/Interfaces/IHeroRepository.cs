using Clean.Domain.Entities;

namespace Clean.Application.Interfaces
{
    public interface IHeroRepository
    {
        bool InsertHero(Hero hero);

        Hero FindHeroById(int id);

        IList<Hero> GetAllHeros();
    }
}