using GymMasterSaaS.Domain.Enums;
using GymMasterSaaS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GymMasterSaaS.Infrastructure.BackgroundJobs;

public class DemoAccountCleanupJob
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DemoAccountCleanupJob> _logger;

    public DemoAccountCleanupJob(ApplicationDbContext context, ILogger<DemoAccountCleanupJob> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task ExecuteAsync()
    {
        _logger.LogInformation("Starting demo account cleanup job");

        var expiredDemoTenants = await _context.Tenants
            .Where(t => t.TenantType == TenantType.Demo &&
                       t.ExpireDate.HasValue &&
                       t.ExpireDate.Value < DateTime.UtcNow &&
                       t.IsActive)
            .ToListAsync();

        foreach (var tenant in expiredDemoTenants)
        {
            tenant.IsActive = false;
        }

        if (expiredDemoTenants.Any())
        {
            await _context.SaveChangesAsync();
            _logger.LogInformation("Deactivated {Count} expired demo accounts", expiredDemoTenants.Count);
        }
    }
}
