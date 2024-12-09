using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class ReceituarioOculosArmacaoConfiguration : IEntityTypeConfiguration<ReceituarioOculosArmacao>
{
    public void Configure(EntityTypeBuilder<ReceituarioOculosArmacao> builder)
    {
        builder.ToTable("receituariooculosarmacao");

        builder.HasKey(t => t.recocuarm_key);
    }
}
