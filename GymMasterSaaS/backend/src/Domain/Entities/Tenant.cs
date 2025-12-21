using GymMasterSaaS.Domain.Enums;

namespace GymMasterSaaS.Domain.Entities;

public class Tenant
{
    public Guid TenantId { get; set; }
    public string Name { get; set; } = string.Empty;
    public TenantType TenantType { get; set; }
    public DateTime? ExpireDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Member> Members { get; set; } = new List<Member>();
    public ICollection<MembershipPlan> MembershipPlans { get; set; } = new List<MembershipPlan>();
}
