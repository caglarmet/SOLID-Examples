using GymMasterSaaS.Domain.Enums;
using GymMasterSaaS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GymMasterSaaS.Infrastructure.BackgroundJobs;

public class MembershipExpirationJob
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<MembershipExpirationJob> _logger;

    public MembershipExpirationJob(ApplicationDbContext context, ILogger<MembershipExpirationJob> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task ExecuteAsync()
    {
        _logger.LogInformation("Starting membership expiration check job");

        var expiredMemberships = await _context.Memberships
            .Where(m => m.Status == MembershipStatus.Active && m.EndDate < DateTime.UtcNow)
            .ToListAsync();

        foreach (var membership in expiredMemberships)
        {
            membership.Status = MembershipStatus.Expired;
        }

        if (expiredMemberships.Any())
        {
            await _context.SaveChangesAsync();
            _logger.LogInformation("Expired {Count} memberships", expiredMemberships.Count);
        }
    }
}
