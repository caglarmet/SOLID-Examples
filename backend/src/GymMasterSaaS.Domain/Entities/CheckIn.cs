using GymMasterSaaS.Domain.Common;

namespace GymMasterSaaS.Domain.Entities;

public class CheckIn : BaseEntity
{
    public Guid MemberId { get; set; }
    public DateTime Time { get; set; }
    public string? Notes { get; set; }

    public Member Member { get; set; } = null!;
    public Tenant Tenant { get; set; } = null!;
}
