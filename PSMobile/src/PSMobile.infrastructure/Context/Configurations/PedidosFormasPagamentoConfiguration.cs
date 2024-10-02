using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class PedidosFormasPagamentoConfiguration : IEntityTypeConfiguration<PedidosFormasPagamento>
{
    public void Configure(EntityTypeBuilder<PedidosFormasPagamento> builder)
    {
        builder.ToTable("pedidosformaspagamento");

        builder.HasKey(t => t.pedforpag_key);

        builder.HasOne(t => t.Pedido)
            .WithMany(e => e.PedidosFormasPagamento)
            .HasForeignKey(e => e.pedforpag_ped_key);

        builder.HasOne(t => t.FormaPagamento)
            .WithMany(e => e.PedidosFormasPagamento)
            .HasForeignKey(e => e.pedforpag_forpag_codigo);

    }
}

