using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class OrdensServicosConfiguration : IEntityTypeConfiguration<OrdensServicos>
{
    public void Configure(EntityTypeBuilder<OrdensServicos> builder)
    {
        builder.ToTable("ordensservicos");

        builder.HasKey(t => t.ordser_key);

        builder.HasOne(t => t.Funcionario)
             .WithMany(f => f.OrdensServicos)
             .HasForeignKey(t => t.ordser_fun_key);

        builder.HasOne(t => t.Cliente)
             .WithMany(c => c.OrdensServicos)
             .HasForeignKey(t => t.ordser_cad_key);

        builder.HasMany(t => t.OrdensServicosItens)
            .WithOne(e => e.OrdensServicos)
            .HasForeignKey(e => e.ordserite_ordser_key);

        builder.HasOne(t => t.Empresa)
            .WithMany()
            .HasForeignKey(e => e.ordser_emp_key);

    }
}