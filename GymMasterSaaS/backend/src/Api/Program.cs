using System.Text;
using GymMasterSaaS.Api.Endpoints;
using GymMasterSaaS.Api.Middleware;
using GymMasterSaaS.Api.Services;
using GymMasterSaaS.Application;
using GymMasterSaaS.Application.Common.Interfaces;
using GymMasterSaaS.Infrastructure.BackgroundJobs;
using GymMasterSaaS.Infrastructure.Persistence;
using GymMasterSaaS.Infrastructure.Services;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .WriteTo.Seq(builder.Configuration["Seq:Url"] ?? "http://localhost:5341")
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
builder.Services.AddScoped<ITenantProvider, TenantProvider>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "YourSuperSecretKeyForJWTTokenGenerationMinimum32Characters!"))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection")));

builder.Services.AddHangfireServer();

builder.Services.AddScoped<MembershipExpirationJob>();
builder.Services.AddScoped<DemoAccountCleanupJob>();
builder.Services.AddScoped<InactiveMemberNotificationJob>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<TenantMiddleware>();

app.UseSerilogRequestLogging();

app.UseAuthentication();
app.UseAuthorization();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() }
});

RecurringJob.AddOrUpdate<MembershipExpirationJob>(
    "membership-expiration-check",
    job => job.ExecuteAsync(),
    Cron.Daily);

RecurringJob.AddOrUpdate<DemoAccountCleanupJob>(
    "demo-account-cleanup",
    job => job.ExecuteAsync(),
    Cron.Daily);

RecurringJob.AddOrUpdate<InactiveMemberNotificationJob>(
    "inactive-member-notification",
    job => job.ExecuteAsync(),
    Cron.Weekly);

app.MapAuthEndpoints();

app.MapGet("/", () => Results.Ok(new
{
    name = "GymMasterSaaS API",
    version = "1.0.0",
    status = "Running"
}))
.WithName("HealthCheck")
.WithTags("General");

Log.Information("GymMasterSaaS API Starting...");

app.Run();

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}
