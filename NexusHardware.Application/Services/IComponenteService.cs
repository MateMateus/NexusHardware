using NexusHardware.Domain.Entities;

namespace NexusHardware.Application.Services;

public interface IComponenteService
{
    Task<IEnumerable<Componente>> BuscarTodos();
    Task<Componente> Cadastrar(Componente componente);
}