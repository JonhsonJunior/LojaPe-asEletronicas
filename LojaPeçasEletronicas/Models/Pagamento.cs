namespace LojaPeçasEletronicas.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public decimal ValorTotal { get; set; }
        public string? FormaDePagamento { get; set; }
        public string? StatusDoPagamento { get; set; }
        public DateTime Data { get; set; }

        public ICollection<PagamentoProduto>? PagamentoProdutos { get; set; }
    }

}
