using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class PdvsConfiguration : IEntityTypeConfiguration<Pdvs>
{
    public void Configure(EntityTypeBuilder<Pdvs> builder)
    {
        builder.ToTable("pdvs");

        builder.HasKey(t => t.pdv_key);
    }
}
