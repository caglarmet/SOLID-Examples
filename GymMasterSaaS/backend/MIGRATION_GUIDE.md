# Database Migration Guide

## Prerequisites

- .NET 8 SDK installed
- SQL Server running
- Update connection strings in `appsettings.json`

## Create Initial Migration

Navigate to the API project and create the initial migration:

```bash
cd src/GymMasterSaaS.Api

# Add EF Core tools if not already installed
dotnet tool install --global dotnet-ef

# Create initial migration
dotnet ef migrations add InitialCreate --project ../GymMasterSaaS.Infrastructure --startup-project .

# Apply migration to database
dotnet ef database update --project ../GymMasterSaaS.Infrastructure --startup-project .
```

## Create Hangfire Database

Hangfire requires a separate database. Run the following SQL script or let Hangfire auto-create it:

```sql
CREATE DATABASE GymMasterSaaS_Hangfire;
```

## Verify Database

After running migrations, verify these tables exist:

### Main Database (GymMasterSaaS)
- Tenants
- Users
- Members
- MembershipPlans
- Memberships
- CheckIns
- Payments

### Hangfire Database (GymMasterSaaS_Hangfire)
- HangFire.Job
- HangFire.Server
- HangFire.State
- etc.

## Future Migrations

When you make changes to entities:

```bash
cd src/GymMasterSaaS.Api

# Add new migration
dotnet ef migrations add MigrationName --project ../GymMasterSaaS.Infrastructure --startup-project .

# Apply migration
dotnet ef database update --project ../GymMasterSaaS.Infrastructure --startup-project .
```

## Rollback Migration

```bash
# Rollback to previous migration
dotnet ef database update PreviousMigrationName --project ../GymMasterSaaS.Infrastructure --startup-project .

# Remove last migration (if not applied)
dotnet ef migrations remove --project ../GymMasterSaaS.Infrastructure --startup-project .
```

## Connection String Examples

### SQL Server (Windows Authentication)
```json
"Server=localhost;Database=GymMasterSaaS;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
```

### SQL Server (SQL Authentication)
```json
"Server=localhost;Database=GymMasterSaaS;User Id=sa;Password=YourPassword;TrustServerCertificate=True;MultipleActiveResultSets=true"
```

### SQL Server (Docker)
```json
"Server=localhost,1433;Database=GymMasterSaaS;User Id=sa;Password=YourStrong@Password;TrustServerCertificate=True;MultipleActiveResultSets=true"
```

## Troubleshooting

### Error: "Build failed"
Make sure all projects can build successfully before running migrations:
```bash
dotnet build
```

### Error: "No DbContext found"
Ensure you're running the command from the API project and specifying the Infrastructure project.

### Error: "Connection string not found"
Verify `appsettings.json` has the correct connection string configuration.
