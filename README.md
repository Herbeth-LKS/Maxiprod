# 🚀 API .NET Dockerizada - Household Expenses  

Este repositório contém uma API **.NET** totalmente containerizada utilizando **Docker** e **PostgreSQL**.  

⚡ **Principais recursos:**  
- A API roda automaticamente ao executar `docker-compose up --build`.  
- O banco de dados **PostgreSQL** é criado e inicializado automaticamente.  
- Comunicação entre os containers já configurada.  

---

## 📋 Pré-requisitos  

Antes de rodar o projeto, verifique se você tem os seguintes softwares instalados:  

- **[Docker](https://www.docker.com/get-started)**  
- **[Docker Compose](https://docs.docker.com/compose/)**  

Para verificar se o Docker e o Docker Compose estão instalados, execute:  

```sh
docker -v
docker-compose -v
```

---

## 🚀 Como Rodar a API  

Para iniciar os containers da API e do banco de dados, execute:  

```sh
docker-compose up --build
```

Isso irá:  
✅ Criar e subir um container **PostgreSQL** na porta `54320`.  
✅ Criar e subir um container da **API .NET** na porta `5555`.  
✅ Criar o banco de dados `household_expenses` automaticamente.  

Se quiser rodar os containers em segundo plano, use:  

```sh
docker-compose up -d --build
```

---

## 🛠️ Configurações do Banco de Dados  

📌 **O banco de dados roda em um container PostgreSQL com os seguintes parâmetros:**  

- **Host:** `db`  
- **Porta:** `54320` (exposta) e `5432` (dentro do container)  
- **Usuário:** `postgres`  
- **Senha:** `root`  
- **Banco de dados:** `household_expenses`  

Você pode acessar o banco via **DBeaver**, **pgAdmin** ou linha de comando:  

```sh
psql -h localhost -p 54320 -U postgres -d household_expenses
```

---

## 📡 Endpoints da API  

A API estará disponível em:  

```
http://localhost:5555
```

Exemplo de chamada com **cURL**:  

```sh
curl -X GET http://localhost:5555/api/
```

Se estiver usando **Postman**, basta importar a URL acima e testar os endpoints.  


---

## 🔄 Como Parar e Remover os Containers  

Para parar os containers sem removê-los:  

```sh
docker-compose down
```

Para parar e **remover** os volumes e os dados do banco:  

```sh
docker-compose down -v
```

---

## 🎯 Principais Comandos Úteis  

| Comando | Descrição |
|---------|-----------|
| `docker ps` | Lista os containers em execução |
| `docker logs -f dotnet_api` | Visualiza os logs da API em tempo real |
| `docker exec -it postgres_container psql -U postgres -d household_expenses` | Acessa o banco via terminal |
| `docker-compose restart` | Reinicia os containers |
| `docker-compose down -v` | Remove os containers e os volumes |

---

## 🛠️ Tecnologias Utilizadas  

- 🚀 **.NET Core** - Backend  
- 🐳 **Docker** - Containerização  
- 🐘 **PostgreSQL** - Banco de dados  
- 🔄 **Docker Compose** - Orquestração de containers  

---

## 🧐 Dúvidas?  

Caso tenha alguma dúvida, sinta-se à vontade para abrir uma **issue** ou entrar em contato.  

🚀 **Happy Coding!** 🎉