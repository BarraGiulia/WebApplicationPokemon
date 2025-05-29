using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplicationPokemon.Models
{
    public class Gym
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Il nome può contenere solo lettere")]
        [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "La città è obbligatoria")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La città può contenere solo lettere")]
        [StringLength(100, ErrorMessage = "Il nome della città non può superare i 100 caratteri")]
        public string Citta { get; set; }

        [Required(ErrorMessage = "Il tipo di palestra è obbligatorio")]
        public string TipoPalestra { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Il numero di allenatori deve essere un numero positivo")]
        public int NumeroAllenatori { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Il numero di Pokémon deve essere un numero positivo")]
        public int NumeroTotalePokemon { get; set; }

        // Relazione: 1 Gym -> molti Trainer
        public ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}
