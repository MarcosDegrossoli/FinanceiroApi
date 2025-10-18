# Estágio 1: Build (Compilação)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de solução (.sln) e restaura dependências
COPY *.sln .
COPY Financeiro.Domain/*.csproj ./Financeiro.Domain/
COPY Financeiro.Infrastructure/*.csproj ./Financeiro.Infrastructure/
COPY Financeiro.Services/*.csproj ./Financeiro.Services/
COPY FinanceiroApi/*.csproj ./FinanceiroApi/

RUN dotnet restore

# Copia todos os arquivos de projeto
COPY . .
WORKDIR /src/FinanceiroApi

# Compila e publica o projeto
RUN dotnet publish FinanceiroApi.csproj -c Release -o /app/publish

# Estágio 2: Final (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

EXPOSE 8080

# Copia a aplicação compilada
COPY --from=build /app/publish .

# Define o ponto de entrada para a aplicação
ENTRYPOINT ["dotnet", "FinanceiroApi.dll"]
