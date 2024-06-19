using LojaPeçasEletronicas.Models;

namespace LojaPeçasEletronicas.services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
    }
}
