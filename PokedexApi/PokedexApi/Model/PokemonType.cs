using PokedexApi.SeedWorks;

namespace PokedexApi.Model
{
    public class PokemonType : BaseEnity
    {
        public string Name { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
