import { createContext, useEffect, useState } from "react";

import axios from "axios";
const ApiContex = createContext();
export const ApiContexProvider = ({ children }) => {
  const api = axios.create();
  const [pokemons, setPokemons] = useState(null);
  const GetPokemon = () => {
    api.get("https://localhost:7033/api/Pokemons").then((res) => {
      setPokemons(res.data);
    });
  };
  useEffect(() => {
    GetPokemon();
  },[]);
  const values = {
    pokemons,
  };

  return <ApiContex.Provider value={values}> {children} </ApiContex.Provider>;
};
export default ApiContex;
