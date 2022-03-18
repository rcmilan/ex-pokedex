using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database
{
    public class PokedexContext : DbContext
    {
        public PokedexContext(DbContextOptions<PokedexContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().HasData
                (
                new Pokemon(1, "Bulbasaur"),
                new Pokemon(2, "Ivysaur"),
                new Pokemon(3, "Venusaur")
                );
        }
    }
}