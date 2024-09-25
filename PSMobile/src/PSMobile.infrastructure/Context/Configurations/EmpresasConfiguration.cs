using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class EmpresasConfiguration : IEntityTypeConfiguration<Empresas>
{
    public void Configure(EntityTypeBuilder<Empresas> builder)
    {
        builder.ToTable("empresas");

        builder.HasKey(x => x.emp_key);
    }
}
