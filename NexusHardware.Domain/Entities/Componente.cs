namespace NexusHardware.Domain.Entities;

public class Componente
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = null!;
    public string Descricao { get; private set; } = null!;
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }
    public string ImageUrl { get; private set; }
    public bool Ativo { get; private set; }

    // --- NOVO: Chave Estrangeira (Ligação com Fabricante) ---
    public int FabricanteId { get; private set; }
    public Fabricante Fabricante { get; private set; }

    protected Componente() { }

    // Atualizei o construtor para exigir o fabricanteId
    public Componente(string nome, string descricao, decimal preco, int estoque, string imageUrl, int fabricanteId)
    {
        ValidateDomain(nome, preco, estoque);
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
        ImageUrl = imageUrl;
        FabricanteId = fabricanteId; // Guardamos o ID aqui
        Ativo = true;
    }

    public void AtualizarEstoque(int quantidade)
    {
        if (Estoque + quantidade < 0)
            throw new Exception("Estoque insuficiente para esta operação.");

        Estoque += quantidade;
    }

    private void ValidateDomain(string nome, decimal preco, int estoque)
    {
        if (string.IsNullOrEmpty(nome))
            throw new Exception("O nome do componente é obrigatório.");

        if (preco < 0)
            throw new Exception("O preço não pode ser negativo.");

        if (estoque < 0)
            throw new Exception("O estoque inicial não pode ser negativo.");
    }
}