using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusHardware.Domain.Entities;

namespace NexusHardware.Infrastructure.Mappings;

public class ComponenteMap : IEntityTypeConfiguration<Componente>
{
    public void Configure(EntityTypeBuilder<Componente> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Descricao)
            .HasMaxLength(500);

        // Configuração importante para dinheiro (10 dígitos, 2 decimais)
        builder.Property(c => c.Preco)
            .HasPrecision(10, 2);
    }
}