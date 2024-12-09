using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class ReceituarioOculosAnexosConfiguration : IEntityTypeConfiguration<ReceituarioOculosAnexos>
{
    public void Configure(EntityTypeBuilder<ReceituarioOculosAnexos> builder)
    {
        builder.ToTable("receituariooculosanexos");

        builder.HasKey(t => t.recocuane_key);
    }
}
