using PokedexApi.SeedWorks;

namespace PokedexApi.Model
{
    public class Pokemon : BaseEnity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public PokemonStat PokemonStats { get; set; }
        public ICollection<PokemonType> PokemonTypes { get; set; }
        public ICollection<PokemonWeakness> pokemonWeaknesses { get; set; }


    }
}
