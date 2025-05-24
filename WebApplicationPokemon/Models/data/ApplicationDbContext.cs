using Microsoft.EntityFrameworkCore;

namespace WebApplicationPokemon.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Gym> Gyms { get; set; }
    }
}
