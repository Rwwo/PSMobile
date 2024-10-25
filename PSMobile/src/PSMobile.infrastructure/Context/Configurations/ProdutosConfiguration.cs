using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class ProdutosConfiguration : IEntityTypeConfiguration<Produtos>
{
    public void Configure(EntityTypeBuilder<Produtos> builder)
    {
        builder.ToTable("produtos");

        builder.HasKey(t => t.pro_key);

    }
}
