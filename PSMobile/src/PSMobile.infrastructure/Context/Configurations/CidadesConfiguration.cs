using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class CidadesConfiguration : IEntityTypeConfiguration<Cidades>
{
    public void Configure(EntityTypeBuilder<Cidades> builder)
    {
        builder.ToTable("cidades");

        builder.HasKey(t => t.cid_key);

        builder.HasOne(t => t.Ufs)
            .WithMany(c => c.Cidades)
            .HasForeignKey(t => t.cid_ufs_codigo);
    }
}
