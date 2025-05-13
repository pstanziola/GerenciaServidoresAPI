# GerenciaServidoresAPI

Sistema de gerenciamento de servidores públicos desenvolvido em .NET 8
utilizando CQRS com MediatR, Entity Framework Core e testes automatizados.

---

## 🧩 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core (Minimal API)
- Entity Framework Core (InMemory)
- CQRS + MediatR
- FluentValidation
- xUnit + FluentAssertions
- Swagger
- Docker (opcional)

---

## 🚀 Como Executar Localmente

1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/GerenciaServidoresAPI.git
cd GerenciaServidoresAPI
```

2. Restaurar as dependências:

```bash
dotnet restore
```

3. Execute a aplicação

```bash
dotnet run --project GerenciaServidoresAPI
```

4. Acesse o Swagger

```bash
http://localhost:5000/swagger
```

🧪 Rodar os Testes

```bash
dotnet test
```

△ ## Para resultados detalhados nos testes rodar os testes usando o C# Dev Kit ##

🐳 Executar com Docker (opcional)

```bash
docker build -t gerenciaservidoresapi .
docker run -p 5000:80 gerenciaservidoresapi
```

✅ Como usar 🐳

1. Construir a imagem Docker:
   docker build -t gerenciaservidoresapi
2. Rodar o container:
   docker run -p 5000:80 gerenciaservidoresapi
3. Acessar a API via navegador:
   http://localhost:5000/swagger

### Caso o migrations não funcione, usar o path completo:

~/.dotnet/tools/dotnet-ef migrations add InitialCreate --project GerenciaServidoresAPI --startup-project GerenciaServidoresAPI
~/.dotnet/tools/dotnet-ef database update --project GerenciaServidoresAPI --startup-project GerenciaServidoresAPI
~/.dotnet/tools/dotnet-ef migrations add SeedOrgaosAndLotacoes
~/.dotnet/tools/dotnet-ef database update

Endpoints Disponíveis:

- Listar servidores
  GET /api/servidores
  Query Params (opcionais): nome,orgao,lotacao

- Cadastrar servidor
  POST /api/servidores
  Body:
  {
  "nome": "João da Silva",
  "telefone": "11999999999",
  "email": "joao@exemplo.com",
  "orgaoId": "11111111-1111-1111-1111-111111111111",
  "lotacaoId": "22222222-2222-2222-2222-222222222222",
  "sala": "B101"
  }

- Atualizar servidor
  PUT /api/servidores/{id}
  Body:
  {
  "id": "GUID_DO_SERVIDOR",
  "nome": "João Atualizado",
  "telefone": "1188888888",
  "email": "joao.novo@exemplo.com",
  "orgaoId": "11111111-1111-1111-1111-111111111111",
  "lotacaoId": "22222222-2222-2222-2222-222222222222",
  "sala": "C202",
  "ativo": true
  }

- Inativar servidor (exclusão lógica)
  DELETE /api/servidores/{id}
