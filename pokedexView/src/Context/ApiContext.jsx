import { createContext, useEffect, useState } from "react";
import PokemonApi from "../Api/PokemonApi";
import axios from "axios";
const ApiContex = createContext();
export const ApiContexProvider = ({ children }) => {
  const { pokemonApi } = PokemonApi();
  const api = axios.create();
  const [pokemons, setPokemons] = useState(null);
  const [postPokemon, setPostPokemon] = useState(null);

  const fillContext = () => {
    pokemonApi.GetPokemon(setPokemons);
  };

  useEffect(() => {
    fillContext();
  }, []);
  const values = {
    pokemons,
  };

  return <ApiContex.Provider value={values}> {children} </ApiContex.Provider>;
};
export default ApiContex;
