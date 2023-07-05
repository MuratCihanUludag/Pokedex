using Microsoft.EntityFrameworkCore;
using PokedexApi.Model;

namespace PokedexApi.Context
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
        }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonStat> PokemonStats { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<PokemonWeakness> PokemonWeaknesses { get; set; }
    }
}
