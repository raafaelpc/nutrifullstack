import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

function DataList() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get('https://localhost:7298/api/basal/info');
        setData(response.data);
        setLoading(false);
      } catch (error) {
        setError(error.message);
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  if (loading) {
    return <p>Loading...</p>;
  }

  if (error) {
    return <p className="error">Erro: {error}</p>;
  }

  return (
    <div className="data-list">
      <h1>
        Dados Registrados ({data.length} {data.length === 1 ? 'pessoa' : 'pessoas'})
      </h1>
      <ul>
        {data.map((item, index) => (
          <li key={index}>
            Nome: {item.nome}, Basal Metabolismo: {item.basalMetabolismo}
          </li>
        ))}
      </ul>

      <Link to="/">
        <button>Novo registro</button>
      </Link>
    </div>
  );
}

export default DataList;
