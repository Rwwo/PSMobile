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

        builder.HasMany(x => x.ProdutosImagens)
           .WithOne(m => m.Produtos)
           .HasForeignKey(c => c.proima_pro_codigo)
            .HasPrincipalKey(p => p.pro_codigo);

    }
}
