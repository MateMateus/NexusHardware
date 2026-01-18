using Microsoft.EntityFrameworkCore;
using NexusHardware.Domain.Entities;

namespace NexusHardware.Infrastructure.Context;

public class NexusDbContext : DbContext
{
    public NexusDbContext(DbContextOptions<NexusDbContext> options) : base(options)
    { }

    // Aqui definimos quais tabelas serão criadas
    public DbSet<Componente> Componentes { get; set; }
    public DbSet<Fabricante> Fabricantes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Essa linha mágica busca todas as configurações de mapeamento (Passo 3) automaticamente
        builder.ApplyConfigurationsFromAssembly(typeof(NexusDbContext).Assembly);
    }
}