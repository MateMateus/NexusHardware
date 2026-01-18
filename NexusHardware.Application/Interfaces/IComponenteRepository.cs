using NexusHardware.Domain.Entities;

namespace NexusHardware.Application.Interfaces;

public interface IComponenteRepository
{
    // 1. Contrato: Buscar tudo (assíncrono)
    Task<IEnumerable<Componente>> ObterTodosAsync();

    // 2. Contrato: Buscar um só pelo ID
    Task<Componente?> ObterPorIdAsync(int id);

    // 3. Contrato: Adicionar novo
    Task<Componente> AdicionarAsync(Componente componente);

    // 4. Contrato: Atualizar existente
    Task<Componente> AtualizarAsync(Componente componente);

    // 5. Contrato: Remover
    Task DeletarAsync(Componente componente);
}