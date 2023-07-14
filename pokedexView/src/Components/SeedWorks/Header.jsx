import React from "react";
import { NavLink } from "react-router-dom";

function Header() {
  return (
    <header className="header">
      <ul className="flex">
        <li>
          <NavLink>Home</NavLink>
        </li>
        <li>
          <NavLink>Pokedex</NavLink>
        </li>
        <li>
          <NavLink>Trading Card</NavLink>
        </li>
        <li>
          <NavLink to={"/create/pokemon"}>Create Pokemon</NavLink>
        </li>
      </ul>
    </header>
  );
}

export default Header;
