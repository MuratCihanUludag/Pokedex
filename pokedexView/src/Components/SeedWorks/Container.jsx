import React from "react";
import Pokedex from "../../Pages/Pokedex";
import { Route, Routes } from "react-router-dom";
import Login from "../../Pages/Login";
import Registration from "../../Pages/Registration ";
import Header from "./Header";
import { ApiContexProvider } from "../../Context/ApiContext";
function Container() {
  const permissionId = 1;
  if (permissionId === null) {
    return (
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/registration" element={<Registration  />} />
      </Routes>
    );
  }
  if (permissionId === 1){
    return (
      <ApiContexProvider>
        <div className="main" >
          <Header/>
          <Routes>
            <Route path="/" element={<Pokedex />} />
          </Routes>
        </div>
      </ApiContexProvider>
    );
  }
    
}

export default Container;
