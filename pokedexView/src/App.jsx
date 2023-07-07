import React from "react";
import "./App.css";
import Container from "./Components/SeedWorks/Container";
import { BrowserRouter } from "react-router-dom";
import Login from "./Pages/Login";

function App() {
  const permissionId = 1; // It will be entered manually for a temporary period, and then the API will be taken from the API after the necessary actions are taken.
  if (permissionId === 1) {
    return <Login />;
  }
  return (
    <BrowserRouter>
      <Container />
    </BrowserRouter>
  );
}

export default App;
