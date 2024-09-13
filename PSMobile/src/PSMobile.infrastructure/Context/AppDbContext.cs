using System.Reflection;

using Microsoft.EntityFrameworkCore;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> contextOptions)
        : base(contextOptions)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    public DbSet<Cadastros> Cadastros { get; set; }

    private const string CONST_DATA_CADASTRO = "DataCadastro";
    private const string CONST_DATA_MODIFICACAO = "DataModificacao";


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        foreach (var entry in ChangeTracker
                                .Entries()
                                .Where(entry => entry.Entity.GetType().GetProperty(CONST_DATA_CADASTRO) != null))
        {

            if (entry.State == EntityState.Added)
                entry.Property(CONST_DATA_CADASTRO).CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
            {
                entry.Property(CONST_DATA_CADASTRO).IsModified = false;
                entry.Property(CONST_DATA_MODIFICACAO).CurrentValue = DateTime.Now;
            }


        }

        return await base.SaveChangesAsync(cancellationToken);
    }

}
