using Microsoft.AspNetCore.Mvc;
using WebApplicationPokemon.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplicationPokemon.Controllers
{
    public class GymController : Controller
    {
        private static List<Gym> gyms = new List<Gym>
        {
              new Gym { Nome = "Palestra di Pewter", Citta = "Pewter", Trainers = new List<Trainer> { new Trainer(), new Trainer() } },
              new Gym { Nome = "Palestra di Cerulean", Citta = "Cerulean", Trainers = new List<Trainer> { new Trainer() } },
              new Gym { Nome = "Palestra di Vermilion", Citta = "Vermilion", Trainers = new List<Trainer> { new Trainer() } }
        };

        public IActionResult Index()
        {
            return View(gyms);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Gym newGym)
        {
            newGym.Id = gyms.Max(g => g.Id) + 1;
            gyms.Add(newGym);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var gym = gyms.FirstOrDefault(g => g.Id == id);
            return View(gym);
        }

        [HttpPost]
        public IActionResult Edit(Gym updated)
        {
            var gym = gyms.FirstOrDefault(g => g.Id == updated.Id);
            if (gym != null)
            {
                gym.Nome = updated.Nome;
                gym.Citta = updated.Citta;
                gym.Trainers = updated.Trainers;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var gym = gyms.FirstOrDefault(g => g.Id == id);
            return View(gym);
        }

        public IActionResult Delete(int id)
        {
            var gym = gyms.FirstOrDefault(g => g.Id == id);
            if (gym != null)
                gyms.Remove(gym);
            return RedirectToAction("Index");
        }
    }
}
