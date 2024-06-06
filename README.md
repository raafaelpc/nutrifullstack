# Configuração do Back-end
## Clone o Repositório
git clone https://github.com/raafaelpc/nutrifullstack.git

cd seu-repositorio/BackEnd

## Configurar a String de Conexão

### Atualize a string de conexão no appsettings.json para conectar ao seu banco de dados SQL Server.

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=NomeDoBanco;Trusted_Connection=True;"
  }
}

## Restaurar Pacotes NuGet
dotnet restore

## Aplicar Migrações e Atualizar o Banco de Dados
dotnet ef database update

## Executar o Projeto
dotnet run



# Configuração do Front-end

## Navegar para o Diretório do Front-end
cd ../FrontEnd

## Instalar Dependências
npm install .

## Executar o Projeto React
npm start

