using GymMasterSaaS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GymMasterSaaS.Infrastructure.BackgroundJobs;

public class InactiveMemberNotificationJob
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<InactiveMemberNotificationJob> _logger;

    public InactiveMemberNotificationJob(ApplicationDbContext context, ILogger<InactiveMemberNotificationJob> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task ExecuteAsync()
    {
        _logger.LogInformation("Starting inactive member notification job");

        var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);

        var inactiveMembers = await _context.Members
            .Where(m => m.IsActive &&
                       !m.CheckIns.Any(c => c.Time >= thirtyDaysAgo))
            .Select(m => new { m.Id, m.FullName, m.Phone, m.Email })
            .ToListAsync();

        _logger.LogInformation("Found {Count} inactive members (no check-in in 30 days). Notification mock prepared.",
            inactiveMembers.Count);
    }
}
