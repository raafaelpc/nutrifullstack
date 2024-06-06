import React, { useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

function Register() {
  const [formData, setFormData] = useState({
    nome: '',
    idade: '',
    peso: '',
    altura: '',
    sexo: ''
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const [basalMetabolism, setBasalMetabolism] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError(null);

    try {
      const response = await axios.post('https://localhost:7298/api/basal/metabolismo-basal', formData);
      setBasalMetabolism(response.data);
      setFormData({
        ...formData,
        [e.target.name]: e.target.value
      });
    } catch (error) {
      setError(error.message);
    } finally {
      setLoading(false);
    }
  };

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  return (
    <div>
      <h1>Registrar Dados</h1>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="nome">Nome</label>
          <input
            type="text"
            id="nome"
            name="nome"
            value={formData.nome}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="idade">Idade</label>
          <input
            type="number"
            id="idade"
            name="idade"
            value={formData.idade}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="peso">Peso (kg)</label>
          <input
            type="number"
            id="peso"
            name="peso"
            value={formData.peso}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="altura">Altura (cm)</label>
          <input
            type="number"
            id="altura"
            name="altura"
            value={formData.altura}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="sexo">Sexo</label>
          <select id="sexo" name="sexo" value={formData.sexo} onChange={handleChange} required>
            <option value="">Selecione</option>
            <option value="M">Masculino</option>
            <option value="F">Feminino</option>
          </select>
        </div>
        <div className="button-group">
          <button type="submit" disabled={loading}>
            {loading ? 'Registrando...' : 'Registrar'}
          </button>
          <Link to="/data">
            <button>Ver registros</button>
          </Link>
        </div>
      </form>

      {basalMetabolism && (
        <div className="basal-metabolism">
          <p>Metabolismo Basal: {basalMetabolism}</p>
        </div>
      )}

      {error && <p className="error">Erro: {error}</p>}
    </div>
  );
}

export default Register;
