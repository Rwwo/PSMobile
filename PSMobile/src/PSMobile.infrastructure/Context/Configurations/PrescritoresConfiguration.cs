using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class PrescritoresConfiguration : IEntityTypeConfiguration<Prescritores>
{
    public void Configure(EntityTypeBuilder<Prescritores> builder)
    {
        builder.ToTable("prescritores");

        builder.HasKey(t => t.pre_key);
    }
}
