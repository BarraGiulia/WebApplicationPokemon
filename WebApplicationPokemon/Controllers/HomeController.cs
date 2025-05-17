using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationPokemon.Models;
using System.Collections.Generic; // Aggiungi questa riga

namespace WebApplicationPokemon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Aggiungi qui una lista di Pokémon da passare alla vista
            var pokemonList = new List<string> { "Pikachu", "Bulbasaur", "Charmander", "Squirtle" };
            return View(pokemonList); // Passa la lista alla vista
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
