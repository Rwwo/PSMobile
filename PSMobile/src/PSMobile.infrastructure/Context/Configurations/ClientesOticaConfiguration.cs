using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;

public class ClientesOticaConfiguration : IEntityTypeConfiguration<ClientesOtica>
{
    public void Configure(EntityTypeBuilder<ClientesOtica> builder)
    {
        builder.ToTable("clientesotica");

        builder.HasKey(t => t.clioti_key);
    }
}
