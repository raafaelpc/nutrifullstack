import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Register from './Components/RegisterForm';
import DataList from './Components/DataList';
import './App.css'; // Importa o CSS

function App() {
  return (
    <Router>
      <div className="container">
        <header className="header">
          <h1>Calculadora de Metabolismo Basal</h1>
        </header>
        <Routes>
          <Route path="/" element={<Register />} />
          <Route path="/data" element={<DataList />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
