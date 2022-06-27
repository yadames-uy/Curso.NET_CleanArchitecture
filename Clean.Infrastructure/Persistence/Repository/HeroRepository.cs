using AutoMapper;
using Clean.Application.Interfaces;
using Clean.Domain.Entities;
using Clean.Infrastructure.Persistence.DTOs;
using Microsoft.Extensions.Logging;

namespace Clean.Infrastructure.Persistence.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly SQLDBContext _dbContext;
        private readonly ILogger<HeroRepository> _logger;
        private readonly IMapper _mapper;

        public HeroRepository(ILogger<HeroRepository> logger, IMapper mapper)
        {
            _dbContext = new SQLDBContext();
            _logger = logger;
            _mapper = mapper;
        }

        public Hero FindHeroById(int id)
        {
            var result = _dbContext.Hero.Where(x => x.Id == id).FirstOrDefault<HeroDto>()!;
            if (result != null)
            {
                _logger.LogInformation("Encontrado heroe: {0}", result.Name);
            }
            else
            {
                _logger.LogInformation("No se ha encontrado elementos con el id {0}", id);
            }

            return _mapper.Map<Hero>(result);
        }

        public IList<Hero> GetAllHeros()
        {
            var result = _dbContext.Hero.ToList();
            return _mapper.Map<List<Hero>>(result);
        }

        public bool InsertHero(Hero hero)
        {
            var result = _dbContext.Hero.Add(_mapper.Map<HeroDto>(hero));
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