using PokedexApi.Model;

namespace PokedexApi.ViewModel
{
    public class PokemonViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public PokemonStat PokemonStats { get; set; }
        public List<int> PokemonTypesId { get; set; }
        public List<int> pokemonWeaknessesId { get; set; }
    }
}
