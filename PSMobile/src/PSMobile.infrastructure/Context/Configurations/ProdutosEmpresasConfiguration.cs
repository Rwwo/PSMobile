using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class ProdutosEmpresasConfiguration : IEntityTypeConfiguration<ProdutosEmpresas>
{
    public void Configure(EntityTypeBuilder<ProdutosEmpresas> builder)
    {
        builder.ToTable("produtosempresas");

        builder.HasKey(t => t.proemp_key);

        builder.HasOne(t => t.Produto)
            .WithOne(c => c.ProdutosEmpresas)
            .HasForeignKey<ProdutosEmpresas>(t => t.proemp_pro_key);
    }
}

