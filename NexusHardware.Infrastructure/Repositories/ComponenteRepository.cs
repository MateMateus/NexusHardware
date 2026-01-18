using Microsoft.EntityFrameworkCore;
using NexusHardware.Application.Interfaces;
using NexusHardware.Domain.Entities;
using NexusHardware.Infrastructure.Context;

namespace NexusHardware.Infrastructure.Repositories;

public class ComponenteRepository : IComponenteRepository
{
    private readonly NexusDbContext _context;

    public ComponenteRepository(NexusDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Componente>> ObterTodosAsync()
    {
        // O Include carrega os dados do Fabricante junto com o Componente
        return await _context.Componentes
            .Include(c => c.Fabricante)
            .AsNoTracking() // Melhora performance para leitura
            .ToListAsync();
    }

    public async Task<Componente?> ObterPorIdAsync(int id)
    {
        return await _context.Componentes
            .Include(c => c.Fabricante)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Componente> AdicionarAsync(Componente componente)
    {
        _context.Componentes.Add(componente);
        await _context.SaveChangesAsync();
        return componente;
    }

    public async Task<Componente> AtualizarAsync(Componente componente)
    {
        _context.Componentes.Update(componente);
        await _context.SaveChangesAsync();
        return componente;
    }

    public async Task DeletarAsync(Componente componente)
    {
        _context.Componentes.Remove(componente);
        await _context.SaveChangesAsync();
    }
}