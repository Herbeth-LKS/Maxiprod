FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos do projeto
COPY . .

# Instala as dependências
RUN dotnet restore

# Instalar o dotnet-ef globalmente
RUN dotnet tool install --global dotnet-ef

EXPOSE 5278

# Comando padrão (sobrescrito no docker-compose)
CMD ["dotnet", "run"]
