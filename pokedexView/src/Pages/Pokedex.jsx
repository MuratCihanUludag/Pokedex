import React, { useContext } from "react";
import ApiContext from "../Context/ApiContext";
import { Link } from "react-router-dom";
function Pokedex() {
  const { pokemons } = useContext(ApiContext);
  console.log(pokemons);
  return (
    <section className="section">
      <div className="pokedex-grid">
        {pokemons?.map((pokemon, index) => {
          const id = pokemon.id.toString().padStart(3, "0");
          return (
            <div key={index} className="pokedex-card">
              <Link to={`/pokemon/${pokemon.id}`}>
                <div style={{ textAlign: "center" }}>
                  <img src={`https://assets.pokemon.com/assets/cms2/img/pokedex/detail/${id}.png`} alt={pokemon.name}/>
                </div>
                <p>#{id}</p>
                <h3>{pokemon.name}</h3>
                <div className="pokemon-type">
                  {pokemon.type.map((type, index) => {
                    return (
                      <p className={`${type.name}`} key={index}>{type.name}</p>
                    );
                  })}
                </div>
              </Link>
            </div>
          );
        })}
      </div>
    </section>
  );
}

export default Pokedex;
