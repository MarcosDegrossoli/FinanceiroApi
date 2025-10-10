# 🏦 FinanceiroApi

O **`FinanceiroApi`** é uma API RESTful desenvolvida em .NET 8.0 para gerenciar dados financeiros (usuários, bancos, contas e lançamentos). O projeto utiliza uma **arquitetura limpa e em camadas baseada no Domain-Driven Design (DDD)** para garantir código modular, testável e de fácil manutenção.

---

## 🛠️ Tecnologias Principais

| Categoria | Tecnologia | Versão |
| :--- | :--- | :--- |
| **Plataforma** | .NET 8.0 Web API | LTS |
| **Banco de Dados** | PostgreSQL | — |
| **ORM** | Entity Framework Core | — |
| **Provedor DB** | Npgsql | — |
| **Arquitetura** | DDD em Camadas | — |
| **Testes** | xUnit e Moq | — |

---

## 📐 Arquitetura do Projeto (DDD em Camadas)

O projeto é dividido em quatro camadas principais:

1.  **`FinanceiroApi.Application`**: **Camada de Apresentação/API**. Contém os **Controllers**, a configuração de injeção de dependência (`Program.cs`) e o Swagger. É a porta de entrada para todas as requisições HTTP.
2.  **`Financeiro.Services`**: **Camada de Aplicação/Serviço**. Contém a lógica de negócio (validações, orquestração e regras de negócio).
3.  **`Financeiro.Infrastructure`**: **Camada de Infraestrutura**. Responsável por toda a parte técnica, como a classe **`FinanceiroDbContext`**, as **Migrations** e os **Repositories** (acesso direto ao PostgreSQL).
4.  **`Financeiro.Domain`**: **Camada de Domínio**. O coração da aplicação, contendo apenas as **Entidades** (`Usuario`, `Conta`, `Banco`, etc.) e as regras de negócio puras.

---

## 🚀 Como Rodar o Projeto

### Pré-requisitos

* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [PostgreSQL](https://www.postgresql.org/download/)
* Terminal com acesso ao comando `dotnet`

### 1. Configurar o Banco de Dados

1.  No arquivo **`appsettings.json`** (em `FinanceiroApi.Application`), atualize a string de conexão:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Port=5432;Database=financeiro_db;Username=postgres;Password=SUA_SENHA"
    }
    ```
2.  Abra o terminal na raiz da solução (`FinanceiroApi/`) e aplique as migrações:
    ```bash
    # Cria/Atualiza o banco de dados com a migração InitialCreate
    dotnet ef database update --project Financeiro.Infrastructure --startup-project FinanceiroApi.Application
    ```

### 2. Executar a API

1.  No terminal, vá para o diretório do projeto principal:
    ```bash
    cd FinanceiroApi.Application
    ```
2.  Rode a aplicação:
    ```bash
    dotnet run
    ```

A API estará acessível em **`https://localhost:PORTA_DO_SEU_PROJETO/swagger`**.

---
