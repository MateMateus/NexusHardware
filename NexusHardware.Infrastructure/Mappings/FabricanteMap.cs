using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusHardware.Domain.Entities;

namespace NexusHardware.Infrastructure.Mappings;

public class FabricanteMap : IEntityTypeConfiguration<Fabricante>
{
    public void Configure(EntityTypeBuilder<Fabricante> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Nome)
            .HasMaxLength(100)
            .IsRequired(); // Not Null

        // Configuração do relacionamento 1 : N
        builder.HasMany(f => f.Componentes)
            .WithOne(c => c.Fabricante)
            .HasForeignKey(c => c.FabricanteId)
            .OnDelete(DeleteBehavior.Restrict); // Impede deletar fabricante se ele tiver peças cadastradas (Segurança!)
    }
}