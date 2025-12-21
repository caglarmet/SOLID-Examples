# GymMasterSaaS

Modern, multi-tenant gym management SaaS platform.

## Project Structure

```
GymMasterSaaS/
├── backend/          # .NET 8 Backend (Clean Architecture)
│   ├── src/
│   │   ├── Api/                  # API Layer (Minimal API)
│   │   ├── Application/          # Application Layer (CQRS)
│   │   ├── Domain/               # Domain Layer (Entities)
│   │   └── Infrastructure/       # Infrastructure Layer (EF Core)
│   └── tests/                    # Unit & Integration Tests
├── frontend/         # Next.js Frontend (Planned)
│   ├── app/
│   ├── components/
│   └── styles/
└── docs/             # Documentation
    ├── requirements/
    └── prompts/
```

## Features

- **Multi-Tenant Architecture**: Complete tenant isolation with Demo/Trial/Paid tiers
- **Clean Architecture**: Well-structured layers with SOLID principles
- **CQRS Pattern**: Using MediatR for command/query separation
- **JWT Authentication**: Secure auth with refresh token support
- **Background Jobs**: Hangfire for automated tasks
- **Comprehensive Logging**: Serilog with Console and Seq sinks

## Tech Stack

### Backend
- .NET 8
- ASP.NET Core Minimal API
- Entity Framework Core 8
- SQL Server
- MediatR (CQRS)
- FluentValidation
- Serilog
- Hangfire
- xUnit

### Frontend (Planned)
- Next.js 14
- TypeScript
- Tailwind CSS
- React Query
- Zustand

## Quick Start

### Backend

```bash
cd backend/src/Api

# Restore packages
dotnet restore

# Update database
dotnet ef database update --project ../Infrastructure

# Run API
dotnet run
```

API will be available at `https://localhost:5001`

- Swagger: `https://localhost:5001/swagger`
- Hangfire: `https://localhost:5001/hangfire`

### Frontend

*Coming soon*

## Documentation

See [docs/](./docs/) folder for detailed documentation:
- [Features](./docs/requirements/FEATURES.md)
- [Backend README](./backend/README.md)
- [Migration Guide](./backend/MIGRATION_GUIDE.md)

## License

MIT

## Author

GymMasterSaaS Team
