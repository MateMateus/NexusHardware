namespace NexusHardware.Domain.Entities;

public class Fabricante
{
    public int Id { get; private set; }
    public string Nome { get; private set; }

    // Relação: Um fabricante tem VÁRIOS componentes
    public ICollection<Componente> Componentes { get; private set; }

    protected Fabricante() { }

    public Fabricante(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("Nome do fabricante é obrigatório.");

        Nome = nome;
        Componentes = new List<Componente>();
    }
}