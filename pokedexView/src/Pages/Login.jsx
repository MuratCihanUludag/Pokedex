import React, { useEffect, useRef } from "react";
import Pokeball from "../assets/pokeball.png";
import LoginForm from "../Components/Form/LoginForm";
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
          <img ref={pokeballRef} className="pokeball-icon" src={Pokeball} alt="pokeball-icon" />
        </div>
        <LoginForm/>
      </div>
    </div>
  );
}

export default Login;
