using System.ComponentModel.DataAnnotations;

namespace WebApplicationPokemon.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome del Pokémon è obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il tipo è obbligatorio")]
        public string Tipo { get; set; }

        [Range(1, 100, ErrorMessage = "Il livello deve essere tra 1 e 100")]
        public int Livello { get; set; }

        // Collegato all'allenatore
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }

}
