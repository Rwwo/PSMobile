using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class OrdensServicosItensConfiguration : IEntityTypeConfiguration<OrdensServicosItens>
{
    public void Configure(EntityTypeBuilder<OrdensServicosItens> builder)
    {
        builder.ToTable("ordensservicositens");

        builder.HasKey(t => t.ordserite_key);

        builder.HasOne(t => t.OrdensServicos)
            .WithMany(c => c.OrdensServicosItens)
            .HasForeignKey(t => t.ordserite_ordser_key);

        builder.HasOne(t => t.Produto)
            .WithMany()
            .HasForeignKey(t => t.ordserite_pro_codigo)
            .HasPrincipalKey(p => p.pro_codigo);

    }
}