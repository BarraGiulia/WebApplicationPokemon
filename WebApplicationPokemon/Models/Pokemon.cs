using System.ComponentModel.DataAnnotations;

namespace WebApplicationPokemon.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome del Pokémon è obbligatorio")]
        [RegularExpression("^[A-Za-zÀ-ÿ\\s'-]+$", ErrorMessage = "Il nome può contenere solo lettere e spazi")]
        [StringLength(50, ErrorMessage = "Il nome non può superare i 50 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il tipo è obbligatorio")]
        [StringLength(30, ErrorMessage = "Il tipo non può superare i 30 caratteri")]
        public string Tipo { get; set; }

        [Range(1, 100, ErrorMessage = "Il livello deve essere tra 1 e 100")]
        public int Livello { get; set; }

        [Required(ErrorMessage = "È necessario selezionare un allenatore")]
        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; }
    }
}
