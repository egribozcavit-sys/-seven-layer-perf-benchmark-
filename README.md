# -seven-layer-perf-benchmark-
Seven-layer network performance benchmarking framework
# Enterprise 7-Layer Architecture (.NET 8)

Professional enterprise-grade 7-layer architecture implementation with Clean Architecture, CQRS, MediatR, JWT Authentication, and more.

## 🏗️ Architecture Layers

- **Domain**: Core business entities, interfaces, events
- **Application**: Use cases, CQRS commands/queries, DTOs, validators
- **Infrastructure**: External services (Logging, Caching, Email)
- **Persistence**: EF Core, DbContext, Repositories, Unit of Work
- **API**: RESTful controllers, middleware, filters, Swagger
- **Web**: Razor Pages frontend (optional)
- **Shared**: Constants, helpers, extensions, exceptions

## 🚀 Features

- ✅ Clean Architecture
- ✅ CQRS + MediatR
- ✅ Repository + Unit of Work
- ✅ JWT Authentication + Refresh Token
- ✅ Role-Based Authorization
- ✅ FluentValidation
- ✅ AutoMapper
- ✅ Global Exception Handling
- ✅ Soft Delete + Audit Logging
- ✅ Pagination + Filtering + Sorting
- ✅ Health Checks
- ✅ Serilog (Structured Logging)
- ✅ Redis Caching
- ✅ Swagger/OpenAPI Documentation

## 🛠️ Technologies

- .NET 8
- Entity Framework Core 8
- MediatR 12+
- FluentValidation 11+
- AutoMapper 12+
- Serilog
- Redis
- JWT Bearer Authentication
- BCrypt

## 📦 Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server
- Redis (optional)

### Installation

1. Clone the repository
```bash
git clone [https://github.com/yourusername/EnterpriseApp.git](https://github.com/yourusername/EnterpriseApp.git)
cd EnterpriseApp
