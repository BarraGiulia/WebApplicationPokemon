using Microsoft.AspNetCore.Mvc;

namespace WebApplicationPokemon.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
