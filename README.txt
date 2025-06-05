# 🥗 MealPlanner API

API RESTful desenvolvida em **.NET 8 + SQL Server**, com arquitetura baseada em **DDD (Domain-Driven Design)**, para gerenciamento de **planos alimentares por paciente**. Criada como parte de um desafio técnico, com foco em organização, escalabilidade e boas práticas.

---

## ⚙️ Tecnologias e Ferramentas

- ASP.NET Core 8 (Web API)
- C# 12
- Entity Framework Core 8
- SQL Server (via LocalDB ou Docker)
- AutoMapper
- FluentValidation
- Docker / docker-compose (extra)
- Arquitetura baseada em DDD

---

## 🧱 Arquitetura

O projeto está organizado seguindo os princípios do **Domain-Driven Design (DDD)**:

/src
/backend
/MealPlanner.API → Controllers e endpoints
/MealPlanner.Application → Casos de uso, interfaces de serviços
/MealPlanner.Domain → Entidades e lógica de domínio
/MealPlanner.Persistence → Repositórios e DbContext
/shared
/MealPlanner.Communication → DTOs e contratos de comunicação
/MealPlanner.Exception → Exceptions personalizadas
/tests → (planejado para testes unitários)


---

## 📦 Funcionalidades

### ✅ Implementadas

- CRUD de:
  - Pacientes
  - Alimentos
  - Planos alimentares
- Associação de alimentos a planos com porções (em gramas)
- Cálculo de calorias por alimento e total por plano
- Visualização de plano alimentar do paciente no dia (`GET /patients/{id}/mealplans/today`)
- Soft delete de pacientes
- Paginação e filtros simples
- Validações com FluentValidation
- Mapeamento de entidades com AutoMapper
- Tratamento de erros com `ProblemDetails`

---

## ❌ Funcionalidades pendentes

- ❗ **Testes unitários** (não foram implementados a tempo)
- ❗ **Autenticação JWT com roles (`NUTRITIONIST`, `ADMIN`)** — estava prevista, mas não concluída

---

## 🚀 Como executar

### Pré-requisitos

- .NET 8 SDK
- SQL Server ou Docker
- Visual Studio / VS Code

### Passos para rodar

```bash
# Clone o projeto

# Vá para a pasta da API
cd MealPlanner/src/backend/MealPlanner.API

# Execute as migrations
dotnet ef database update --project ../MealPlanner.Persistence --startup-project .

# Rode a aplicação
dotnet run

 Melhorias futuras
 Implementar autenticação JWT e controle por perfil (nutricionista/admin)

 Criar testes unitários com xUnit (≥70% de cobertura)

 Cadastro de nutricionistas e vínculo com pacientes

 Suporte a refeições por período (café, almoço, janta)

 Dashboard de calorias por semana/mês

 Histórico de planos alimentares

 Deploy automatizado com GitHub Actions

 Documentação OpenAPI com exemplos completos
