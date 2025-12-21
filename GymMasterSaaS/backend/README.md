# GymMasterSaaS Backend

Modern, multi-tenant gym management SaaS platform built with .NET 8, Clean Architecture, and CQRS pattern.

## Features

- **Multi-Tenant Architecture**: Complete tenant isolation with X-Tenant header validation
- **Clean Architecture**: Well-structured layers (Domain, Application, Infrastructure, API)
- **CQRS Pattern**: Using MediatR for command/query separation
- **JWT Authentication**: Secure authentication with refresh token support
- **Background Jobs**: Hangfire for recurring tasks (membership expiration, cleanup, notifications)
- **Logging**: Serilog with Console and Seq sinks
- **Validation**: FluentValidation for input validation
- **Global Exception Handling**: Centralized error management

## Tech Stack

- .NET 8
- ASP.NET Core Minimal API
- Entity Framework Core 8
- SQL Server
- MediatR
- FluentValidation
- AutoMapper
- Serilog
- Hangfire
- xUnit (for testing)

## Project Structure

```
backend/
├── src/
│   ├── GymMasterSaaS.Api/           # API Layer (Minimal API)
│   ├── GymMasterSaaS.Application/   # Application Layer (CQRS, MediatR)
│   ├── GymMasterSaaS.Domain/        # Domain Layer (Entities, Enums)
│   └── GymMasterSaaS.Infrastructure/ # Infrastructure Layer (EF Core, Persistence)
└── tests/
    ├── GymMasterSaaS.Api.Tests/
    ├── GymMasterSaaS.Application.Tests/
    ├── GymMasterSaaS.Domain.Tests/
    └── GymMasterSaaS.Infrastructure.Tests/
```

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server
- (Optional) Seq for log aggregation

### Database Setup

1. Update connection strings in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GymMasterSaaS;...",
    "HangfireConnection": "Server=localhost;Database=GymMasterSaaS_Hangfire;..."
  }
}
```

2. Run EF Core migrations:
```bash
cd src/GymMasterSaaS.Api
dotnet ef database update
```

### Run the Application

```bash
cd src/GymMasterSaaS.Api
dotnet run
```

The API will be available at `https://localhost:5001` (or the port specified in launchSettings.json)

### Swagger UI

Navigate to `https://localhost:5001/swagger` for API documentation and testing.

### Hangfire Dashboard

Navigate to `https://localhost:5001/hangfire` to view background jobs.

## API Endpoints

### Authentication

- `POST /auth/register` - Register new tenant and owner user
- `POST /auth/login` - Login with email and password
- `POST /auth/refresh-token` - Refresh access token

### Headers

All endpoints (except `/auth/register`) require the `X-Tenant` header:
```
X-Tenant: {tenant-guid}
```

## Domain Entities

- **Tenant**: Multi-tenant organization (Demo/Trial/Paid)
- **User**: System users (Owner/Staff/Trainer/Member roles)
- **Member**: Gym members
- **MembershipPlan**: Subscription plans
- **Membership**: Active memberships
- **CheckIn**: Member check-in records
- **Payment**: Payment transactions

## Multi-Tenant Features

### Tenant Types

- **Demo**: Limited features, auto-expires
- **Trial**: 14-day trial period
- **Paid**: Full access

### Tenant Isolation

- Global query filter on all entities
- Automatic TenantId assignment on entity creation
- Middleware validation for every request

## Background Jobs

- **Membership Expiration Check**: Daily job to expire outdated memberships
- **Demo Account Cleanup**: Daily job to deactivate expired demo accounts
- **Inactive Member Notification**: Weekly job to identify inactive members (30+ days)

## Configuration

### JWT Settings

Edit `appsettings.json`:
```json
{
  "Jwt": {
    "Key": "YourSecretKey...",
    "Issuer": "GymMasterSaaS",
    "Audience": "GymMasterSaaSUsers"
  }
}
```

### Serilog/Seq

```json
{
  "Seq": {
    "Url": "http://localhost:5341"
  }
}
```

## Development

### Adding a New Feature

1. Create entity in `Domain/Entities`
2. Add DbSet to `ApplicationDbContext`
3. Create CQRS commands/queries in `Application/Features`
4. Add validators with FluentValidation
5. Create endpoints in `Api/Endpoints`

### Running Tests

```bash
dotnet test
```

## Security

- Password hashing with PBKDF2
- JWT with refresh tokens
- Global exception middleware
- Tenant validation middleware
- Input validation with FluentValidation

## License

MIT

## Author

GymMasterSaaS Team
