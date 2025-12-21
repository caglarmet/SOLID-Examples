using GymMasterSaaS.Domain.Common;
using GymMasterSaaS.Domain.Enums;

namespace GymMasterSaaS.Domain.Entities;

public class Membership : BaseEntity
{
    public Guid MemberId { get; set; }
    public Guid PlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? RemainingEntries { get; set; }
    public MembershipStatus Status { get; set; }
    public DateTime? FrozenDate { get; set; }
    public string? Notes { get; set; }

    public Member Member { get; set; } = null!;
    public MembershipPlan Plan { get; set; } = null!;
    public Tenant Tenant { get; set; } = null!;
}
