using GymMasterSaaS.Domain.Common;

namespace GymMasterSaaS.Domain.Entities;

public class MembershipPlan : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DurationDays { get; set; }
    public int? MaxEntries { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public Tenant Tenant { get; set; } = null!;
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}
