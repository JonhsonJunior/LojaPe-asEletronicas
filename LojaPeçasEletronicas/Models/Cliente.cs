namespace LojaPeçasEletronicas.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }

        public ICollection<Avaliacao>? Avaliacoes { get; set; }
        public ICollection<Pagamento>? Pagamentos { get; set; }
    }
}
