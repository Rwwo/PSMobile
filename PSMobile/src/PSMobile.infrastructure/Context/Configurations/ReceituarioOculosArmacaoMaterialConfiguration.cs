using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class ReceituarioOculosArmacaoMaterialConfiguration : IEntityTypeConfiguration<ReceituarioOculosArmacaoMaterial>
{
    public void Configure(EntityTypeBuilder<ReceituarioOculosArmacaoMaterial> builder)
    {
        builder.ToTable("receituariooculosarmacaomaterial");

        builder.HasKey(t => t.recocuarmmat_key);

        builder.HasOne(t => t.TiposMateriais)
           .WithOne()
           .HasForeignKey<ReceituarioOculosArmacaoMaterial>(t => t.recocuarmmat_tipmat_key);
    }
}
