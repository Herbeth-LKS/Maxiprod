# Usa a imagem oficial do .NET SDK para desenvolvimento
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

# Copia os arquivos do projeto
COPY . .

# Restaura as dependências
RUN dotnet restore
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update || true

# Expõe a porta padrão do .NET
EXPOSE 5555

# Comando de inicialização será definido no docker-compose
ENTRYPOINT ["sh", "-c", "dotnet ef database update || true && dotnet run --urls http://0.0.0.0:5555"]
