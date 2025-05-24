using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationPokemon.Models
{
    public class Gym
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Citta { get; set; }

        // Relazione: 1 Gym -> molti Trainer
        public ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}
