# API-MultiTenant
Exploração técnica de arquiteturas Multi-Tenant escaláveis utilizando .NET 10. Inclui implementações de isolamento de dados (Database-per-Tenant, Shared Database, IDs ), middlewares customizados e estratégias de resolução de estratégia de tenant.


# 🏢 .NET 10 Multi-Tenant Lab

Este repositório é um laboratório de estudos focado na implementação de sistemas **Multi-Tenant** utilizando as tecnologias mais recentes do ecossistema .NET. O objetivo é explorar diferentes estratégias de isolamento de dados e como gerenciar múltiplos clientes em uma única infraestrutura de forma segura e performática.

## 🚀 Objetivos do Projeto

- Implementar a resolução de Tenants via Hostname, Header e Subdomínio.
- Explorar padrões de isolamento de dados.
- Configurar Migrations automáticas para diferentes contextos.
- Utilizar recursos de performance do .NET 10 e C# 14.

## 🏗️ Estratégias de Arquitetura

O projeto aborda os três principais modelos de isolamento:

1.  **Shared Database (Isolamento Lógico):** Todos os tenants compartilham o mesmo banco de dados e as tabelas possuem uma coluna `TenantId`.
2.  **Shared Database (Isolamento Lógico):** Todos os tenants compartilham o mesmo banco de dados porém separados por schemas.
3.  **Database per Tenant (Isolamento Físico):** Cada tenant possui sua própria string de conexão e banco de dados independente.

## 🛠️ Tecnologias

- **Framework:** .NET 10 (SDK Preview/LTS)
- **Linguagem:** C# 14
- **ORM:** Entity Framework Core 10
- **Banco de Dados:** SQL Server
- **Containerização:** Docker
- **Documentação:** Swagger/OpenAPI

## 📂 Estrutura do Repositório
