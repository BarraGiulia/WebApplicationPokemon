using Microsoft.AspNetCore.Mvc;
using WebApplicationPokemon.Models;

namespace WebApplicationPokemon.Controllers
{
    public class PokemonController : Controller
    {
        private static List<Pokemon> pokemons = new List<Pokemon>
        {
            new Pokemon { Id = 1, Nome = "Pikachu", Tipo = "Elettro", Livello = 25, Trainer = new Trainer { Nome = "Ash" } },
            new Pokemon { Id = 2, Nome = "Bulbasaur", Tipo = "Erba", Livello = 20, Trainer = new Trainer { Nome = "Ash" } },
            new Pokemon { Id = 3, Nome = "Charmander", Tipo = "Fuoco", Livello = 18, Trainer = new Trainer { Nome = "Ash" } },
        };

        public IActionResult Index()
        {
            return View(pokemons);
        }

        public IActionResult Details(int id)
        {
            var pokemon = pokemons.FirstOrDefault(p => p.Id == id);
            if (pokemon == null) return NotFound();
            return View(pokemon);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pokemon pokemon)
        {
            pokemon.Id = pokemons.Max(p => p.Id) + 1;
            pokemons.Add(pokemon);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var pokemon = pokemons.FirstOrDefault(p => p.Id == id);
            if (pokemon == null) return NotFound();
            return View(pokemon);
        }

        [HttpPost]
        public IActionResult Edit(Pokemon pokemon)
        {
            var existing = pokemons.FirstOrDefault(p => p.Id == pokemon.Id);
            if (existing == null) return NotFound();

            existing.Nome = pokemon.Nome;
            existing.Tipo = pokemon.Tipo;
            existing.Livello = pokemon.Livello;
            existing.Trainer = pokemon.Trainer;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var pokemon = pokemons.FirstOrDefault(p => p.Id == id);
            if (pokemon == null) return NotFound();
            return View(pokemon);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var pokemon = pokemons.FirstOrDefault(p => p.Id == id);
            if (pokemon != null) pokemons.Remove(pokemon);
            return RedirectToAction(nameof(Index));
        }

    }
}
