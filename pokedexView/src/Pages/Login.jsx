import React, { useEffect, useRef } from "react";
import Pokeball from "../assets/pokeball.png";
function Login() {
  const pokeballRef = useRef(null);

  useEffect(() => {
    pokeballRef.current.addEventListener("animationend", handleAnimationEnd);
  }, []);
  const handleAnimationEnd = () => {
    const loginForm = document.querySelector(".login-form");
    loginForm.style.zIndex = "4";
    loginForm.style.opacity = "1";
  };
  return (
    <div>
      <div className="login-backgorund">
        <div className="left-half"></div>
        <div className="right-half"></div>
        <div className="icon-position">
          <img ref={pokeballRef} className="pokeball-icon" src={Pokeball} alt="" />
        </div>
        <form className="login-form">
          <div className="card">
            <h4 className="card-title" >Login</h4>
            <div className="form-group">
              <input type="text" placeholder="UserName" />
            </div>
            <button className="btn float-right" >Cont</button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default Login;
