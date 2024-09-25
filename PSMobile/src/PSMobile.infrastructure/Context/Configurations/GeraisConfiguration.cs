using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class GeraisConfiguration : IEntityTypeConfiguration<Gerais>
{
    public void Configure(EntityTypeBuilder<Gerais> builder)
    {
        builder.ToTable("gerais");

        builder.HasNoKey();

        builder.HasOne(t => t.Empresa)
            .WithOne()
            .HasForeignKey<Gerais>(c => c.ger_emp_key);
    }
}
