using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class FuncionariosConfiguration : IEntityTypeConfiguration<Funcionarios>
{
    public void Configure(EntityTypeBuilder<Funcionarios> builder)
    {
        builder.ToTable("funcionarios");

        builder.HasKey(t => t.fun_key);
    }
}