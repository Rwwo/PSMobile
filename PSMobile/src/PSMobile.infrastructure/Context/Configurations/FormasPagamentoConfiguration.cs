using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class FormasPagamentoConfiguration : IEntityTypeConfiguration<FormasPagamento>
{
    public void Configure(EntityTypeBuilder<FormasPagamento> builder)
    {
        builder.ToTable("formaspagamento");

        builder.HasKey(t => t.forpag_codigo);

        builder.HasMany(t => t.PedidosFormasPagamento)
            .WithOne(e => e.FormaPagamento)
            .HasForeignKey(e => e.pedforpag_forpag_codigo);


    }
}