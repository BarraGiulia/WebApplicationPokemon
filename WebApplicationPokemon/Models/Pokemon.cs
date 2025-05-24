using System.ComponentModel.DataAnnotations;

namespace WebApplicationPokemon.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Tipo { get; set; }

        public int Livello { get; set; }

        // Foreign Key verso Trainer
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
