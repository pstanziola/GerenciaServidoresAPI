# Etapa 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos de projeto e restaura as dependências
COPY *.sln .
COPY GerenciaServidoresAPI/*.csproj ./GerenciaServidoresAPI/
COPY GerenciaServidoresAPI.Tests/*.csproj ./GerenciaServidoresAPI.Tests/
RUN dotnet restore

# Copia todo o código-fonte e compila a aplicação
COPY . .
WORKDIR /app/GerenciaServidoresAPI
RUN dotnet publish -c Release -o /app/publish

# Etapa 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Expondo a porta da API (ajustável conforme preferir)
EXPOSE 80

# Comando de entrada
ENTRYPOINT ["dotnet", "GerenciaServidoresAPI.dll"]
