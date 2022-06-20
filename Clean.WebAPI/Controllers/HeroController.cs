using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clean.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroHandler _heroHandler;

        public HeroController(IHeroHandler heroHandler)
        {
            _heroHandler = heroHandler;
        }

        [Route("FindHeroById")]
        [HttpGet]
        public Hero FindHeroById(int id)
        {
            return _heroHandler.FindHeroById(id);
        }
    }
}