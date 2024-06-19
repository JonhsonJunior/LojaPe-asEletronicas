namespace LojaPeçasEletronicas.Models
{
    public class Produto
    {

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public string? ImagemUrl { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        // Propriedade de Estoque
        public Estoque? Estoque { get; set; }

        public ICollection<Avaliacao>? Avaliacoes { get; set; }
        public ICollection<PagamentoProduto>? PagamentoProdutos { get; set; }

        public Produto()
        {
            Estoque = new Estoque(0); // Inicializando com zero unidades
        }
    }
}
