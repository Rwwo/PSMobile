using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class TiposMateriaisConfiguration : IEntityTypeConfiguration<TiposMateriais>
{
    public void Configure(EntityTypeBuilder<TiposMateriais> builder)
    {
        builder.ToTable("tiposmateriais");

        builder.HasKey(t => t.tipmat_key);
    }
}