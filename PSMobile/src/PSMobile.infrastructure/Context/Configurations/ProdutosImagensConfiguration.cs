using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class ProdutosImagensConfiguration : IEntityTypeConfiguration<ProdutosImagens>
{
    public void Configure(EntityTypeBuilder<ProdutosImagens> builder)
    {
        builder.ToTable("produtosimagens");

        builder.HasKey(t => t.proima_key);


    }
}
