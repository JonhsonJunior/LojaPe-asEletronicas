namespace LojaPeçasEletronicas.Models
{
    public class PagamentoProduto
    {
        public int PagamentoProdutoId { get; set; }
        public Pagamento? Pagamento { get; set; }

        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
