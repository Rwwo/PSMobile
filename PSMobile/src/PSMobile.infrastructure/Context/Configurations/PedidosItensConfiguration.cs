using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class PedidosItensConfiguration : IEntityTypeConfiguration<PedidosItens>
{
    public void Configure(EntityTypeBuilder<PedidosItens> builder)
    {
        builder.ToTable("pedidositens");

        builder.HasKey(t => t.pedite_key);

        builder.HasOne(t => t.Pedido)
            .WithMany(c => c.PedidosItens)
            .HasForeignKey(t => t.pedite_ped_key);

        builder.HasOne(t => t.Produto)
            .WithMany()
            .HasForeignKey(t => t.pedite_pro_codigo)
            .HasPrincipalKey(p => p.pro_codigo);

    }
}
