using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaPeçasEletronicas.Models;

namespace LojaPeçasEletronicas.Data
{
    public class LojaPeçasEletronicasContext : DbContext
    {
        public LojaPeçasEletronicasContext (DbContextOptions<LojaPeçasEletronicasContext> options)
            : base(options)
        {
        }

        public DbSet<LojaPeçasEletronicas.Models.Produto> Produto { get; set; } = default!;
        public DbSet<LojaPeçasEletronicas.Models.Categoria> Categoria { get; set; } = default!;
        public DbSet<LojaPeçasEletronicas.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<LojaPeçasEletronicas.Models.Avaliacao> Avaliacao { get; set; } = default!;
        public DbSet<LojaPeçasEletronicas.Models.Pagamento> Pagamento { get; set; } = default!;
        public DbSet<LojaPeçasEletronicas.Models.PagamentoProduto> PagamentoProduto { get; set; } = default!;
    }
}
