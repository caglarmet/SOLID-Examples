using GymMasterSaaS.Domain.Common;
using GymMasterSaaS.Domain.Enums;

namespace GymMasterSaaS.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid MemberId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
    public string? Description { get; set; }
    public string? TransactionId { get; set; }

    public Member Member { get; set; } = null!;
    public Tenant Tenant { get; set; } = null!;
}
