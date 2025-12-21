using GymMasterSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymMasterSaaS.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Tenant> Tenants { get; }
    DbSet<User> Users { get; }
    DbSet<Member> Members { get; }
    DbSet<MembershipPlan> MembershipPlans { get; }
    DbSet<Membership> Memberships { get; }
    DbSet<CheckIn> CheckIns { get; }
    DbSet<Payment> Payments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
