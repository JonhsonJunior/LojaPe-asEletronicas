namespace LojaPeçasEletronicas.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int Nota { get; set; }
        public string? Comentario { get; set; }
        public DateTime Data { get; set; }
    }
}
