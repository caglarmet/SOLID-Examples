using GymMasterSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMasterSaaS.Infrastructure.Persistence.Configurations;

public class CheckInConfiguration : IEntityTypeConfiguration<CheckIn>
{
    public void Configure(EntityTypeBuilder<CheckIn> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Time)
            .IsRequired();

        builder.HasIndex(c => c.TenantId);
        builder.HasIndex(c => c.MemberId);
        builder.HasIndex(c => c.Time);

        builder.HasOne(c => c.Tenant)
            .WithMany()
            .HasForeignKey(c => c.TenantId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Member)
            .WithMany(m => m.CheckIns)
            .HasForeignKey(c => c.MemberId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
