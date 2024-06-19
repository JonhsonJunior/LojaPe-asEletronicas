namespace LojaPeçasEletronicas.Models
{
    public class Estoque
    {
        public int Quantidade { get; set; }

        public Estoque(int quantidadeInicial)
        {
            Quantidade = quantidadeInicial;
        }

        public void AdicionarEstoque(int quantidade)
        {
            Quantidade += quantidade;
        }

        public void RemoverEstoque(int quantidade)
        {
            if (quantidade <= Quantidade)
            {
                Quantidade -= quantidade;
            }
            else
            {
                throw new InvalidOperationException("Quantidade insuficiente em estoque.");
            }
        }
    }
}
