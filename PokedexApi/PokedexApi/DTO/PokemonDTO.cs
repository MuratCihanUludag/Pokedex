﻿using PokedexApi.Model;

namespace PokedexApi.ViewModel
{
    public class PokemonDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<int> PokemonTypesId { get; set; }
        public List<int> pokemonWeaknessesId { get; set; }
        public PokemonStatDTO PokemonStats { get; set; }
    }
}
