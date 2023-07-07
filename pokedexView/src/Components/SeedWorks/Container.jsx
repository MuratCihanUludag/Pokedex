import React from 'react'
import Pokedex from '../../Pages/Pokedex'
import { Route,Routes } from 'react-router-dom'

function Container() {
  return (
    <Routes>
        <Route path='/' element={<Pokedex/>} />
      
    </Routes>
  )
}

export default Container
