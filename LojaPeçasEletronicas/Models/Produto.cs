﻿namespace LojaPeçasEletronicas.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public ICollection<Avaliacao>? Avaliacoes { get; set; }
        public ICollection<PagamentoProduto>? PagamentoProdutos { get; set; }
    }
}