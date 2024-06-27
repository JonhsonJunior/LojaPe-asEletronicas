using LojaPeçasEletronicas.Data;
using LojaPeçasEletronicas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaPeçasEletronicas.Controllers
{
    public class PagamentoProdutosController : Controller
    {
        private readonly LojaPeçasEletronicasContext _context;

        public PagamentoProdutosController(LojaPeçasEletronicasContext context)
        {
            _context = context;
        }

        // GET: PagamentoProdutos
        public async Task<IActionResult> Index()
        {
            var pagamentoProdutos = await _context.PagamentoProduto.Include(p => p.Produto).ToListAsync();
            return View(pagamentoProdutos);
        }

        // GET: PagamentoProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pagamentoProduto = await GetPagamentoProdutoByIdAsync(id.Value);
            if (pagamentoProduto == null) return NotFound();

            return View(pagamentoProduto);
        }

        // GET: PagamentoProdutos/Create
        public IActionResult Create()
        {
            PopulateProdutosDropDownList();
            return View();
        }

        // POST: PagamentoProdutos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoProdutoId,ProdutoId,Quantidade")] PagamentoProduto pagamentoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateProdutosDropDownList(pagamentoProduto.ProdutoId);
            return View(pagamentoProduto);
        }

        // GET: PagamentoProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var pagamentoProduto = await GetPagamentoProdutoByIdAsync(id.Value);
            if (pagamentoProduto == null) return NotFound();

            PopulateProdutosDropDownList(pagamentoProduto.ProdutoId);
            return View(pagamentoProduto);
        }

        // POST: PagamentoProdutos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoProdutoId,ProdutoId,Quantidade")] PagamentoProduto pagamentoProduto)
        {
            if (id != pagamentoProduto.PagamentoProdutoId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoProdutoExists(pagamentoProduto.PagamentoProdutoId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateProdutosDropDownList(pagamentoProduto.ProdutoId);
            return View(pagamentoProduto);
        }

        // GET: PagamentoProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var pagamentoProduto = await GetPagamentoProdutoByIdAsync(id.Value);
            if (pagamentoProduto == null) return NotFound();

            return View(pagamentoProduto);
        }

        // POST: PagamentoProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentoProduto = await _context.PagamentoProduto.FindAsync(id);
            if (pagamentoProduto != null)
            {
                _context.PagamentoProduto.Remove(pagamentoProduto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoProdutoExists(int id)
        {
            return _context.PagamentoProduto.Any(e => e.PagamentoProdutoId == id);
        }

        private async Task<PagamentoProduto?> GetPagamentoProdutoByIdAsync(int id)
        {
            return await _context.PagamentoProduto.Include(p => p.Produto).FirstOrDefaultAsync(m => m.PagamentoProdutoId == id);
        }

        private void PopulateProdutosDropDownList(object? selectedProduto = null)
        {
            var produtosQuery = from p in _context.Produto
                                orderby p.Nome
                                select p;
            ViewBag.ProdutoId = new SelectList(produtosQuery.AsNoTracking(), "ProdutoId", "Nome", selectedProduto);
        }
    }
}