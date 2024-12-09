using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class ReceituarioOculosConfiguration : IEntityTypeConfiguration<ReceituarioOculos>
{
    public void Configure(EntityTypeBuilder<ReceituarioOculos> builder)
    {
        builder.ToTable("receituariooculos");

        builder.HasKey(t => t.recocu_key);

        builder.HasOne(t => t.Funcionarios)
            .WithOne()
            .HasForeignKey<ReceituarioOculos>(t => t.recocu_fun_key);

        builder.HasOne(t => t.Prescritores)
            .WithOne()
            .HasForeignKey<ReceituarioOculos>(t => t.recocu_pre_key);

        builder.HasOne(t => t.ClientesOtica)
            .WithOne()
            .HasForeignKey<ReceituarioOculos>(t => t.recocu_clioti_key);

        builder.HasOne(t => t.Cadastros)
            .WithOne()
            .HasForeignKey<ReceituarioOculos>(t => t.recocu_cad_key);

        builder.HasOne(t => t.TiposMateriais)
            .WithOne()
            .HasForeignKey<ReceituarioOculos>(t => t.recocu_tipmat_key);


        builder.HasMany(t => t.ReceituarioOculosAnexos)
            .WithOne(c => c.ReceituarioOculos)
            .HasForeignKey(t => t.recocuane_recocu_key);

        builder.HasMany(t => t.ReceituarioOculosArmacao)
            .WithOne(c => c.ReceituarioOculos)
            .HasForeignKey(t => t.recocuarm_recocu_key);

        builder.HasMany(t => t.ReceituarioOculosArmacaoMaterial)
            .WithOne(c => c.ReceituarioOculos)
            .HasForeignKey(t => t.recocuarmmat_recocu_key);

    }
}
