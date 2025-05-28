using Microsoft.AspNetCore.Mvc;
using WebApplicationPokemon.Models;

namespace WebApplicationPokemon.Controllers
{
    public class TrainerController : Controller
    {
        // Dati finti in memoria per esempio
        private static List<Trainer> trainers = new List<Trainer>
        {
            new Trainer { Id = 1, Nome = "Ash", Eta = 10, Citta = "Pallet Town", Gym = new Gym { Nome = "Verde" }, Pokemons = new List<Pokemon> { new Pokemon(), new Pokemon(), new Pokemon() } },
            new Trainer { Id = 2, Nome = "Misty", Eta = 12, Citta = "Cerulean", Gym = new Gym { Nome = "Acqua" }, Pokemons = new List<Pokemon> { new Pokemon(), new Pokemon(), new Pokemon(), new Pokemon() } },
            new Trainer { Id = 3, Nome = "Brock", Eta = 15, Citta = "Pewter", Gym = new Gym { Nome = "Roccia" }, Pokemons = new List<Pokemon> { new Pokemon(), new Pokemon() } },
        };

        public IActionResult Index()
        {
            return View(trainers);
        }

        public IActionResult Details(int id)
        {
            var trainer = trainers.FirstOrDefault(t => t.Id == id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trainer trainer, int NumeroPokemons)
        {
            trainer.Id = trainers.Max(t => t.Id) + 1;
            trainer.Pokemons = Enumerable.Range(1, NumeroPokemons).Select(i => new Pokemon()).ToList();
            trainers.Add(trainer);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var trainer = trainers.FirstOrDefault(t => t.Id == id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }

        [HttpPost]
        public IActionResult Edit(Trainer trainer, int NumeroPokemons)
        {
            var existing = trainers.FirstOrDefault(t => t.Id == trainer.Id);
            if (existing == null) return NotFound();

            existing.Nome = trainer.Nome;
            existing.Eta = trainer.Eta;
            existing.Citta = trainer.Citta;
            existing.Gym = trainer.Gym;

            // Aggiorna il numero di Pokémon
            int diff = NumeroPokemons - existing.Pokemons.Count;
            if (diff > 0)
                existing.Pokemons = trainer.Pokemons.ToList();
            else if (diff < 0)
                existing.Pokemons = existing.Pokemons.Take(NumeroPokemons).ToList();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var trainer = trainers.FirstOrDefault(t => t.Id == id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var trainer = trainers.FirstOrDefault(t => t.Id == id);
            if (trainer == null) return NotFound();

            trainers.Remove(trainer);
            return RedirectToAction("Index");
        }
    }
}
