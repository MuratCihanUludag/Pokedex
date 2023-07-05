using PokedexApi.SeedWorks;

namespace PokedexApi.Model
{
    public class PokemonWeakness : BaseEnity
    {
        public string Name { get; set; }
        public ICollection<Pokemon> pokemons { get; set; }
    }
}
