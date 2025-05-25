using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplicationPokemon.Models;

namespace WebApplicationPokemon.Controllers
{
    public class GymController : Controller
    {
        private static List<Gym> gyms = new List<Gym>
        {
            new Gym { Id = 1, Nome = "Palestra di Pewter", Citta = "Pewter", Trainers = new List<Trainer> { new Trainer(), new Trainer() } },
            new Gym { Id = 2, Nome = "Palestra di Cerulean", Citta = "Cerulean", Trainers = new List<Trainer> { new Trainer() } },
            new Gym { Id = 3, Nome = "Palestra di Vermilion", Citta = "Vermilion", Trainers = new List<Trainer> { new Trainer() } }
        };

        public IActionResult Index()
        {
            return View(gyms);
        }

        public IActionResult Details(int id)
        {
            var gym = gyms.FirstOrDefault(g => g.Id == id);
            if (gym == null) return NotFound();
            return View(gym);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Gym gym)
        {
            if (!ModelState.IsValid)
                return View(gym);

            gym.Id = gyms.Any() ? gyms.Max(g => g.Id) + 1 : 1;
            gym.Trainers = new List<Trainer>(); // nessun allenatore per ora
            gyms.Add(gym);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var gym = gyms.FirstOrDefault(g => g.Id == id);
            if (gym == null) return NotFound();
            return View(gym);
        }

        [HttpPost]
        public IActionResult Edit(int id, Gym updatedGym)
        {
            if (!ModelState.IsValid)
                return View(updatedGym);

            var gym = gyms.FirstOrDefault(g => g.Id == id);
            if (gym == null) return NotFound();

            gym.Nome = updatedGym.Nome;
            gym.Citta = updatedGym.Citta;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var gym = gyms.FirstOrDefault(g => g.Id == id);
            if (gym == null) return NotFound();
            return View(gym);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var gym = gyms.FirstOrDefault(g => g.Id == id);
            if (gym == null) return NotFound();

            gyms.Remove(gym);
            return RedirectToAction(nameof(Index));
        }
    }
}
