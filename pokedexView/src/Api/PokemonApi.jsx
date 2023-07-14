import axios from "axios";

const PokemonApi = () => {
  const api = axios.create({
    baseURL: "https://localhost:7033/",
  });

  //======================================= HttpGet =================================================
  const GetPokemon = (setPokemons) => {
    api.get("api/Pokemons").then((res) => {
      setPokemons(res.data);
    });
  };
  const CreatePokemon = (data) => {
    api.post("api/Pokemons", data);
  };

  const pokemonApi = {
    GetPokemon,
  };
  return { pokemonApi };
};

export default PokemonApi;
