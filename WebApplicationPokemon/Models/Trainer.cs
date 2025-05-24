using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationPokemon.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public int Eta { get; set; }

        public string Citta { get; set; }

        // Foreign Key verso Gym
        public int GymId { get; set; }
        public Gym Gym { get; set; }

        // Relazione: 1 Trainer -> molti Pokémon
        public ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    }
}
