using GymMasterSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMasterSaaS.Infrastructure.Persistence.Configurations;

public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Status)
            .IsRequired();

        builder.Property(m => m.StartDate)
            .IsRequired();

        builder.Property(m => m.EndDate)
            .IsRequired();

        builder.HasIndex(m => m.TenantId);
        builder.HasIndex(m => m.MemberId);
        builder.HasIndex(m => m.Status);

        builder.HasOne(m => m.Tenant)
            .WithMany()
            .HasForeignKey(m => m.TenantId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.Member)
            .WithMany(mb => mb.Memberships)
            .HasForeignKey(m => m.MemberId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.Plan)
            .WithMany(p => p.Memberships)
            .HasForeignKey(m => m.PlanId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
