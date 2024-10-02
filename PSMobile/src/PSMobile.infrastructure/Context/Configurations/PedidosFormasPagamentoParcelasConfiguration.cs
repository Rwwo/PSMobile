using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class PedidosFormasPagamentoParcelasConfiguration : IEntityTypeConfiguration<PedidosFormasPagamentoParcelas>
{
    public void Configure(EntityTypeBuilder<PedidosFormasPagamentoParcelas> builder)
    {
        builder.ToTable("pedidosformaspagamentoparcelas");

        builder.HasKey(t => t.pedforpagpar_key);

        builder.HasOne(t => t.PedidosFormasPagamento)
            .WithMany(e => e.PedidosFormasPagamentoParcelas)
            .HasForeignKey(e => e.pedforpagpar_pedforpag_key);

    }
}

