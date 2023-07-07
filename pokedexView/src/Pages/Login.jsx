import React from "react";
import Pokeball from "../assets/pokeball.png";
function Login() {
  return (
    <div>
      <div className="login-backgorund">
        <div className="left-half"></div>
        <div className="right-half"></div>
        <div className="icon-position">
          <img className="pokeball-icon" src={Pokeball} alt="" />
        </div>
      </div>
    </div>
  );
}

export default Login;
