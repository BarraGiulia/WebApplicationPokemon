using Microsoft.AspNetCore.Mvc;

namespace WebApplicationPokemon.Controllers
{
    public class GymController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
