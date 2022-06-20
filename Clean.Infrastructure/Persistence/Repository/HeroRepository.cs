using Clean.Application.Interfaces;
using Clean.Domain.Entities;

namespace Clean.Infrastructure.Persistence.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly SQLDBContext _dbContext;

        public HeroRepository()
        {
            _dbContext = new SQLDBContext();
        }

        public Hero FindHeroById(int id)
        {
            return _dbContext.Hero.Where(x => x.Id == id).FirstOrDefault<Hero>();
        }

        public IList<Hero> GetAllHeros()
        {
            return _dbContext.Hero.ToList();
        }

        public bool InsertHero(Hero hero)
        {
            var result = _dbContext.Hero.Add(hero);
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}