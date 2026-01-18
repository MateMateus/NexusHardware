using NexusHardware.Application.Interfaces;
using NexusHardware.Domain.Entities;

namespace NexusHardware.Application.Services;

public class ComponenteService : IComponenteService
{
    private readonly IComponenteRepository _repository;

    public ComponenteService(IComponenteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Componente>> BuscarTodos()
    {
        return await _repository.ObterTodosAsync();
    }

    public async Task<Componente> Cadastrar(Componente componente)
    {
        // REGRA DE NEGÓCIO: Não aceita preço zerado ou negativo
        if (componente.Preco <= 0)
            throw new Exception("O preço do componente deve ser maior que zero.");

        // Se passou na regra, manda salvar no banco
        return await _repository.AdicionarAsync(componente);
    }
}