using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationPokemon.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Il nome deve avere tra 3 e 50 caratteri")]
        public string Nome { get; set; }

        [Range(10, 100, ErrorMessage = "L'età deve essere tra 10 e 100")]
        public int Eta { get; set; }

        [Required(ErrorMessage = "La città è obbligatoria")]
        public string Citta { get; set; }

        public int GymId { get; set; }
        public Gym Gym { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    }

}
