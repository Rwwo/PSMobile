using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class UfsConfiguration : IEntityTypeConfiguration<Ufs>
{
    public void Configure(EntityTypeBuilder<Ufs> builder)
    {
        builder.ToTable("ufs");

        builder.HasKey(t => t.ufs_codigo);

        builder.HasMany(t => t.Cidades)
            .WithOne(e => e.Ufs)
            .HasForeignKey(e => e.cid_ufs_codigo);
    }
}
