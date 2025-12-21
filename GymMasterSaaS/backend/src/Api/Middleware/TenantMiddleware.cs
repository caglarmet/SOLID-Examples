using GymMasterSaaS.Infrastructure.Persistence;
using GymMasterSaaS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace GymMasterSaaS.Api.Middleware;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantProvider tenantProvider, ApplicationDbContext dbContext)
    {
        var path = context.Request.Path.Value?.ToLower() ?? "";

        if (path.Contains("/auth/register") || path.Contains("/swagger") || path.Contains("/hangfire"))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue("X-Tenant", out var tenantIdValue))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new { error = "X-Tenant header is required" });
            return;
        }

        if (!Guid.TryParse(tenantIdValue, out var tenantId))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new { error = "Invalid X-Tenant format" });
            return;
        }

        var tenant = await dbContext.Tenants
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TenantId == tenantId && t.IsActive);

        if (tenant == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new { error = "Invalid or inactive tenant" });
            return;
        }

        tenantProvider.SetTenantId(tenantId);

        await _next(context);
    }
}
