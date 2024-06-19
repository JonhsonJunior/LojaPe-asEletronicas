/*using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaPeçasEletronicas.Data;
using LojaPeçasEletronicas.Models;

namespace LojaPeçasEletronicas.services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApplicationDbContext _context;

        public ProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }
    }
}
*/