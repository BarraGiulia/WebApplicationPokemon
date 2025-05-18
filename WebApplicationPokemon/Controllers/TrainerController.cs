using Microsoft.AspNetCore.Mvc;

namespace WebApplicationPokemon.Controllers
{
    public class TrainerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
