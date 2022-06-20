using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using Clean.WebAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clean.WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHeroHandler _heroHandler;

        public HomeController(ILogger<HomeController> logger, IHeroHandler heroHandler)
        {
            _logger = logger;
            _heroHandler = heroHandler;
        }

        public IActionResult Index(string heroId)
        {
            try
            {
                if (string.IsNullOrEmpty(heroId))
                    return View();

                if (!int.TryParse(heroId, out _))
                    throw new Exception("ID inválido");

                Hero hero = _heroHandler.FindHeroById(int.Parse(heroId));
                return View(hero);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}