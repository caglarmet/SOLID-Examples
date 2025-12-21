using GymMasterSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMasterSaaS.Infrastructure.Persistence.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(m => m.Email)
            .HasMaxLength(200);

        builder.Property(m => m.Address)
            .HasMaxLength(500);

        builder.HasIndex(m => m.TenantId);
        builder.HasIndex(m => new { m.TenantId, m.Phone });

        builder.HasOne(m => m.Tenant)
            .WithMany(t => t.Members)
            .HasForeignKey(m => m.TenantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
