using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class PedidosConfiguration : IEntityTypeConfiguration<Pedidos>
{
    public void Configure(EntityTypeBuilder<Pedidos> builder)
    {
        builder.ToTable("pedidos");

        builder.HasKey(t => t.ped_key);

        builder.HasOne(t => t.Funcionario)
            .WithMany(f=>f.Pedidos)
            .HasForeignKey(t => t.ped_fun_key);

        builder.HasOne(t => t.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(t => t.ped_cad_key);

        builder.HasMany(t => t.PedidosFormasPagamento)
            .WithOne(e => e.Pedido)
            .HasForeignKey(e => e.pedforpag_forpag_codigo);

        builder.HasMany(t => t.PedidosItens)
            .WithOne(e => e.Pedido)
            .HasForeignKey(e => e.pedite_ped_key);

    }
}
